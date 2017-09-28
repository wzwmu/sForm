using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SSHFrom.BO;
using System.Diagnostics;

namespace SSHFrom
{
    public partial class Form2 : Form
    {
        CustomerHelper helper;
        public Form2()
        {
            InitializeComponent();
            this.groupBox1.Enabled = false;
        }
        private void txtSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = ((TextBox)sender).Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ((TextBox)sender).Text = dialog.SelectedPath;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnZip_Click(null, null);
            shellCmd("sleep 1000");
            btnUpFile_Click(null, null);
            shellCmd("sleep 1000");
            btnUnZip_Click(null, null);
            shellCmd("sleep 1000");
            btnKill_Click(null, null);
            shellCmd("sleep 1000");
            btnStartup_Click(null, null);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if ((sender is Control && ((Control)sender).Text == "连接")
                || (sender is ToolStripItem && ((ToolStripItem)sender).Text == "连接")
                )
            {
                this.txtOutput.Text = "";
                if (helper == null)
                {
                    helper = new CustomerHelper();
                    helper.StatusEvent += Helper_StatusEvent;
                    helper.OutputEvent += Shell_OutputEvent;
                    helper.MessgaeEvent += Shell_MessageEvent;
                }
                helper.Open(this.txtHost.Text, this.txtUser.Text, this.txtPass.Text);
                if (sender is Control)
                    ((Control)sender).Text = "关闭";
                else if (sender is ToolStripItem)
                    ((ToolStripItem)sender).Text = "关闭";
            }
            else
            {
                if (helper != null)
                {
                    helper.Close();
                }
                if (sender is Control)
                    ((Control)sender).Text = "连接";
                else if (sender is ToolStripItem)
                    ((ToolStripItem)sender).Text = "连接";
            }
        }
        private void shellCmd(string cmd)
        {
            while (helper.Status == 2)
            {
                Application.DoEvents();
            }
            this.groupBox1.Enabled = false;
            helper.ShellAasyn(cmd);
        }
        private void Helper_StatusEvent(object obj)
        {
            if (this.groupBox1.InvokeRequired)
            {
                this.BeginInvoke(new Action<object>(Helper_StatusEvent), obj);
            }
            else
            {
                if (helper == null) this.groupBox1.Enabled = true;
                else if (helper.Status != 2 && !this.groupBox1.Enabled) this.groupBox1.Enabled = true;
                else if (helper.Status == 2 && this.groupBox1.Enabled) this.groupBox1.Enabled = false;
            }
        }

        private void btnZip_Click(object sender, EventArgs e)
        {
            string source = this.txtSource.Text;
            string dir = this.txtRemotePath.Text.TrimEnd(new char[] { '/' });
            string target = dir.Split('/').Last();
            string zipFile = target + ".zip";
            string remotePath = txtRemotePath.Text.Remove(txtRemotePath.Text.LastIndexOf(target));
            List<string> wList = txtWhite.Text.Split(',').ToList();
            DateTime dt = ckInc.Checked ? this.dateInc.Value.Date + this.timeInc.Value.TimeOfDay : DateTime.MinValue;
            if (ckInc.Checked)
                shellCmd("zip " + source + " " + zipFile + " " + txtWhite.Text + " " + dt.ToString());
            else
                shellCmd("zip " + source + " " + zipFile + " " + txtWhite.Text);
        }


        private void btnUpFile_Click(object sender, EventArgs e)
        {
            string dir = this.txtRemotePath.Text.TrimEnd(new char[] { '/' });
            string target = dir.Split('/').Last();
            string zipFile = target + ".zip";
            string remotePath = txtRemotePath.Text.Remove(txtRemotePath.Text.LastIndexOf(target));
            //sftp.Put(zipFile, remotePath);
            shellCmd("up " + zipFile + " " + remotePath);
        }
        private void btnUnZip_Click(object sender, EventArgs e)
        {
            string dir = this.txtRemotePath.Text.TrimEnd(new char[] { '/' });
            string target = dir.Split('/').Last();
            string zipFile = target + ".zip";
            string remotePath = txtRemotePath.Text.Remove(txtRemotePath.Text.LastIndexOf(target));
            //remote 目录
            shellCmd("wait cd " + remotePath);
            //解压
            shellCmd("wait unzip -o -d ./DMS ./" + zipFile);
        }
        private void btnKill_Click(object sender, EventArgs e)
        {
            //检查tomcat
            shellCmd("wait ps -ef|grep " + this.txtReg.Text);
            shellCmd("ck " + this.txtUser.Text + " *([\\d]*) [^r]*" + this.txtReg.Text);
        }
        private void btnStartup_Click(object sender, EventArgs e)
        {
            shellCmd(txtStartBefor.Text);
            //启动 
            shellCmd(txtStartup.Text);
        }
        private void Shell_OutputEvent(string output)
        {
            if (this.txtOutput.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Shell_OutputEvent), output);
            }
            else
            {
                Regex r = new Regex("\\u001b\\[[^m]*m");
                output = r.Replace(output, "");
                this.txtOutput.AppendText(output);
                this.txtOutput.ScrollToCaret();
            }
        }
        private void Shell_MessageEvent(string msg)
        {
            if (this.txtInfo.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Shell_MessageEvent), msg);
            }
            else
            {
                this.txtInfo.AppendText("\r\n");
                this.txtInfo.AppendText(msg);
                this.txtInfo.ScrollToCaret();
            }
        }

        private void checkConfig(Control ct)
        {
            if (ct is TextBox)
            {
                if (Config.GetSetting(ct.Name) == null) Config.AddSetting(ct.Name, ct.Text);
                else ct.Text = Config.GetSetting(ct.Name);
            }
            else if (ct is DateTimePicker)
            {
                if (Config.GetSetting(ct.Name) == null) Config.AddSetting(ct.Name, ((DateTimePicker)ct).Value.ToString());
                else ((DateTimePicker)ct).Value = DateTime.Parse(Config.GetSetting(ct.Name));
            }
        }
        private void updateConfig(Control ct)
        {
            if (ct is TextBox)
            {
                Config.UpdateSeeting(ct.Name, ct.Text);
            }
            else if (ct is DateTimePicker)
            {
                Config.UpdateSeeting(ct.Name, ((DateTimePicker)ct).Value.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                saveConfig(dialog.FileName);
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                loadConfig(dialog.FileName);
            }
        }
        private void loadConfig(string fileName)
        {
            PublishBO p = null;
            try
            {
                p = (PublishBO)Utils.Deserialize(fileName);
            }
            catch (Exception e)
            {
                MessageBox.Show("加载失败");
            }
            this.txtHost.Text = p.Server.Host;
            this.txtUser.Text = p.Server.User;
            this.txtPass.Text = p.Server.Pass;

            this.txtSource.Text = p.Source;
            this.txtWhite.Text = p.White;
            this.dateInc.Value = p.DatetimeInc;
            this.timeInc.Value = p.DatetimeInc;

            this.txtRemotePath.Text = p.RemotePath;
            this.txtReg.Text = p.Reg;
            this.txtStartBefor.Text = p.StartBefor;
            this.txtStartup.Text = p.Startup;
        }
        private void saveConfig(string fileName)
        {
            ServerBO server = new ServerBO(this.txtHost.Text, this.txtUser.Text, this.txtPass.Text);
            PublishBO publish = new PublishBO(server, this.txtSource.Text, this.txtWhite.Text,
                 this.ckInc.Checked, (this.dateInc.Value.Date + this.timeInc.Value.TimeOfDay),
                 this.txtRemotePath.Text, this.txtReg.Text, this.txtStartBefor.Text, this.txtStartup.Text);
            Utils.Serialize(fileName, publish);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (helper != null) helper.Close();
        }

        private void biView_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = !this.groupBox1.Visible;
        }

        private void btnFtp_Click(object sender, EventArgs e)
        {
            ServerBO server = new ServerBO(this.txtHost.Text, this.txtUser.Text, this.txtPass.Text);
            PublishBO publish = new PublishBO(server, this.txtSource.Text, this.txtWhite.Text,
                 this.ckInc.Checked, (this.dateInc.Value.Date + this.timeInc.Value.TimeOfDay),
                 this.txtRemotePath.Text, this.txtReg.Text, this.txtStartBefor.Text, this.txtStartup.Text);
            Form4 f = new Form4(helper, publish);
            f.Show(this);
        }

        private bool running = false;
        private void btnCompile_Click(object sender, EventArgs e)
        {
            //javac - encoding UTF - 8 - d classesA - sourcepath C:\workspaceyili\DMS\src - classpath classesA; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - aop - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - aspects - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - beans - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - build - src - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - context - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - context - support - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - core - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - expression - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - instrument - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - instrument - tomcat - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - jdbc - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - jms - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - orm - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - oxm - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - struts - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - test - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - tx - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - web - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - webmvc - 3.2.2.jar; C:\workspaceyili\DMS\WebContent\WEB - INF\lib\spring - webmvc - portlet - 3.2.2.jar; C:\workspaceyili\DMS\src\com\yl\common\annotation\*.java

            running = false;
            compile(new DirectoryInfo(txtCompileSor.Text));
        }
        private void compile(DirectoryInfo root)
        {
            string argument = "";
            //encoding
            argument += " -encoding UTF-8";
            argument += " -Xlint:unchecked";
            argument += " -Xlint:deprecation";
            argument += " -sourcepath " + txtCompileSor.Text;
            argument += " -d " + txtCompileTarget.Text;
            argument += " -classpath \"" + txtCompileTarget.Text;
            foreach (string libPath in txtCompileLib.Text.Split(';'))
                foreach (FileInfo file in (new DirectoryInfo(libPath)).GetFiles())
                {
                    argument += ";" + file.FullName;
                }

            argument += "\" " + root.FullName + "\\*.java";
            if (root.FullName.EndsWith("amend"))
            {

            }
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Program Files\\Java\\jdk1.7.0\\bin\\javac.exe";
            start.Arguments = argument;
            //start.WorkingDirectory = ".";
            start.UseShellExecute = false;
            start.RedirectStandardInput = true;
            start.RedirectStandardOutput = true;
            //process.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            start.CreateNoWindow = true; 
            //启动  
            running = true;


            Process cmd = Process.Start(start);
             
            cmd.BeginOutputReadLine(); 
            cmd.WaitForExit();
            
            cmd.Close(); 

            foreach (DirectoryInfo dir in root.GetDirectories())
            {
                //if (!running)
                compile(dir);
            }
        } 
    }
}
