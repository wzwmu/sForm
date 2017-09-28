using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHFrom
{
    public partial class Form3 : Form
    {
        private string endTag = "---";
        private CustomerHelper helper;
        private bool _stoping = false;
        public Form3()
        {
            InitializeComponent();
            helper = new CustomerHelper();
            helper.MessgaeEvent += Helper_MessgaeEvent;
            helper.StatusEvent += Helper_StatusEvent;
            helper.OutputEvent += Helper_OutputEvent;
            loadInfo();
        }
        private void loadInfo()
        {
            List<string> list = read("script.txt");
            this.listView1.Items.Clear();
            int i = -2;
            string[] script = new string[6];
            foreach (string str in list)
            {
                if (i < 0)
                {
                    if (i == -2) this.txtSource.Text = str;
                    else if (i == -1) this.txtWhite.Text = str;
                    i++;
                    continue;
                }
                if (str.StartsWith(endTag))
                {
                    ListViewItem item = new ListViewItem(new string[] { script[0], script[1], script[2], "未知", script[4], script[5] });
                    this.listView1.Items.Add(item);
                    i = 0;
                    continue;
                }
                if (i < 6)
                {
                    script[i] = str;
                }
                else
                {
                    script[5] += "\r\n" + str;
                }
                i++;
            }  
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(this.txtSource.Text);
            list.Add(this.txtWhite.Text);
            foreach(ListViewItem item in this.listView1.Items)
            {
                for(int i = 0; i < item.SubItems.Count; i++)
                {
                    list.Add(item.SubItems[i].Text);
                }
                list.Add(endTag);
            }
            write("script.txt", list);
        }
        private List<string> read(string path)
        {
            List<string> list = new List<string>();
            if (!File.Exists(path)) File.Create(path).Close();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            sr.Close();
            return list;
        }
        private void write(string path,List<string> list)
        {
            if (!File.Exists(path)) File.Create(path).Close();
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            for(int i = 0; i < list.Count; i++)
            {
                sw.WriteLine(list[i]);
            }
            sw.Flush();
            sw.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(new string[] { this.txtHost.Text,this.txtUser.Text,this.txtPass.Text,"未知",this.txtUrl.Text,this.txtScript.Text});
            this.listView1.Items.Add(item);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0) return;
            ListViewItem item = this.listView1.SelectedItems[0];
            this.txtHost.Text = item.SubItems[0].Text;
            this.txtUser.Text = item.SubItems[1].Text;
            this.txtPass.Text = item.SubItems[2].Text;
            //"未知" = item.SubItems[0].Text;
            this.txtUrl.Text = item.SubItems[4].Text;
            this.txtScript.Text = item.SubItems[5].Text;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0) return;
            ListViewItem item = this.listView1.SelectedItems[0];
            item.SubItems[0].Text = this.txtHost.Text;
            item.SubItems[1].Text = this.txtUser.Text;
            item.SubItems[2].Text = this.txtPass.Text;
            //"未知" = item.SubItems[0].Text;
            item.SubItems[4].Text = this.txtUrl.Text;
            item.SubItems[5].Text = this.txtScript.Text;

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0) return;
            this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in this.listView1.Items)
            {
                item.SubItems[3].Text = "检测中..."; 
                Task task = new Task(obj => GetUrltoHtml((string)obj), item.SubItems[4].Text.Split(',')[0]);
                task.Start();
            }
        }
        public delegate void DelegateCheckCallback(string url, string str);
        private void checkCallback(string url,string str)
        {
            if (this.listView1.InvokeRequired)
            {
                this.BeginInvoke(new DelegateCheckCallback(checkCallback), new object[] { url,str });
            }
            else
            {
                foreach (ListViewItem item in this.listView1.Items)
                {
                    string[] strs = item.SubItems[4].Text.Split(',');
                    string val = str.IndexOf( strs.Length<2 ?"login.do": strs[1]) >= 0 ? "开启" : "关闭";
                    if (strs[0] == url)
                        item.SubItems[3].Text = val;
                }
            }
        }
        private void GetUrltoHtml(string url)
        {
            try
            {
                System.Net.WebRequest wReq = System.Net.WebRequest.Create(url);
                wReq.Timeout = 35000;
                System.Net.WebResponse wResp = wReq.GetResponse();
                System.IO.Stream respStream = wResp.GetResponseStream();
                // Dim reader As StreamReader = New StreamReader(respStream)
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding("utf-8")))
                {
                    string str= reader.ReadToEnd();
                    respStream.Close();
                    wResp.Close();
                    checkCallback(url,str);
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //errorMsg = ex.Message;
            }
            checkCallback(url, "");
        }


        private void Helper_StatusEvent(object obj)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<object>(Helper_StatusEvent), obj);
            }
            else
            {
                this.btnRun.Enabled=this.btnTest.Enabled = (helper.Status != 2);
            }
        }
        private void Helper_OutputEvent(string msg)
        {
            if (this.txtOutPut.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Helper_OutputEvent), msg);
            }
            else
            {
                this.txtOutPut.AppendText("\r\n");
                this.txtOutPut.AppendText(msg);
                this.txtOutPut.ScrollToCaret();
            }
        }


        private void Helper_MessgaeEvent(string msg)
        {
            if (this.txtMessage.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Helper_MessgaeEvent), msg);
            }
            else
            {
                try
                {
                    this.txtMessage.AppendText("\r\n");
                    this.txtMessage.AppendText(msg);
                    this.txtMessage.ScrollToCaret();
                }
                catch { }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (helper != null) helper.Close();
        }
        private void runTask(string host,string user,string pass,string script)
        {
            //helper.Close(); 
            //helper.Open(host, user, pass); 
            helper.ShellAasyn("open "+ host+" "+ user+" "+ pass);
            foreach (string str in script.Split('\n'))
            {
                if (str.Trim().StartsWith("//")) continue;
                if (_stoping) break;
                while (helper.Status == 2)
                {
                    if (_stoping) break;
                    Application.DoEvents();
                }
                helper.ShellAasyn(str.Trim());
            }
            while (helper.Status == 2)
            {
                if (_stoping) break;
                Application.DoEvents();
            }
            //helper.Close();
            helper.ShellAasyn("close");
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            _stoping = false;
            this.txtMessage.Clear();
            this.txtOutPut.Clear();
            runTask(this.txtHost.Text, this.txtUser.Text, this.txtPass.Text,this.txtScript.Text);
            _stoping = false;
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            _stoping = false;
            if (this.listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("请勾选服务器，进行脚本");
                return;
            }
            this.txtMessage.Clear();
            this.txtOutPut.Clear();
            foreach (ListViewItem item in this.listView1.CheckedItems)
            {
                item.BackColor = Color.LightGray;
            }
            foreach (ListViewItem item in this.listView1.CheckedItems)
            {
                item.Selected = true;
                runTask(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[5].Text);
                item.BackColor = Color.LimeGreen;
                item.SubItems[3].Text = "检测中...";
                Task task = new Task(obj => GetUrltoHtml((string)obj), item.SubItems[4].Text.Split(',')[0]);
                task.Start();
                if (_stoping) break;
            }
            foreach (ListViewItem item in this.listView1.CheckedItems)
            {
                item.BackColor = Color.White;
            }
            _stoping = false;
        }

        private void btnZip_Click(object sender, EventArgs e)
        { 
            helper.ShellAasyn("zip " + this.txtSource.Text + " DMS.zip " + this.txtWhite.Text); 
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

        private void txtScript_TextChanged(object sender, EventArgs e)
        {
            /*
            int pos = this.txtScript.SelectionStart;
            int len = this.txtScript.SelectionLength;

            for(int i=0;i< this.txtScript.Lines.Length; i++)
            {
                if (this.txtScript.Lines[i].StartsWith("//"))
                { 
                }
            }
            */
        }

        private void ckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in this.listView1.Items)
            {
                item.Checked = this.ckAll.Checked;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _stoping = true;
        }
    }
}
