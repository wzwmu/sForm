namespace SSHFrom
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtWhite = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtRemotePath = new System.Windows.Forms.TextBox();
            this.txtStartup = new System.Windows.Forms.TextBox();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnUpFile = new System.Windows.Forms.Button();
            this.btnUnZip = new System.Windows.Forms.Button();
            this.btnKill = new System.Windows.Forms.Button();
            this.btnStartup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCompile = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.dateInc = new System.Windows.Forms.DateTimePicker();
            this.timeInc = new System.Windows.Forms.DateTimePicker();
            this.ckInc = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartBefor = new System.Windows.Forms.TextBox();
            this.txtCompileLib = new System.Windows.Forms.TextBox();
            this.txtCompileTarget = new System.Windows.Forms.TextBox();
            this.txtCompileSor = new System.Windows.Forms.TextBox();
            this.ckCompile = new System.Windows.Forms.CheckBox();
            this.btnFtp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.biFile = new System.Windows.Forms.ToolStripMenuItem();
            this.biOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.biSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.biServer = new System.Windows.Forms.ToolStripMenuItem();
            this.biConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.biPulish = new System.Windows.Forms.ToolStripMenuItem();
            this.biZipFile = new System.Windows.Forms.ToolStripMenuItem();
            this.biUpFile = new System.Windows.Forms.ToolStripMenuItem();
            this.biUnZipFile = new System.Windows.Forms.ToolStripMenuItem();
            this.biKill = new System.Windows.Forms.ToolStripMenuItem();
            this.biStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.biRun = new System.Windows.Forms.ToolStripMenuItem();
            this.biView = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(421, 19);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "一键执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(77, 74);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(298, 21);
            this.txtSource.TabIndex = 1;
            this.txtSource.Text = "C:\\workspaceyili\\DMS\\WebContent";
            this.txtSource.Click += new System.EventHandler(this.txtSource_Click);
            // 
            // txtWhite
            // 
            this.txtWhite.Location = new System.Drawing.Point(77, 101);
            this.txtWhite.Name = "txtWhite";
            this.txtWhite.Size = new System.Drawing.Size(298, 21);
            this.txtWhite.TabIndex = 2;
            this.txtWhite.Text = "resource,WEB-INF\\classes\\com,WEB-INF\\messages";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(242, 20);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(53, 21);
            this.txtPass.TabIndex = 5;
            this.txtPass.Text = "123456";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(166, 20);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(70, 21);
            this.txtUser.TabIndex = 4;
            this.txtUser.Text = "root";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(77, 20);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(83, 21);
            this.txtHost.TabIndex = 3;
            this.txtHost.Text = "10.103.1.174";
            // 
            // txtRemotePath
            // 
            this.txtRemotePath.Location = new System.Drawing.Point(77, 155);
            this.txtRemotePath.Name = "txtRemotePath";
            this.txtRemotePath.Size = new System.Drawing.Size(298, 21);
            this.txtRemotePath.TabIndex = 6;
            this.txtRemotePath.Text = "/home/dms/tomcat/webapps/DMS";
            // 
            // txtStartup
            // 
            this.txtStartup.Location = new System.Drawing.Point(77, 236);
            this.txtStartup.Name = "txtStartup";
            this.txtStartup.Size = new System.Drawing.Size(298, 21);
            this.txtStartup.TabIndex = 10;
            this.txtStartup.Text = "./startup.sh";
            // 
            // txtReg
            // 
            this.txtReg.Location = new System.Drawing.Point(77, 182);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(298, 21);
            this.txtReg.TabIndex = 11;
            this.txtReg.Text = "/usr/bin/java";
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(384, 75);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(502, 329);
            this.txtOutput.TabIndex = 12;
            this.txtOutput.Text = "";
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(77, 18);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(65, 23);
            this.btnZip.TabIndex = 13;
            this.btnZip.Text = "压缩文件";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(301, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(40, 23);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnUpFile
            // 
            this.btnUpFile.Location = new System.Drawing.Point(148, 18);
            this.btnUpFile.Name = "btnUpFile";
            this.btnUpFile.Size = new System.Drawing.Size(65, 23);
            this.btnUpFile.TabIndex = 14;
            this.btnUpFile.Text = "上传文件";
            this.btnUpFile.UseVisualStyleBackColor = true;
            this.btnUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // btnUnZip
            // 
            this.btnUnZip.Location = new System.Drawing.Point(219, 19);
            this.btnUnZip.Name = "btnUnZip";
            this.btnUnZip.Size = new System.Drawing.Size(65, 23);
            this.btnUnZip.TabIndex = 15;
            this.btnUnZip.Text = "解压文件";
            this.btnUnZip.UseVisualStyleBackColor = true;
            this.btnUnZip.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(290, 19);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(65, 23);
            this.btnKill.TabIndex = 16;
            this.btnKill.Text = "杀进程";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // btnStartup
            // 
            this.btnStartup.Location = new System.Drawing.Point(361, 19);
            this.btnStartup.Name = "btnStartup";
            this.btnStartup.Size = new System.Drawing.Size(65, 23);
            this.btnStartup.TabIndex = 17;
            this.btnStartup.Text = "启动进程";
            this.btnStartup.UseVisualStyleBackColor = true;
            this.btnStartup.Click += new System.EventHandler(this.btnStartup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZip);
            this.groupBox1.Controls.Add(this.btnStartup);
            this.groupBox1.Controls.Add(this.btnUpFile);
            this.groupBox1.Controls.Add(this.btnKill);
            this.groupBox1.Controls.Add(this.btnUnZip);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(384, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 50);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发布";
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(313, 126);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(65, 23);
            this.btnCompile.TabIndex = 18;
            this.btnCompile.Text = "编译文件";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(0, 274);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(384, 105);
            this.txtInfo.TabIndex = 20;
            this.txtInfo.Text = "";
            // 
            // dateInc
            // 
            this.dateInc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateInc.Location = new System.Drawing.Point(77, 128);
            this.dateInc.Name = "dateInc";
            this.dateInc.Size = new System.Drawing.Size(83, 21);
            this.dateInc.TabIndex = 22;
            // 
            // timeInc
            // 
            this.timeInc.CustomFormat = "";
            this.timeInc.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeInc.Location = new System.Drawing.Point(166, 128);
            this.timeInc.Name = "timeInc";
            this.timeInc.ShowUpDown = true;
            this.timeInc.Size = new System.Drawing.Size(70, 21);
            this.timeInc.TabIndex = 23;
            // 
            // ckInc
            // 
            this.ckInc.AutoSize = true;
            this.ckInc.Location = new System.Drawing.Point(16, 131);
            this.ckInc.Name = "ckInc";
            this.ckInc.Size = new System.Drawing.Size(60, 16);
            this.ckInc.TabIndex = 24;
            this.ckInc.Text = "增量：";
            this.ckInc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "服务器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "源目录：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "目标目录：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "进程检测：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "启动进程：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 30;
            this.label6.Text = "过滤名单：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCompile);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtStartBefor);
            this.groupBox2.Controls.Add(this.txtCompileLib);
            this.groupBox2.Controls.Add(this.txtCompileTarget);
            this.groupBox2.Controls.Add(this.txtCompileSor);
            this.groupBox2.Controls.Add(this.ckCompile);
            this.groupBox2.Controls.Add(this.btnFtp);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSource);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtWhite);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtHost);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRemotePath);
            this.groupBox2.Controls.Add(this.txtStartup);
            this.groupBox2.Controls.Add(this.ckInc);
            this.groupBox2.Controls.Add(this.txtReg);
            this.groupBox2.Controls.Add(this.timeInc);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.dateInc);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(384, 274);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "启动准备：";
            // 
            // txtStartBefor
            // 
            this.txtStartBefor.Location = new System.Drawing.Point(77, 209);
            this.txtStartBefor.Name = "txtStartBefor";
            this.txtStartBefor.Size = new System.Drawing.Size(298, 21);
            this.txtStartBefor.TabIndex = 36;
            this.txtStartBefor.Text = "cd /home/dms/tomcat/bin";
            // 
            // txtCompileLib
            // 
            this.txtCompileLib.Location = new System.Drawing.Point(77, 47);
            this.txtCompileLib.Name = "txtCompileLib";
            this.txtCompileLib.ReadOnly = true;
            this.txtCompileLib.Size = new System.Drawing.Size(83, 21);
            this.txtCompileLib.TabIndex = 35;
            this.txtCompileLib.Text = "C:\\workspaceyili\\DMS\\WebContent\\WEB-INF\\lib;C:\\Program Files\\Java\\jdk1.7.0\\jre\\li" +
    "b";
            // 
            // txtCompileTarget
            // 
            this.txtCompileTarget.Location = new System.Drawing.Point(242, 47);
            this.txtCompileTarget.Name = "txtCompileTarget";
            this.txtCompileTarget.ReadOnly = true;
            this.txtCompileTarget.Size = new System.Drawing.Size(128, 21);
            this.txtCompileTarget.TabIndex = 34;
            this.txtCompileTarget.Text = "C:\\workspaceyili\\DMS\\WebContent\\WEB-INF\\classes";
            this.txtCompileTarget.Click += new System.EventHandler(this.txtSource_Click);
            // 
            // txtCompileSor
            // 
            this.txtCompileSor.Location = new System.Drawing.Point(166, 47);
            this.txtCompileSor.Name = "txtCompileSor";
            this.txtCompileSor.ReadOnly = true;
            this.txtCompileSor.Size = new System.Drawing.Size(70, 21);
            this.txtCompileSor.TabIndex = 33;
            this.txtCompileSor.Text = "C:\\workspaceyili\\DMS\\src";
            this.txtCompileSor.Click += new System.EventHandler(this.txtSource_Click);
            // 
            // ckCompile
            // 
            this.ckCompile.AutoSize = true;
            this.ckCompile.Location = new System.Drawing.Point(16, 50);
            this.ckCompile.Name = "ckCompile";
            this.ckCompile.Size = new System.Drawing.Size(60, 16);
            this.ckCompile.TabIndex = 32;
            this.ckCompile.Text = "编译：";
            this.ckCompile.UseVisualStyleBackColor = true;
            // 
            // btnFtp
            // 
            this.btnFtp.Location = new System.Drawing.Point(347, 19);
            this.btnFtp.Name = "btnFtp";
            this.btnFtp.Size = new System.Drawing.Size(23, 23);
            this.btnFtp.TabIndex = 31;
            this.btnFtp.Text = "F";
            this.btnFtp.UseVisualStyleBackColor = true;
            this.btnFtp.Click += new System.EventHandler(this.btnFtp_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 379);
            this.panel1.TabIndex = 33;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biFile,
            this.biServer,
            this.biPulish,
            this.biView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 25);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // biFile
            // 
            this.biFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biOpen,
            this.biSaveAs});
            this.biFile.Name = "biFile";
            this.biFile.Size = new System.Drawing.Size(44, 21);
            this.biFile.Text = "配置";
            // 
            // biOpen
            // 
            this.biOpen.Name = "biOpen";
            this.biOpen.Size = new System.Drawing.Size(112, 22);
            this.biOpen.Text = "打开";
            this.biOpen.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // biSaveAs
            // 
            this.biSaveAs.Name = "biSaveAs";
            this.biSaveAs.Size = new System.Drawing.Size(112, 22);
            this.biSaveAs.Text = "另存为";
            this.biSaveAs.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // biServer
            // 
            this.biServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biConnect});
            this.biServer.Name = "biServer";
            this.biServer.Size = new System.Drawing.Size(56, 21);
            this.biServer.Text = "服务器";
            // 
            // biConnect
            // 
            this.biConnect.Name = "biConnect";
            this.biConnect.Size = new System.Drawing.Size(100, 22);
            this.biConnect.Text = "连接";
            this.biConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // biPulish
            // 
            this.biPulish.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.biZipFile,
            this.biUpFile,
            this.biUnZipFile,
            this.biKill,
            this.biStartup,
            this.toolStripSeparator1,
            this.biRun});
            this.biPulish.Name = "biPulish";
            this.biPulish.Size = new System.Drawing.Size(44, 21);
            this.biPulish.Text = "发布";
            // 
            // biZipFile
            // 
            this.biZipFile.Name = "biZipFile";
            this.biZipFile.Size = new System.Drawing.Size(124, 22);
            this.biZipFile.Text = "压缩文件";
            this.biZipFile.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // biUpFile
            // 
            this.biUpFile.Name = "biUpFile";
            this.biUpFile.Size = new System.Drawing.Size(124, 22);
            this.biUpFile.Text = "上传文件";
            this.biUpFile.Click += new System.EventHandler(this.btnUpFile_Click);
            // 
            // biUnZipFile
            // 
            this.biUnZipFile.Name = "biUnZipFile";
            this.biUnZipFile.Size = new System.Drawing.Size(124, 22);
            this.biUnZipFile.Text = "解压文件";
            this.biUnZipFile.Click += new System.EventHandler(this.btnUnZip_Click);
            // 
            // biKill
            // 
            this.biKill.Name = "biKill";
            this.biKill.Size = new System.Drawing.Size(124, 22);
            this.biKill.Text = "杀进程";
            this.biKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // biStartup
            // 
            this.biStartup.Name = "biStartup";
            this.biStartup.Size = new System.Drawing.Size(124, 22);
            this.biStartup.Text = "启动进程";
            this.biStartup.Click += new System.EventHandler(this.btnStartup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // biRun
            // 
            this.biRun.Name = "biRun";
            this.biRun.Size = new System.Drawing.Size(124, 22);
            this.biRun.Text = "一键发布";
            this.biRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // biView
            // 
            this.biView.Name = "biView";
            this.biView.Size = new System.Drawing.Size(44, 21);
            this.biView.Text = "视图";
            this.biView.Click += new System.EventHandler(this.biView_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 404);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "简易发布";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtWhite;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtRemotePath;
        private System.Windows.Forms.TextBox txtStartup;
        private System.Windows.Forms.TextBox txtReg;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnUpFile;
        private System.Windows.Forms.Button btnUnZip;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Button btnStartup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.DateTimePicker dateInc;
        private System.Windows.Forms.DateTimePicker timeInc;
        private System.Windows.Forms.CheckBox ckInc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem biFile;
        private System.Windows.Forms.ToolStripMenuItem biOpen;
        private System.Windows.Forms.ToolStripMenuItem biSaveAs;
        private System.Windows.Forms.ToolStripMenuItem biServer;
        private System.Windows.Forms.ToolStripMenuItem biConnect;
        private System.Windows.Forms.ToolStripMenuItem biPulish;
        private System.Windows.Forms.ToolStripMenuItem biZipFile;
        private System.Windows.Forms.ToolStripMenuItem biUpFile;
        private System.Windows.Forms.ToolStripMenuItem biUnZipFile;
        private System.Windows.Forms.ToolStripMenuItem biKill;
        private System.Windows.Forms.ToolStripMenuItem biStartup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem biRun;
        private System.Windows.Forms.ToolStripMenuItem biView;
        private System.Windows.Forms.Button btnFtp;
        private System.Windows.Forms.TextBox txtCompileTarget;
        private System.Windows.Forms.TextBox txtCompileSor;
        private System.Windows.Forms.CheckBox ckCompile;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.TextBox txtCompileLib;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartBefor;
    }
}