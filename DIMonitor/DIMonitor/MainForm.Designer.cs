﻿namespace DIMonitor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblResult = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbEnvironment = new System.Windows.Forms.ComboBox();
            this.lblKalenderDatum = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.cbBU = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBeginDTM = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEndDTM = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPeilDatum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLastRefreshDTM = new System.Windows.Forms.Label();
            this.lblLastStep = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbOnTop = new System.Windows.Forms.CheckBox();
            this.lblControleType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPackage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDetailDTM = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRunDetails = new System.Windows.Forms.Button();
            this.btnTroubleshooting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLocalAdminPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StagingLogboekMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runDetailLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sSISLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblBronsysteem = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblOpmerkingen = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLatestSSISMessage = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSSISRunID = new System.Windows.Forms.Label();
            this.btnSSISRefresh = new System.Windows.Forms.Button();
            this.filesWaitingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Location = new System.Drawing.Point(53, 105);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(50, 19);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Result";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(360, 443);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbEnvironment
            // 
            this.cbEnvironment.FormattingEnabled = true;
            this.cbEnvironment.Items.AddRange(new object[] {
            "LOCAL",
            "DEV",
            "TEST",
            "ACC",
            "PROD"});
            this.cbEnvironment.Location = new System.Drawing.Point(45, 44);
            this.cbEnvironment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEnvironment.Name = "cbEnvironment";
            this.cbEnvironment.Size = new System.Drawing.Size(132, 24);
            this.cbEnvironment.TabIndex = 2;
            this.cbEnvironment.SelectedIndexChanged += new System.EventHandler(this.cbEnvironment_SelectedIndexChanged);
            // 
            // lblKalenderDatum
            // 
            this.lblKalenderDatum.AutoSize = true;
            this.lblKalenderDatum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKalenderDatum.Location = new System.Drawing.Point(131, 106);
            this.lblKalenderDatum.Name = "lblKalenderDatum";
            this.lblKalenderDatum.Size = new System.Drawing.Size(2, 19);
            this.lblKalenderDatum.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbPeriod
            // 
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Items.AddRange(new object[] {
            "DAG",
            "MAAND"});
            this.cbPeriod.Location = new System.Drawing.Point(203, 44);
            this.cbPeriod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(121, 24);
            this.cbPeriod.TabIndex = 4;
            this.cbPeriod.SelectedIndexChanged += new System.EventHandler(this.cbPeriod_SelectedIndexChanged);
            // 
            // cbBU
            // 
            this.cbBU.FormattingEnabled = true;
            this.cbBU.Items.AddRange(new object[] {
            "ILVB",
            "ILVV"});
            this.cbBU.Location = new System.Drawing.Point(353, 44);
            this.cbBU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbBU.Name = "cbBU";
            this.cbBU.Size = new System.Drawing.Size(121, 24);
            this.cbBU.TabIndex = 5;
            this.cbBU.SelectedIndexChanged += new System.EventHandler(this.cbBU_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "KalenderDatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "BeginDTM";
            // 
            // lblBeginDTM
            // 
            this.lblBeginDTM.AutoSize = true;
            this.lblBeginDTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeginDTM.Location = new System.Drawing.Point(131, 165);
            this.lblBeginDTM.Name = "lblBeginDTM";
            this.lblBeginDTM.Size = new System.Drawing.Size(2, 19);
            this.lblBeginDTM.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(279, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "EndDTM";
            // 
            // lblEndDTM
            // 
            this.lblEndDTM.AutoSize = true;
            this.lblEndDTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndDTM.Location = new System.Drawing.Point(283, 165);
            this.lblEndDTM.Name = "lblEndDTM";
            this.lblEndDTM.Size = new System.Drawing.Size(2, 19);
            this.lblEndDTM.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "PeilDatum";
            // 
            // lblPeilDatum
            // 
            this.lblPeilDatum.AutoSize = true;
            this.lblPeilDatum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeilDatum.Location = new System.Drawing.Point(283, 106);
            this.lblPeilDatum.Name = "lblPeilDatum";
            this.lblPeilDatum.Size = new System.Drawing.Size(2, 19);
            this.lblPeilDatum.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Last Refresh:";
            // 
            // lblLastRefreshDTM
            // 
            this.lblLastRefreshDTM.AutoSize = true;
            this.lblLastRefreshDTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastRefreshDTM.Location = new System.Drawing.Point(148, 401);
            this.lblLastRefreshDTM.Name = "lblLastRefreshDTM";
            this.lblLastRefreshDTM.Size = new System.Drawing.Size(2, 19);
            this.lblLastRefreshDTM.TabIndex = 15;
            // 
            // lblLastStep
            // 
            this.lblLastStep.AutoSize = true;
            this.lblLastStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLastStep.Location = new System.Drawing.Point(159, 206);
            this.lblLastStep.Name = "lblLastStep";
            this.lblLastStep.Size = new System.Drawing.Size(2, 19);
            this.lblLastStep.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Last Step:";
            // 
            // cbOnTop
            // 
            this.cbOnTop.AutoSize = true;
            this.cbOnTop.Location = new System.Drawing.Point(453, 401);
            this.cbOnTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOnTop.Name = "cbOnTop";
            this.cbOnTop.Size = new System.Drawing.Size(18, 17);
            this.cbOnTop.TabIndex = 18;
            this.cbOnTop.UseVisualStyleBackColor = true;
            this.cbOnTop.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblControleType
            // 
            this.lblControleType.AutoSize = true;
            this.lblControleType.Location = new System.Drawing.Point(126, 1);
            this.lblControleType.Name = "lblControleType";
            this.lblControleType.Size = new System.Drawing.Size(0, 17);
            this.lblControleType.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Controletype:";
            // 
            // lblPackage
            // 
            this.lblPackage.AutoSize = true;
            this.lblPackage.Location = new System.Drawing.Point(126, 22);
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Size = new System.Drawing.Size(0, 17);
            this.lblPackage.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Package:";
            // 
            // lblDetailDTM
            // 
            this.lblDetailDTM.AutoSize = true;
            this.lblDetailDTM.Location = new System.Drawing.Point(126, 43);
            this.lblDetailDTM.Name = "lblDetailDTM";
            this.lblDetailDTM.Size = new System.Drawing.Size(0, 17);
            this.lblDetailDTM.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 26;
            this.label12.Text = "Detail DTM:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 71);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // btnRunDetails
            // 
            this.btnRunDetails.Location = new System.Drawing.Point(39, 442);
            this.btnRunDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRunDetails.Name = "btnRunDetails";
            this.btnRunDetails.Size = new System.Drawing.Size(145, 31);
            this.btnRunDetails.TabIndex = 29;
            this.btnRunDetails.Text = "Run Details";
            this.btnRunDetails.UseVisualStyleBackColor = true;
            this.btnRunDetails.Click += new System.EventHandler(this.btnRunDetails_Click);
            // 
            // btnTroubleshooting
            // 
            this.btnTroubleshooting.Location = new System.Drawing.Point(216, 442);
            this.btnTroubleshooting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTroubleshooting.Name = "btnTroubleshooting";
            this.btnTroubleshooting.Size = new System.Drawing.Size(121, 31);
            this.btnTroubleshooting.TabIndex = 30;
            this.btnTroubleshooting.Text = "Troubleshooting";
            this.btnTroubleshooting.UseVisualStyleBackColor = true;
            this.btnTroubleshooting.Click += new System.EventHandler(this.btnTroubleshooting_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(17, 477);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(463, 100);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.logsToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.transferDataToolStripMenuItem,
            this.filesWaitingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(590, 28);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.setLocalAdminPasswordToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(251, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // setLocalAdminPasswordToolStripMenuItem
            // 
            this.setLocalAdminPasswordToolStripMenuItem.Name = "setLocalAdminPasswordToolStripMenuItem";
            this.setLocalAdminPasswordToolStripMenuItem.Size = new System.Drawing.Size(251, 24);
            this.setLocalAdminPasswordToolStripMenuItem.Text = "Set Local Admin Password";
            this.setLocalAdminPasswordToolStripMenuItem.Click += new System.EventHandler(this.setLocalAdminPasswordToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StagingLogboekMenuItem,
            this.runDetailLogToolStripMenuItem1,
            this.sSISLogToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.logsToolStripMenuItem.Text = "Logs";
            // 
            // StagingLogboekMenuItem
            // 
            this.StagingLogboekMenuItem.Name = "StagingLogboekMenuItem";
            this.StagingLogboekMenuItem.Size = new System.Drawing.Size(191, 24);
            this.StagingLogboekMenuItem.Text = "Staging LogBoek";
            this.StagingLogboekMenuItem.Click += new System.EventHandler(this.logBoekToolStripMenuItem1_Click);
            // 
            // runDetailLogToolStripMenuItem1
            // 
            this.runDetailLogToolStripMenuItem1.Name = "runDetailLogToolStripMenuItem1";
            this.runDetailLogToolStripMenuItem1.Size = new System.Drawing.Size(191, 24);
            this.runDetailLogToolStripMenuItem1.Text = "Run Detail Log";
            this.runDetailLogToolStripMenuItem1.Click += new System.EventHandler(this.runDetailLogToolStripMenuItem1_Click);
            // 
            // sSISLogToolStripMenuItem
            // 
            this.sSISLogToolStripMenuItem.Name = "sSISLogToolStripMenuItem";
            this.sSISLogToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.sSISLogToolStripMenuItem.Text = "SSIS Log";
            this.sSISLogToolStripMenuItem.Click += new System.EventHandler(this.sSISLogToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // transferDataToolStripMenuItem
            // 
            this.transferDataToolStripMenuItem.Name = "transferDataToolStripMenuItem";
            this.transferDataToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.transferDataToolStripMenuItem.Text = "Transfer Data";
            this.transferDataToolStripMenuItem.Click += new System.EventHandler(this.transferDataToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Keep on Top";
            // 
            // ssStatusStrip
            // 
            this.ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel});
            this.ssStatusStrip.Location = new System.Drawing.Point(0, 642);
            this.ssStatusStrip.Name = "ssStatusStrip";
            this.ssStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssStatusStrip.Size = new System.Drawing.Size(590, 25);
            this.ssStatusStrip.TabIndex = 35;
            this.ssStatusStrip.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(96, 20);
            this.tssLabel.Text = "Lekker Bezig!";
            // 
            // lblBronsysteem
            // 
            this.lblBronsysteem.AutoSize = true;
            this.lblBronsysteem.Location = new System.Drawing.Point(126, 85);
            this.lblBronsysteem.Name = "lblBronsysteem";
            this.lblBronsysteem.Size = new System.Drawing.Size(0, 17);
            this.lblBronsysteem.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "Bronsysteem:";
            // 
            // lblOpmerkingen
            // 
            this.lblOpmerkingen.AutoSize = true;
            this.lblOpmerkingen.Location = new System.Drawing.Point(126, 64);
            this.lblOpmerkingen.Name = "lblOpmerkingen";
            this.lblOpmerkingen.Size = new System.Drawing.Size(0, 17);
            this.lblOpmerkingen.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 17);
            this.label15.TabIndex = 38;
            this.label15.Text = "Opmerkingen:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.6644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.3356F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBronsysteem, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblOpmerkingen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblControleType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPackage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDetailDTM, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLatestSSISMessage, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(39, 249);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 129);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 17);
            this.label14.TabIndex = 40;
            this.label14.Text = "SSIS Message:";
            // 
            // lblLatestSSISMessage
            // 
            this.lblLatestSSISMessage.AutoSize = true;
            this.lblLatestSSISMessage.Location = new System.Drawing.Point(126, 106);
            this.lblLatestSSISMessage.Name = "lblLatestSSISMessage";
            this.lblLatestSSISMessage.Size = new System.Drawing.Size(0, 17);
            this.lblLatestSSISMessage.TabIndex = 41;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(387, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 17);
            this.label11.TabIndex = 41;
            this.label11.Text = "SSIS Run ID";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // lblSSISRunID
            // 
            this.lblSSISRunID.AutoSize = true;
            this.lblSSISRunID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSSISRunID.Location = new System.Drawing.Point(390, 106);
            this.lblSSISRunID.Name = "lblSSISRunID";
            this.lblSSISRunID.Size = new System.Drawing.Size(2, 19);
            this.lblSSISRunID.TabIndex = 42;
            // 
            // btnSSISRefresh
            // 
            this.btnSSISRefresh.Location = new System.Drawing.Point(486, 355);
            this.btnSSISRefresh.Name = "btnSSISRefresh";
            this.btnSSISRefresh.Size = new System.Drawing.Size(30, 23);
            this.btnSSISRefresh.TabIndex = 43;
            this.btnSSISRefresh.Text = "R";
            this.btnSSISRefresh.UseVisualStyleBackColor = true;
            this.btnSSISRefresh.Click += new System.EventHandler(this.btnSSISRefresh_Click);
            // 
            // filesWaitingToolStripMenuItem
            // 
            this.filesWaitingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceFilesToolStripMenuItem});
            this.filesWaitingToolStripMenuItem.Name = "filesWaitingToolStripMenuItem";
            this.filesWaitingToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.filesWaitingToolStripMenuItem.Text = "Files";
            // 
            // sourceFilesToolStripMenuItem
            // 
            this.sourceFilesToolStripMenuItem.Name = "sourceFilesToolStripMenuItem";
            this.sourceFilesToolStripMenuItem.Size = new System.Drawing.Size(156, 24);
            this.sourceFilesToolStripMenuItem.Text = "Source Files";
            this.sourceFilesToolStripMenuItem.Click += new System.EventHandler(this.sourceFilesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 667);
            this.Controls.Add(this.btnSSISRefresh);
            this.Controls.Add(this.lblSSISRunID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ssStatusStrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTroubleshooting);
            this.Controls.Add(this.btnRunDetails);
            this.Controls.Add(this.cbOnTop);
            this.Controls.Add(this.lblLastStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblLastRefreshDTM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPeilDatum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEndDTM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBeginDTM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbBU);
            this.Controls.Add(this.cbPeriod);
            this.Controls.Add(this.lblKalenderDatum);
            this.Controls.Add(this.cbEnvironment);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "DI Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbEnvironment;
        private System.Windows.Forms.Label lblKalenderDatum;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.ComboBox cbBU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBeginDTM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEndDTM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPeilDatum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLastRefreshDTM;
        private System.Windows.Forms.Label lblLastStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbOnTop;
        private System.Windows.Forms.Label lblControleType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblDetailDTM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRunDetails;
        private System.Windows.Forms.Button btnTroubleshooting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem setLocalAdminPasswordToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.Label lblBronsysteem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblOpmerkingen;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem transferDataToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSSISRunID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLatestSSISMessage;
        private System.Windows.Forms.Button btnSSISRefresh;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StagingLogboekMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runDetailLogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sSISLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesWaitingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceFilesToolStripMenuItem;
    }
}
