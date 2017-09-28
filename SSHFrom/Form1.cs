using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; 
using System.Text; 
using System.Windows.Forms;
using Tamir.SharpSsh;
using System.IO.Compression;
using System.Text.RegularExpressions;

namespace SSHFrom
{
    public partial class Form1 : Form
    {
        CustomerHelper _customer;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_customer != null)
                _customer.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (this.btnOpen.Text == "连接")
            {
                _customer = new CustomerHelper();
                _customer.OutputEvent += Shell_OutputEvent;
                _customer.Open(txtHost.Text, txtUser.Text, txtPass.Text);
                this.btnOpen.Text = "关闭连接";
                this.groupBox1.Enabled = true;
            }
            else
            {
                if(_customer!=null)
                    _customer.Close();
                _customer = null;
                this.btnOpen.Text = "连接";
                this.groupBox1.Enabled = false;
            }

        } 
        private void txtSendMsg_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == 13)
            {
                _customer.ShellAasyn(this.txtSendMsg.Text);
                this.txtSendMsg.Text = "";
                while (_customer.Status == 2)
                {
                    Application.DoEvents();
                }
            }
        }
        private void Shell_OutputEvent(string output)
        {
            if (this.txtOutput.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(Shell_OutputEvent), output);
            }
            else
            { 
                this.txtOutput.AppendText(output);
                this.txtOutput.ScrollToCaret();
            }
        }

        private void btnTask_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
