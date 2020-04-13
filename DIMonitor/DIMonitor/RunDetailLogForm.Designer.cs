namespace DIMonitor
{
    partial class RunDetailLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunDetailLogForm));
            this.dgvRunDetailLog = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.switchOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbErrors = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunDetailLog)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRunDetailLog
            // 
            this.dgvRunDetailLog.AllowUserToAddRows = false;
            this.dgvRunDetailLog.AllowUserToDeleteRows = false;
            this.dgvRunDetailLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRunDetailLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRunDetailLog.Location = new System.Drawing.Point(0, 0);
            this.dgvRunDetailLog.Name = "dgvRunDetailLog";
            this.dgvRunDetailLog.ReadOnly = true;
            this.dgvRunDetailLog.RowTemplate.Height = 24;
            this.dgvRunDetailLog.Size = new System.Drawing.Size(1672, 692);
            this.dgvRunDetailLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 667);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1672, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchOrderToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 23);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // switchOrderToolStripMenuItem
            // 
            this.switchOrderToolStripMenuItem.Name = "switchOrderToolStripMenuItem";
            this.switchOrderToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
            this.switchOrderToolStripMenuItem.Text = "Switch Order";
            this.switchOrderToolStripMenuItem.Click += new System.EventHandler(this.switchOrderToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(143, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel";
            // 
            // cbErrors
            // 
            this.cbErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbErrors.AutoSize = true;
            this.cbErrors.Location = new System.Drawing.Point(576, 667);
            this.cbErrors.Name = "cbErrors";
            this.cbErrors.Size = new System.Drawing.Size(102, 21);
            this.cbErrors.TabIndex = 2;
            this.cbErrors.Text = "Errors Only";
            this.cbErrors.UseVisualStyleBackColor = true;
            this.cbErrors.CheckedChanged += new System.EventHandler(this.cbErrors_CheckedChanged);
            // 
            // RunDetailLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 692);
            this.Controls.Add(this.cbErrors);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvRunDetailLog);
            this.Name = "RunDetailLogForm";
            this.Text = "Run Detail Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRunDetailLog)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRunDetailLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem switchOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox cbErrors;
    }
}