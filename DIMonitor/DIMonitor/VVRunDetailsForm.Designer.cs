namespace DIMonitor
{
    partial class VVRunDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnvironment = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblBU = new System.Windows.Forms.Label();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPeilDatum = new System.Windows.Forms.Label();
            this.cbMaakCF = new System.Windows.Forms.CheckBox();
            this.cbLaadDDSDWH = new System.Windows.Forms.CheckBox();
            this.cbLaadDDS = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbCalendarDates = new System.Windows.Forms.ComboBox();
            this.btnAbortRun = new System.Windows.Forms.Button();
            this.cbLaadStaging = new System.Windows.Forms.CheckBox();
            this.cbLegenStaging = new System.Windows.Forms.CheckBox();
            this.cbLaadEPMidas = new System.Windows.Forms.CheckBox();
            this.cbLaadOFSMidas = new System.Windows.Forms.CheckBox();
            this.cbLaadEPNN = new System.Windows.Forms.CheckBox();
            this.cbLaadOFS = new System.Windows.Forms.CheckBox();
            this.cbLaadIKV = new System.Windows.Forms.CheckBox();
            this.cbDoelOFSKlantdata = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbLegenDDS = new System.Windows.Forms.CheckBox();
            this.tbDistributieLijst = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Omgeving:";
            // 
            // lblEnvironment
            // 
            this.lblEnvironment.AutoSize = true;
            this.lblEnvironment.Location = new System.Drawing.Point(119, 37);
            this.lblEnvironment.Name = "lblEnvironment";
            this.lblEnvironment.Size = new System.Drawing.Size(24, 17);
            this.lblEnvironment.TabIndex = 24;
            this.lblEnvironment.Text = "<>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPeriod);
            this.groupBox1.Controls.Add(this.lblBU);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblEnvironment);
            this.groupBox1.Location = new System.Drawing.Point(39, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(373, 75);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(249, 37);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(48, 17);
            this.lblPeriod.TabIndex = 26;
            this.lblPeriod.Text = "period";
            // 
            // lblBU
            // 
            this.lblBU.AutoSize = true;
            this.lblBU.Location = new System.Drawing.Point(176, 37);
            this.lblBU.Name = "lblBU";
            this.lblBU.Size = new System.Drawing.Size(24, 17);
            this.lblBU.TabIndex = 25;
            this.lblBU.Text = "bu";
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.Location = new System.Drawing.Point(610, 110);
            this.btnGenerateScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(124, 36);
            this.btnGenerateScript.TabIndex = 26;
            this.btnGenerateScript.Text = "Generate Script";
            this.btnGenerateScript.UseVisualStyleBackColor = true;
            this.btnGenerateScript.Click += new System.EventHandler(this.btnGenerateScript_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(610, 164);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(124, 30);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Kalenderdatum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Peildatum";
            // 
            // lblPeilDatum
            // 
            this.lblPeilDatum.AutoSize = true;
            this.lblPeilDatum.Location = new System.Drawing.Point(424, 114);
            this.lblPeilDatum.Name = "lblPeilDatum";
            this.lblPeilDatum.Size = new System.Drawing.Size(69, 17);
            this.lblPeilDatum.TabIndex = 32;
            this.lblPeilDatum.Text = "peildatum";
            // 
            // cbMaakCF
            // 
            this.cbMaakCF.AutoSize = true;
            this.cbMaakCF.Location = new System.Drawing.Point(398, 252);
            this.cbMaakCF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbMaakCF.Name = "cbMaakCF";
            this.cbMaakCF.Size = new System.Drawing.Size(85, 21);
            this.cbMaakCF.TabIndex = 52;
            this.cbMaakCF.Text = "Maak CF";
            this.cbMaakCF.UseVisualStyleBackColor = true;
            // 
            // cbLaadDDSDWH
            // 
            this.cbLaadDDSDWH.AutoSize = true;
            this.cbLaadDDSDWH.Location = new System.Drawing.Point(398, 218);
            this.cbLaadDDSDWH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadDDSDWH.Name = "cbLaadDDSDWH";
            this.cbLaadDDSDWH.Size = new System.Drawing.Size(132, 21);
            this.cbLaadDDSDWH.TabIndex = 51;
            this.cbLaadDDSDWH.Text = "Laad DDS DWH";
            this.cbLaadDDSDWH.UseVisualStyleBackColor = true;
            // 
            // cbLaadDDS
            // 
            this.cbLaadDDS.AutoSize = true;
            this.cbLaadDDS.Location = new System.Drawing.Point(398, 185);
            this.cbLaadDDS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadDDS.Name = "cbLaadDDS";
            this.cbLaadDDS.Size = new System.Drawing.Size(95, 21);
            this.cbLaadDDS.TabIndex = 50;
            this.cbLaadDDS.Text = "Laad DDS";
            this.cbLaadDDS.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(339, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 17);
            this.label4.TabIndex = 55;
            this.label4.Text = "CF Distributielijst:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(611, 308);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 36);
            this.btnClose.TabIndex = 57;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(610, 212);
            this.btnStartRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(124, 30);
            this.btnStartRun.TabIndex = 58;
            this.btnStartRun.Text = "Start Run";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 59;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cbCalendarDates
            // 
            this.cbCalendarDates.FormattingEnabled = true;
            this.cbCalendarDates.Location = new System.Drawing.Point(161, 110);
            this.cbCalendarDates.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCalendarDates.Name = "cbCalendarDates";
            this.cbCalendarDates.Size = new System.Drawing.Size(105, 24);
            this.cbCalendarDates.TabIndex = 60;
            this.cbCalendarDates.SelectedIndexChanged += new System.EventHandler(this.cbCalendarDates_SelectedIndexChanged);
            // 
            // btnAbortRun
            // 
            this.btnAbortRun.Location = new System.Drawing.Point(610, 260);
            this.btnAbortRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAbortRun.Name = "btnAbortRun";
            this.btnAbortRun.Size = new System.Drawing.Size(124, 30);
            this.btnAbortRun.TabIndex = 61;
            this.btnAbortRun.Text = "Abort Run";
            this.btnAbortRun.UseVisualStyleBackColor = true;
            this.btnAbortRun.Click += new System.EventHandler(this.btnAbortRun_Click);
            // 
            // cbLaadStaging
            // 
            this.cbLaadStaging.AutoSize = true;
            this.cbLaadStaging.Location = new System.Drawing.Point(7, 62);
            this.cbLaadStaging.Margin = new System.Windows.Forms.Padding(4);
            this.cbLaadStaging.Name = "cbLaadStaging";
            this.cbLaadStaging.Size = new System.Drawing.Size(114, 21);
            this.cbLaadStaging.TabIndex = 22;
            this.cbLaadStaging.Text = "Laad Staging";
            this.cbLaadStaging.UseVisualStyleBackColor = true;
            // 
            // cbLegenStaging
            // 
            this.cbLegenStaging.AutoSize = true;
            this.cbLegenStaging.Location = new System.Drawing.Point(7, 32);
            this.cbLegenStaging.Margin = new System.Windows.Forms.Padding(4);
            this.cbLegenStaging.Name = "cbLegenStaging";
            this.cbLegenStaging.Size = new System.Drawing.Size(122, 21);
            this.cbLegenStaging.TabIndex = 21;
            this.cbLegenStaging.Text = "Legen Staging";
            this.cbLegenStaging.UseVisualStyleBackColor = true;
            // 
            // cbLaadEPMidas
            // 
            this.cbLaadEPMidas.AutoSize = true;
            this.cbLaadEPMidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLaadEPMidas.Location = new System.Drawing.Point(7, 100);
            this.cbLaadEPMidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadEPMidas.Name = "cbLaadEPMidas";
            this.cbLaadEPMidas.Size = new System.Drawing.Size(125, 21);
            this.cbLaadEPMidas.TabIndex = 23;
            this.cbLaadEPMidas.Text = "Laad EP Midas";
            this.cbLaadEPMidas.UseVisualStyleBackColor = true;
            // 
            // cbLaadOFSMidas
            // 
            this.cbLaadOFSMidas.AutoSize = true;
            this.cbLaadOFSMidas.Location = new System.Drawing.Point(7, 128);
            this.cbLaadOFSMidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadOFSMidas.Name = "cbLaadOFSMidas";
            this.cbLaadOFSMidas.Size = new System.Drawing.Size(135, 21);
            this.cbLaadOFSMidas.TabIndex = 24;
            this.cbLaadOFSMidas.Text = "Laad OFS Midas";
            this.cbLaadOFSMidas.UseVisualStyleBackColor = true;
            // 
            // cbLaadEPNN
            // 
            this.cbLaadEPNN.AutoSize = true;
            this.cbLaadEPNN.Location = new System.Drawing.Point(7, 155);
            this.cbLaadEPNN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadEPNN.Name = "cbLaadEPNN";
            this.cbLaadEPNN.Size = new System.Drawing.Size(108, 21);
            this.cbLaadEPNN.TabIndex = 25;
            this.cbLaadEPNN.Text = "Laad EP NN";
            this.cbLaadEPNN.UseVisualStyleBackColor = true;
            // 
            // cbLaadOFS
            // 
            this.cbLaadOFS.AutoSize = true;
            this.cbLaadOFS.Location = new System.Drawing.Point(7, 199);
            this.cbLaadOFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadOFS.Name = "cbLaadOFS";
            this.cbLaadOFS.Size = new System.Drawing.Size(94, 21);
            this.cbLaadOFS.TabIndex = 26;
            this.cbLaadOFS.Text = "Laad OFS";
            this.cbLaadOFS.UseVisualStyleBackColor = true;
            // 
            // cbLaadIKV
            // 
            this.cbLaadIKV.AutoSize = true;
            this.cbLaadIKV.Location = new System.Drawing.Point(7, 226);
            this.cbLaadIKV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLaadIKV.Name = "cbLaadIKV";
            this.cbLaadIKV.Size = new System.Drawing.Size(87, 21);
            this.cbLaadIKV.TabIndex = 27;
            this.cbLaadIKV.Text = "Laad IKV";
            this.cbLaadIKV.UseVisualStyleBackColor = true;
            // 
            // cbDoelOFSKlantdata
            // 
            this.cbDoelOFSKlantdata.AutoSize = true;
            this.cbDoelOFSKlantdata.Location = new System.Drawing.Point(7, 254);
            this.cbDoelOFSKlantdata.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDoelOFSKlantdata.Name = "cbDoelOFSKlantdata";
            this.cbDoelOFSKlantdata.Size = new System.Drawing.Size(157, 21);
            this.cbDoelOFSKlantdata.TabIndex = 28;
            this.cbDoelOFSKlantdata.Text = "Doel OFS KlantData";
            this.cbDoelOFSKlantdata.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbDoelOFSKlantdata);
            this.groupBox2.Controls.Add(this.cbLaadIKV);
            this.groupBox2.Controls.Add(this.cbLaadOFS);
            this.groupBox2.Controls.Add(this.cbLaadEPNN);
            this.groupBox2.Controls.Add(this.cbLaadOFSMidas);
            this.groupBox2.Controls.Add(this.cbLaadEPMidas);
            this.groupBox2.Controls.Add(this.cbLegenStaging);
            this.groupBox2.Controls.Add(this.cbLaadStaging);
            this.groupBox2.Location = new System.Drawing.Point(39, 150);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(283, 287);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bronnen";
            // 
            // cbLegenDDS
            // 
            this.cbLegenDDS.AutoSize = true;
            this.cbLegenDDS.Location = new System.Drawing.Point(398, 150);
            this.cbLegenDDS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbLegenDDS.Name = "cbLegenDDS";
            this.cbLegenDDS.Size = new System.Drawing.Size(103, 21);
            this.cbLegenDDS.TabIndex = 62;
            this.cbLegenDDS.Text = "Legen DDS";
            this.cbLegenDDS.UseVisualStyleBackColor = true;
            // 
            // tbDistributieLijst
            // 
            this.tbDistributieLijst.Location = new System.Drawing.Point(483, 404);
            this.tbDistributieLijst.Multiline = true;
            this.tbDistributieLijst.Name = "tbDistributieLijst";
            this.tbDistributieLijst.Size = new System.Drawing.Size(252, 39);
            this.tbDistributieLijst.TabIndex = 63;
            // 
            // VVRunDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 481);
            this.Controls.Add(this.tbDistributieLijst);
            this.Controls.Add(this.cbLegenDDS);
            this.Controls.Add(this.btnAbortRun);
            this.Controls.Add(this.cbCalendarDates);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStartRun);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPeilDatum);
            this.Controls.Add(this.cbMaakCF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLaadDDSDWH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbLaadDDS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnGenerateScript);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VVRunDetailsForm";
            this.Text = "RunDetails";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnvironment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBU;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPeilDatum;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.CheckBox cbMaakCF;
        private System.Windows.Forms.CheckBox cbLaadDDSDWH;
        private System.Windows.Forms.CheckBox cbLaadDDS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cbCalendarDates;
        private System.Windows.Forms.Button btnAbortRun;
        private System.Windows.Forms.CheckBox cbLaadStaging;
        private System.Windows.Forms.CheckBox cbLegenStaging;
        private System.Windows.Forms.CheckBox cbLaadEPMidas;
        private System.Windows.Forms.CheckBox cbLaadOFSMidas;
        private System.Windows.Forms.CheckBox cbLaadEPNN;
        private System.Windows.Forms.CheckBox cbLaadOFS;
        private System.Windows.Forms.CheckBox cbLaadIKV;
        private System.Windows.Forms.CheckBox cbDoelOFSKlantdata;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbLegenDDS;
        private System.Windows.Forms.TextBox tbDistributieLijst;
    }
}