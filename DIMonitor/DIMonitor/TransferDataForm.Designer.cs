namespace DIMonitor
{
    partial class TransferDataForm
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
            this.btnRunBcp = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbTransferBatchFile = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunBcp
            // 
            this.btnRunBcp.Location = new System.Drawing.Point(42, 107);
            this.btnRunBcp.Name = "btnRunBcp";
            this.btnRunBcp.Size = new System.Drawing.Size(219, 36);
            this.btnRunBcp.TabIndex = 0;
            this.btnRunBcp.Text = "Transfer Data";
            this.btnRunBcp.UseVisualStyleBackColor = true;
            this.btnRunBcp.Click += new System.EventHandler(this.btnRunBcp_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(324, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(96, 20);
            this.tssLabel.Text = "Lekker Bezig!";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // cbTransferBatchFile
            // 
            this.cbTransferBatchFile.FormattingEnabled = true;
            this.cbTransferBatchFile.Location = new System.Drawing.Point(42, 46);
            this.cbTransferBatchFile.Name = "cbTransferBatchFile";
            this.cbTransferBatchFile.Size = new System.Drawing.Size(219, 24);
            this.cbTransferBatchFile.TabIndex = 3;
            // 
            // TransferDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 260);
            this.Controls.Add(this.cbTransferBatchFile);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRunBcp);
            this.Name = "TransferDataForm";
            this.Text = "Transfer Data";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunBcp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbTransferBatchFile;
    }
}