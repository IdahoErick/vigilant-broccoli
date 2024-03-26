
namespace DIMonitor
{
    partial class ReplicateStatusForm
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
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxTables = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSourceDB = new System.Windows.Forms.ComboBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblMaxDateDiff = new System.Windows.Forms.Label();
            this.lblNbrTables = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMaxRowCountDiff = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbQueryTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckStatus
            // 
            this.btnCheckStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckStatus.Location = new System.Drawing.Point(991, 37);
            this.btnCheckStatus.Name = "btnCheckStatus";
            this.btnCheckStatus.Size = new System.Drawing.Size(117, 23);
            this.btnCheckStatus.TabIndex = 3;
            this.btnCheckStatus.Text = "Check Status";
            this.btnCheckStatus.UseVisualStyleBackColor = true;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnRunDataCompare_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(23, 116);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidth = 51;
            this.dgvResults.RowTemplate.Height = 24;
            this.dgvResults.Size = new System.Drawing.Size(1368, 815);
            this.dgvResults.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Results";
            // 
            // tbMaxTables
            // 
            this.tbMaxTables.Location = new System.Drawing.Point(150, 64);
            this.tbMaxTables.Name = "tbMaxTables";
            this.tbMaxTables.Size = new System.Drawing.Size(71, 22);
            this.tbMaxTables.TabIndex = 19;
            this.tbMaxTables.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Number of Tables";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Consolidated DB";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // cbSourceDB
            // 
            this.cbSourceDB.FormattingEnabled = true;
            this.cbSourceDB.Location = new System.Drawing.Point(142, 19);
            this.cbSourceDB.Name = "cbSourceDB";
            this.cbSourceDB.Size = new System.Drawing.Size(121, 24);
            this.cbSourceDB.TabIndex = 27;
            // 
            // lbl1
            // 
            this.lbl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(522, 948);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(264, 17);
            this.lbl1.TabIndex = 30;
            this.lbl1.Text = "Maximum Modified Date difference (min):";
            // 
            // lblMaxDateDiff
            // 
            this.lblMaxDateDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxDateDiff.AutoSize = true;
            this.lblMaxDateDiff.Location = new System.Drawing.Point(799, 948);
            this.lblMaxDateDiff.Name = "lblMaxDateDiff";
            this.lblMaxDateDiff.Size = new System.Drawing.Size(16, 17);
            this.lblMaxDateDiff.TabIndex = 31;
            this.lblMaxDateDiff.Text = "0";
            // 
            // lblNbrTables
            // 
            this.lblNbrTables.AutoSize = true;
            this.lblNbrTables.Location = new System.Drawing.Point(91, 948);
            this.lblNbrTables.Name = "lblNbrTables";
            this.lblNbrTables.Size = new System.Drawing.Size(16, 17);
            this.lblNbrTables.TabIndex = 33;
            this.lblNbrTables.Text = "0";
            this.lblNbrTables.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 948);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "# tables:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lblMaxRowCountDiff
            // 
            this.lblMaxRowCountDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMaxRowCountDiff.AutoSize = true;
            this.lblMaxRowCountDiff.Location = new System.Drawing.Point(466, 948);
            this.lblMaxRowCountDiff.Name = "lblMaxRowCountDiff";
            this.lblMaxRowCountDiff.Size = new System.Drawing.Size(16, 17);
            this.lblMaxRowCountDiff.TabIndex = 35;
            this.lblMaxRowCountDiff.Text = "0";
            this.lblMaxRowCountDiff.Click += new System.EventHandler(this.label2_Click_2);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 948);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Maximum Row Count difference:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // tbQueryTimeout
            // 
            this.tbQueryTimeout.Location = new System.Drawing.Point(432, 64);
            this.tbQueryTimeout.Name = "tbQueryTimeout";
            this.tbQueryTimeout.Size = new System.Drawing.Size(84, 22);
            this.tbQueryTimeout.TabIndex = 37;
            this.tbQueryTimeout.Text = "1";
            this.tbQueryTimeout.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Query Timeout";
            this.label2.Click += new System.EventHandler(this.label2_Click_3);
            // 
            // ReplicateStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(1418, 1002);
            this.Controls.Add(this.tbQueryTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMaxRowCountDiff);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblNbrTables);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblMaxDateDiff);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.cbSourceDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbMaxTables);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnCheckStatus);
            this.Name = "ReplicateStatusForm";
            this.Text = "Data Compare";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxTables;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSourceDB;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblMaxDateDiff;
        private System.Windows.Forms.Label lblNbrTables;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMaxRowCountDiff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbQueryTimeout;
        private System.Windows.Forms.Label label2;
    }
}
