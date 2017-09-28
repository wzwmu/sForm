using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSHFrom
{
    public class CustomerHelper
    {
        private SFTPHelper _sftp;
        private ShellHepler _shell;
        //0 未连接 1 连接 2 工作中
        private int _status = 0;

        public event Action<object> StatusEvent;
        public int Status { get => _status; set {
                _status = value;
                if (StatusEvent != null) StatusEvent(_status);
            }
        }
        public event Action<String> OutputEvent;
        public event Action<String> MessgaeEvent;
        private string _server;
        private string _username;
        private string _password;
        public void Open(string server,string username,string password)
        { 
            _server = server;
            _username = username;
            _password = password;
            _sftp = new SFTPHelper(server, username, password);  //端口号默认22，不需要填写  
            _sftp.Connect();

            _shell = new ShellHepler(); 
            _shell.OutputEvent += OutputEvent;
            _shell.OpenShell(server, username, password);
            message("连接服务器:" + _server);
            Status = 1;
        }
        public void Close()
        {
            if (_sftp != null)
            {
                if (_sftp.Connect()) _sftp.Disconnect();
                _sftp = null;
            }
            if (_shell != null)
            {
                _shell.OutputEvent -= OutputEvent;
                _shell.Close();
                _shell = null;
            }
            message("关闭连接:" + _server);
            Status = 0;
        } 
        private void message(string msg)
        {
            if (MessgaeEvent != null) MessgaeEvent(msg);
        }
        public List<string> GetDirList(string path)
        {
            return _sftp.GetFileList(path,true);
        }
        public List<string> GetFileList(string path)
        {
            return _sftp.GetFileList(path,false);
        }
        public void ShellAasyn(string msg)
        {
            Status = 2; 
            Task task = new Task(obj => Shell((string)obj), msg);
            task.Start(); 
        }
        public void Shell(string msg)
        {
            //message("---:"+msg);
            //System.Threading.Thread.Sleep(150);
            //Status = 1;
            //return;
            string[] cmd = msg.Split(' ');
            switch (cmd[0])
            {
                case "sleep":
                    message("睡眠:" + cmd[1]) ; 
                    System.Threading.Thread.Sleep(int.Parse(cmd[1])); 
                    message("睡眠结束");
                    break;
                case "open":
                    if (_sftp != null)
                        Close();
                    Open(cmd[1], cmd[2], cmd[3]);
                    break;
                case "close":
                    Close();
                    break;
                case "up":
                    if (cmd.Length == 3)
                    {
                        message("上传文件:" + cmd[1] + "->" + cmd[2]);
                        _sftp.Put(cmd[1], cmd[2]);
                        message("上传完成");
                    } 
                    break;
                case "down":
                    if (cmd.Length == 3)
                    {
                        message("下载文件:" + cmd[1] + "->" + cmd[2]);
                        _sftp.Get(cmd[1], cmd[2]);
                        message("下载完成");
                    }  
                    break; 
                case "zip":
                    if (cmd.Length >= 4)
                    {
                        message("压缩文件:"+ cmd[1]);
                        DateTime dt = DateTime.MinValue;
 
                        if (cmd.Length == 5)
                        {
                            try
                            {
                                dt = Convert.ToDateTime(cmd[4]);
                            }
                            catch (Exception e) { }
                        }
                        else if (cmd.Length == 6)
                        {
                            try
                            {
                                dt = Convert.ToDateTime(cmd[4]+" "+cmd[5]);
                            }
                            catch (Exception e) { }
                        }
                        int count=ZipHelper.ZipWhiteDirectory(cmd[1], cmd[2], cmd[3].Split(',').ToList(), dt);
                        message("压缩完成:"+count);
                    } 
                    break;
                    //检查 reg 匹配 kill -9
                case "ck":
                    message("循环查杀:");
                    string ps = _shell.GetLastString();
                    //Regex r = new Regex("root *([\\d]*) [^r]*" + msg.Substring(3));
                    Regex r = new Regex(msg.Substring(3));
                    Match m = r.Match(ps);
                    while (m != null && m.Groups.Count > 1)
                    {
                        //杀掉进程
                        _shell.ShellImmediately("kill -9 " + m.Groups[1].Value);
                        m = m.NextMatch();
                    }
                    message("完成");
                    break;
                case "wait":
                    message("等待执行:"+ msg.Substring(5));
                    _shell.Shell(msg.Substring(5));
                    message("完成:");
                    break;
                default:
                    message("执行:"+ msg);
                    _shell.ShellImmediately(msg);
                    System.Threading.Thread.Sleep(100);
                    break;
            }

            Status = 1; 
        }
    }
}
