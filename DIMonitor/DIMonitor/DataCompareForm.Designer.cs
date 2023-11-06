
namespace DIMonitor
{
    partial class DataCompareForm
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
            this.cbCheckInserts = new System.Windows.Forms.CheckBox();
            this.btnRunDataCompare = new System.Windows.Forms.Button();
            this.dgvDataCompareResultsSummary = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDataCompareResultsPerTable = new System.Windows.Forms.DataGridView();
            this.lblSchemaName = new System.Windows.Forms.Label();
            this.tbSchemaName = new System.Windows.Forms.TextBox();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtmpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtmpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cbCheckUpdates = new System.Windows.Forms.CheckBox();
            this.cbCheckDeletes = new System.Windows.Forms.CheckBox();
            this.tbMaxTableRows = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbShowDifferences = new System.Windows.Forms.CheckBox();
            this.lblRowLevelDataDifferences = new System.Windows.Forms.Label();
            this.dgvRowLevelDataDifferences = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCompareResultsSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCompareResultsPerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowLevelDataDifferences)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCheckInserts
            // 
            this.cbCheckInserts.AutoSize = true;
            this.cbCheckInserts.Checked = true;
            this.cbCheckInserts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCheckInserts.Location = new System.Drawing.Point(725, 48);
            this.cbCheckInserts.Name = "cbCheckInserts";
            this.cbCheckInserts.Size = new System.Drawing.Size(94, 17);
            this.cbCheckInserts.TabIndex = 2;
            this.cbCheckInserts.Text = "Check Inserts";
            this.cbCheckInserts.UseVisualStyleBackColor = true;
            // 
            // btnRunDataCompare
            // 
            this.btnRunDataCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunDataCompare.Location = new System.Drawing.Point(707, 507);
            this.btnRunDataCompare.Name = "btnRunDataCompare";
            this.btnRunDataCompare.Size = new System.Drawing.Size(117, 23);
            this.btnRunDataCompare.TabIndex = 3;
            this.btnRunDataCompare.Text = "Run Data Compare";
            this.btnRunDataCompare.UseVisualStyleBackColor = true;
            this.btnRunDataCompare.Click += new System.EventHandler(this.btnRunDataCompare_Click);
            // 
            // dgvDataCompareResultsSummary
            // 
            this.dgvDataCompareResultsSummary.AllowUserToAddRows = false;
            this.dgvDataCompareResultsSummary.AllowUserToDeleteRows = false;
            this.dgvDataCompareResultsSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataCompareResultsSummary.Location = new System.Drawing.Point(23, 116);
            this.dgvDataCompareResultsSummary.Name = "dgvDataCompareResultsSummary";
            this.dgvDataCompareResultsSummary.ReadOnly = true;
            this.dgvDataCompareResultsSummary.RowHeadersWidth = 51;
            this.dgvDataCompareResultsSummary.RowTemplate.Height = 24;
            this.dgvDataCompareResultsSummary.Size = new System.Drawing.Size(796, 79);
            this.dgvDataCompareResultsSummary.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Compare Summary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Data Compare Results per Table";
            // 
            // dgvDataCompareResultsPerTable
            // 
            this.dgvDataCompareResultsPerTable.AllowUserToAddRows = false;
            this.dgvDataCompareResultsPerTable.AllowUserToDeleteRows = false;
            this.dgvDataCompareResultsPerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataCompareResultsPerTable.Location = new System.Drawing.Point(26, 242);
            this.dgvDataCompareResultsPerTable.Name = "dgvDataCompareResultsPerTable";
            this.dgvDataCompareResultsPerTable.ReadOnly = true;
            this.dgvDataCompareResultsPerTable.RowHeadersWidth = 51;
            this.dgvDataCompareResultsPerTable.RowTemplate.Height = 24;
            this.dgvDataCompareResultsPerTable.Size = new System.Drawing.Size(793, 249);
            this.dgvDataCompareResultsPerTable.TabIndex = 6;
            // 
            // lblSchemaName
            // 
            this.lblSchemaName.AutoSize = true;
            this.lblSchemaName.Location = new System.Drawing.Point(27, 31);
            this.lblSchemaName.Name = "lblSchemaName";
            this.lblSchemaName.Size = new System.Drawing.Size(77, 13);
            this.lblSchemaName.TabIndex = 8;
            this.lblSchemaName.Text = "Schema Name";
            // 
            // tbSchemaName
            // 
            this.tbSchemaName.Location = new System.Drawing.Point(30, 48);
            this.tbSchemaName.Name = "tbSchemaName";
            this.tbSchemaName.Size = new System.Drawing.Size(134, 22);
            this.tbSchemaName.TabIndex = 9;
            this.tbSchemaName.Text = "<ALL>";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(175, 49);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(134, 22);
            this.tbTableName.TabIndex = 11;
            this.tbTableName.Text = "<ALL>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table Name";
            // 
            // dtmpStartDate
            // 
            this.dtmpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmpStartDate.Location = new System.Drawing.Point(321, 49);
            this.dtmpStartDate.Name = "dtmpStartDate";
            this.dtmpStartDate.Size = new System.Drawing.Size(110, 22);
            this.dtmpStartDate.TabIndex = 12;
            this.dtmpStartDate.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "End Date";
            // 
            // dtmpEndDate
            // 
            this.dtmpEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtmpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmpEndDate.Location = new System.Drawing.Point(444, 49);
            this.dtmpEndDate.Name = "dtmpEndDate";
            this.dtmpEndDate.Size = new System.Drawing.Size(114, 22);
            this.dtmpEndDate.TabIndex = 14;
            this.dtmpEndDate.Value = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // cbCheckUpdates
            // 
            this.cbCheckUpdates.AutoSize = true;
            this.cbCheckUpdates.Checked = true;
            this.cbCheckUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCheckUpdates.Location = new System.Drawing.Point(725, 71);
            this.cbCheckUpdates.Name = "cbCheckUpdates";
            this.cbCheckUpdates.Size = new System.Drawing.Size(103, 17);
            this.cbCheckUpdates.TabIndex = 16;
            this.cbCheckUpdates.Text = "Check Updates";
            this.cbCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // cbCheckDeletes
            // 
            this.cbCheckDeletes.AutoSize = true;
            this.cbCheckDeletes.Checked = true;
            this.cbCheckDeletes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCheckDeletes.Location = new System.Drawing.Point(725, 93);
            this.cbCheckDeletes.Name = "cbCheckDeletes";
            this.cbCheckDeletes.Size = new System.Drawing.Size(99, 17);
            this.cbCheckDeletes.TabIndex = 17;
            this.cbCheckDeletes.Text = "Check Deletes";
            this.cbCheckDeletes.UseVisualStyleBackColor = true;
            // 
            // tbMaxTableRows
            // 
            this.tbMaxTableRows.Location = new System.Drawing.Point(571, 48);
            this.tbMaxTableRows.Name = "tbMaxTableRows";
            this.tbMaxTableRows.Size = new System.Drawing.Size(134, 22);
            this.tbMaxTableRows.TabIndex = 19;
            this.tbMaxTableRows.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Max Table Rows";
            // 
            // cbShowDifferences
            // 
            this.cbShowDifferences.AutoSize = true;
            this.cbShowDifferences.Location = new System.Drawing.Point(725, 25);
            this.cbShowDifferences.Name = "cbShowDifferences";
            this.cbShowDifferences.Size = new System.Drawing.Size(113, 17);
            this.cbShowDifferences.TabIndex = 20;
            this.cbShowDifferences.Text = "Show Differences";
            this.cbShowDifferences.UseVisualStyleBackColor = true;
            // 
            // lblRowLevelDataDifferences
            // 
            this.lblRowLevelDataDifferences.AutoSize = true;
            this.lblRowLevelDataDifferences.Location = new System.Drawing.Point(23, 516);
            this.lblRowLevelDataDifferences.Name = "lblRowLevelDataDifferences";
            this.lblRowLevelDataDifferences.Size = new System.Drawing.Size(162, 13);
            this.lblRowLevelDataDifferences.TabIndex = 22;
            this.lblRowLevelDataDifferences.Text = "Data Compare Results first Table";
            this.lblRowLevelDataDifferences.Visible = false;
            // 
            // dgvRowLevelDataDifferences
            // 
            this.dgvRowLevelDataDifferences.AllowUserToAddRows = false;
            this.dgvRowLevelDataDifferences.AllowUserToDeleteRows = false;
            this.dgvRowLevelDataDifferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRowLevelDataDifferences.Location = new System.Drawing.Point(23, 532);
            this.dgvRowLevelDataDifferences.Name = "dgvRowLevelDataDifferences";
            this.dgvRowLevelDataDifferences.ReadOnly = true;
            this.dgvRowLevelDataDifferences.RowHeadersWidth = 51;
            this.dgvRowLevelDataDifferences.RowTemplate.Height = 24;
            this.dgvRowLevelDataDifferences.Size = new System.Drawing.Size(793, 350);
            this.dgvRowLevelDataDifferences.TabIndex = 21;
            this.dgvRowLevelDataDifferences.Visible = false;
            // 
            // DataCompareForm
            // 
            this.ClientSize = new System.Drawing.Size(854, 553);
            this.Controls.Add(this.lblRowLevelDataDifferences);
            this.Controls.Add(this.dgvRowLevelDataDifferences);
            this.Controls.Add(this.cbShowDifferences);
            this.Controls.Add(this.tbMaxTableRows);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCheckDeletes);
            this.Controls.Add(this.cbCheckUpdates);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtmpEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtmpStartDate);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSchemaName);
            this.Controls.Add(this.lblSchemaName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDataCompareResultsPerTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDataCompareResultsSummary);
            this.Controls.Add(this.btnRunDataCompare);
            this.Controls.Add(this.cbCheckInserts);
            this.Name = "DataCompareForm";
            this.Text = "Data Compare";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCompareResultsSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCompareResultsPerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowLevelDataDifferences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbCheckInserts;
        private System.Windows.Forms.Button btnRunDataCompare;
        private System.Windows.Forms.DataGridView dgvDataCompareResultsSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDataCompareResultsPerTable;
        private System.Windows.Forms.Label lblSchemaName;
        private System.Windows.Forms.TextBox tbSchemaName;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtmpStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtmpEndDate;
        private System.Windows.Forms.CheckBox cbCheckUpdates;
        private System.Windows.Forms.CheckBox cbCheckDeletes;
        private System.Windows.Forms.TextBox tbMaxTableRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbShowDifferences;
        private System.Windows.Forms.Label lblRowLevelDataDifferences;
        private System.Windows.Forms.DataGridView dgvRowLevelDataDifferences;
    }
}
