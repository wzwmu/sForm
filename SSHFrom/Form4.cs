using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSHFrom.BO;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace SSHFrom
{
    public partial class Form4 : Form
    {
        CustomerHelper _helper;
        PublishBO _publicshBO;
        string[] whiteList;
        public Form4(CustomerHelper helper, PublishBO publicshBO)
        {
            _helper = helper;
            _publicshBO = publicshBO;
            whiteList = _publicshBO.White.Split(',');
            InitializeComponent();

            loadSource();
            //loadTarget();
        } 
        private void loadSource(TreeNode pNode = null)
        { 
            TreeNodeCollection nodes;
            string path = "";
            if (pNode == null)
            {
                nodes = this.treeView1.Nodes;
                nodes.Clear(); 
            }
            else
            {
                nodes = pNode.Nodes; 
                path = pNode.Tag.ToString();
            }
            bool b = false; 
            foreach (string str in whiteList)
            {
                if (path.StartsWith(str))
                {
                    b = true;
                    break;
                }
            }
            if (!b && path!="")
                return;
            DirectoryInfo root = new DirectoryInfo(_publicshBO.Source + path);
            foreach (DirectoryInfo dir in root.GetDirectories())
            {
                TreeNode node = new TreeNode(dir.Name);
                node.Tag = dir.FullName.Replace(_publicshBO.Source,"");
                nodes.Add(node);
                loadSource(node);
            } 
            foreach (FileInfo file in root.GetFiles())
            {
                TreeNode node = new TreeNode(file.Name);
                node.Tag = file.FullName.Replace(_publicshBO.Source, "");
                nodes.Add(node);
            }
        }
        private void loadTarget(TreeNode pNode = null)
        {
            TreeNodeCollection nodes;
            string path;
            if (pNode == null)
            {
                nodes = this.treeView2.Nodes;
                nodes.Clear();
                path = "";
            }
            else
            {
                nodes = pNode.Nodes;
                path = pNode.Tag.ToString();
            }
            bool b = false;
            foreach (string str in whiteList)
            {
                if (path.StartsWith(str))
                {
                    b = true;
                    break;
                }
            }
            if (!b && path != "")
                return;
            foreach (string dir in _helper.GetDirList(_publicshBO.RemotePath + path))
            { 
                if (dir=="." || dir == "..") continue; 
                TreeNode node = new TreeNode(dir);  
                node.Tag = path + "/"+ dir;
                nodes.Add(node);
                //loadTarget(node);
            }
            foreach (string file in _helper.GetFileList(_publicshBO.RemotePath + path))
            {
                TreeNode node = new TreeNode(file);
                node.Tag = path + "/" + file;
                nodes.Add(node);
            } 
        }

        private void treeView2_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //new Thread(new ParameterizedThreadStart((o) => { InitChildNode(o); })) { IsBackground = true }.Start();

        }
        /*
        private void InitChildNode(object o)
        {
            try
            {
                TreeNode trNode = o as TreeNode;
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                if (trNode == null || trNode.IsInitChild || trNodeEx.ChildNodes.Count <= 0)
                    return;
                int iLength = trNodeEx.ChildNodes.Count;//当子节点过多的话，会出现卡主线程的情况。
                treeView2.BeginInvoke(new MethodInvoker(() =>
                {
                    treeView2.BeginUpdate();
                    trNodeEx.Nodes.Clear();
                }));
                for (int i = 0; i < iLength; i++)
                {
                    if (!trNodeEx.ChildNodes[i].IsNeedVisible())
                        continue;
                    tvTest.BeginInvoke(new _delInitChildNode((node) =>
                    {
                        trNode.Nodes.Add(node);
                        node.SetNodeText();

                    }), trNodeEx.ChildNodes[i]);
                }
                trNodeEx.IsInitChild = true;
                tvTest.BeginInvoke(new MethodInvoker(() =>
                {
                    tvTest.EndUpdate();
                }));
                //frmLog.Instant.WriteLog(string.Format("initchildnode.time1:{0}", sw1.ElapsedMilliseconds.ToString()));
                ////tvTest.EndInvoke()
                //sw1.Stop();
                //frmLog.Instant.WriteLog(string.Format("initchildnode.time:{0}", sw1.ElapsedMilliseconds.ToString()));
            }
            catch (Exception ex)
            {
                //frmLog.Instant.WriteLog(ex.Message);
            }
        }
        */
    }
}
