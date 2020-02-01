namespace DIMonitor
{
    partial class SourceFilesForm
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
            this.dgvSourceFiles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSourceFiles
            // 
            this.dgvSourceFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSourceFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSourceFiles.Location = new System.Drawing.Point(31, 33);
            this.dgvSourceFiles.Name = "dgvSourceFiles";
            this.dgvSourceFiles.RowTemplate.Height = 24;
            this.dgvSourceFiles.Size = new System.Drawing.Size(810, 656);
            this.dgvSourceFiles.TabIndex = 0;
            // 
            // SourceFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 712);
            this.Controls.Add(this.dgvSourceFiles);
            this.Name = "SourceFilesForm";
            this.Text = "Source Files";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSourceFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSourceFiles;
    }
}