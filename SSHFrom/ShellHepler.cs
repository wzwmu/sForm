using System;
using System.Collections.Generic;
using System.IO; 
using System.Text;
using System.Text.RegularExpressions;
using Tamir.SharpSsh.jsch;

namespace SSHFrom
{
    class ShellHepler
    {
        MemoryStream outputstream = new MemoryStream();
        Tamir.SharpSsh.SshStream inputstream = null; 
        /// <summary> 
        /// 命令等待标识 
        /// </summary> 

        List<string> waitMark = new List<string>() { "]#", "]$" };
        public bool OpenShell(string host, string username, string pwd)
        {
            try
            {
                inputstream = new Tamir.SharpSsh.SshStream(host, username, pwd);
                ///我手动加进去的方法。。为了读取输出信息 
                inputstream.set_OutputStream(outputstream);
                System.Threading.ThreadPool.QueueUserWorkItem(thread);
                return inputstream != null;
            }
            catch { throw; }
        }
        public bool ShellImmediately(string cmd)
        {
            if (inputstream == null) return false;
            inputstream.Write(cmd);
            inputstream.Flush();
            System.Threading.Thread.Sleep(200);
            return true;
        }
        public bool Shell(string cmd)
        {
            if (inputstream == null) return false;
            string initinfo = GetAllString();
            inputstream.Write(cmd);
            inputstream.Flush();
            string currentinfo = GetAllString();
            while (currentinfo == initinfo)
            {
                System.Threading.Thread.Sleep(100);
                currentinfo = GetAllString();
            }
            return true;
        }
        public event Action<String> OutputEvent;
        long pos=0;
        private void thread(Object obj)
        {
            while(inputstream != null)
            {
                try
                {
                    if (pos < outputstream.Position)
                    {
                        long len = outputstream.Length;
                        byte[] buffer = new byte[len - pos];
                        outputstream.Seek(pos, SeekOrigin.Begin);
                        outputstream.Read(buffer, 0, buffer.Length);
                        string outinfo = Encoding.UTF8.GetString(buffer);
                        outputstream.Flush();
                        Regex r = new Regex("\\u001b\\[[^m]*m");
                        if (OutputEvent != null) OutputEvent(r.Replace(outinfo, ""));
                        pos = outputstream.Position;
                    }
                }
                catch { }
                System.Threading.Thread.Sleep(200);
            }
        }
        public string GetAllString() 
        { 
            string outinfo = Encoding.UTF8.GetString(outputstream.ToArray()); 
            //等待命令结束字符  
            while (!outinfo.Trim().EndsWith(waitMark[0]) && !outinfo.Trim().EndsWith(waitMark[1])) 
            { 
                System.Threading.Thread.Sleep(200); 
                outinfo = Encoding.UTF8.GetString(outputstream.ToArray()); 
            } 
            outputstream.Flush(); 
            return outinfo.ToString();
        }
        public string GetLastString()
        {
            string outinfo = Encoding.UTF8.GetString(outputstream.ToArray());
            outputstream.Flush();
            string[] strs = outinfo.Trim().Split(waitMark.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return strs[strs.Length - 1];
        }
        public void Close()
        {
            if (inputstream != null) inputstream.Close();
            inputstream = null;
        }
    }
}
