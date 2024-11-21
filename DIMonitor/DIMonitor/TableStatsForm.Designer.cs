
namespace DIMonitor
{
    partial class TableStatsForm
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
            this.btnGetTableStatistics = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTableSchema = new System.Windows.Forms.DataGridView();
            this.lblSchemaName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRowLevelDataDifferences = new System.Windows.Forms.Label();
            this.dgvRowCount = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSourceDB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvETLMapping = new System.Windows.Forms.DataGridView();
            this.lblTableDescription = new System.Windows.Forms.Label();
            this.tbTableDescription = new System.Windows.Forms.TextBox();
            this.cbSchemaNames = new System.Windows.Forms.ComboBox();
            this.cbTableName = new System.Windows.Forms.ComboBox();
            this.btnShowTransformSP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSchema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvETLMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetTableStatistics
            // 
            this.btnGetTableStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetTableStatistics.Location = new System.Drawing.Point(674, 37);
            this.btnGetTableStatistics.Name = "btnGetTableStatistics";
            this.btnGetTableStatistics.Size = new System.Drawing.Size(142, 23);
            this.btnGetTableStatistics.TabIndex = 3;
            this.btnGetTableStatistics.Text = "Get Table Statistics";
            this.btnGetTableStatistics.UseVisualStyleBackColor = true;
            this.btnGetTableStatistics.Click += new System.EventHandler(this.btnRunDataCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Table Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Table Schema";
            // 
            // dgvTableSchema
            // 
            this.dgvTableSchema.AllowUserToAddRows = false;
            this.dgvTableSchema.AllowUserToDeleteRows = false;
            this.dgvTableSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableSchema.Location = new System.Drawing.Point(26, 242);
            this.dgvTableSchema.Name = "dgvTableSchema";
            this.dgvTableSchema.ReadOnly = true;
            this.dgvTableSchema.RowHeadersWidth = 51;
            this.dgvTableSchema.RowTemplate.Height = 24;
            this.dgvTableSchema.Size = new System.Drawing.Size(793, 249);
            this.dgvTableSchema.TabIndex = 6;
            // 
            // lblSchemaName
            // 
            this.lblSchemaName.AutoSize = true;
            this.lblSchemaName.Location = new System.Drawing.Point(20, 43);
            this.lblSchemaName.Name = "lblSchemaName";
            this.lblSchemaName.Size = new System.Drawing.Size(98, 16);
            this.lblSchemaName.TabIndex = 8;
            this.lblSchemaName.Text = "Schema Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table Name";
            // 
            // lblRowLevelDataDifferences
            // 
            this.lblRowLevelDataDifferences.AutoSize = true;
            this.lblRowLevelDataDifferences.Location = new System.Drawing.Point(23, 512);
            this.lblRowLevelDataDifferences.Name = "lblRowLevelDataDifferences";
            this.lblRowLevelDataDifferences.Size = new System.Drawing.Size(72, 16);
            this.lblRowLevelDataDifferences.TabIndex = 22;
            this.lblRowLevelDataDifferences.Text = "Row Count";
            // 
            // dgvRowCount
            // 
            this.dgvRowCount.AllowUserToAddRows = false;
            this.dgvRowCount.AllowUserToDeleteRows = false;
            this.dgvRowCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRowCount.Location = new System.Drawing.Point(23, 532);
            this.dgvRowCount.Name = "dgvRowCount";
            this.dgvRowCount.ReadOnly = true;
            this.dgvRowCount.RowHeadersWidth = 51;
            this.dgvRowCount.RowTemplate.Height = 24;
            this.dgvRowCount.Size = new System.Drawing.Size(793, 49);
            this.dgvRowCount.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "DB:";
            // 
            // cbSourceDB
            // 
            this.cbSourceDB.FormattingEnabled = true;
            this.cbSourceDB.Location = new System.Drawing.Point(105, 20);
            this.cbSourceDB.Name = "cbSourceDB";
            this.cbSourceDB.Size = new System.Drawing.Size(216, 24);
            this.cbSourceDB.TabIndex = 27;
            this.cbSourceDB.SelectedIndexChanged += new System.EventHandler(this.cbSourceDB_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "ETL Mapping";
            // 
            // dgvETLMapping
            // 
            this.dgvETLMapping.AllowUserToAddRows = false;
            this.dgvETLMapping.AllowUserToDeleteRows = false;
            this.dgvETLMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvETLMapping.Location = new System.Drawing.Point(23, 603);
            this.dgvETLMapping.Name = "dgvETLMapping";
            this.dgvETLMapping.ReadOnly = true;
            this.dgvETLMapping.RowHeadersWidth = 51;
            this.dgvETLMapping.RowTemplate.Height = 24;
            this.dgvETLMapping.Size = new System.Drawing.Size(793, 249);
            this.dgvETLMapping.TabIndex = 28;
            // 
            // lblTableDescription
            // 
            this.lblTableDescription.AutoSize = true;
            this.lblTableDescription.Location = new System.Drawing.Point(26, 118);
            this.lblTableDescription.Name = "lblTableDescription";
            this.lblTableDescription.Size = new System.Drawing.Size(0, 16);
            this.lblTableDescription.TabIndex = 30;
            // 
            // tbTableDescription
            // 
            this.tbTableDescription.Location = new System.Drawing.Point(29, 118);
            this.tbTableDescription.Multiline = true;
            this.tbTableDescription.Name = "tbTableDescription";
            this.tbTableDescription.ReadOnly = true;
            this.tbTableDescription.Size = new System.Drawing.Size(790, 69);
            this.tbTableDescription.TabIndex = 31;
            // 
            // cbSchemaNames
            // 
            this.cbSchemaNames.FormattingEnabled = true;
            this.cbSchemaNames.Location = new System.Drawing.Point(21, 64);
            this.cbSchemaNames.Name = "cbSchemaNames";
            this.cbSchemaNames.Size = new System.Drawing.Size(166, 24);
            this.cbSchemaNames.TabIndex = 32;
            this.cbSchemaNames.SelectedIndexChanged += new System.EventHandler(this.cbSchemaNames_SelectedIndexChanged);
            // 
            // cbTableName
            // 
            this.cbTableName.FormattingEnabled = true;
            this.cbTableName.Location = new System.Drawing.Point(208, 67);
            this.cbTableName.Name = "cbTableName";
            this.cbTableName.Size = new System.Drawing.Size(307, 24);
            this.cbTableName.TabIndex = 33;
            this.cbTableName.SelectedIndexChanged += new System.EventHandler(this.cbTableName_SelectedIndexChanged);
            this.cbTableName.TextUpdate += new System.EventHandler(this.cbTableName_TextUpdate);
            this.cbTableName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTableName_KeyPress);
            // 
            // btnShowTransformSP
            // 
            this.btnShowTransformSP.Location = new System.Drawing.Point(674, 66);
            this.btnShowTransformSP.Name = "btnShowTransformSP";
            this.btnShowTransformSP.Size = new System.Drawing.Size(142, 23);
            this.btnShowTransformSP.TabIndex = 34;
            this.btnShowTransformSP.Text = "Show Transform SP";
            this.btnShowTransformSP.UseVisualStyleBackColor = true;
            this.btnShowTransformSP.Click += new System.EventHandler(this.btnShowTransformSP_Click);
            // 
            // TableStatsForm
            // 
            this.ClientSize = new System.Drawing.Size(854, 966);
            this.Controls.Add(this.btnShowTransformSP);
            this.Controls.Add(this.cbTableName);
            this.Controls.Add(this.cbSchemaNames);
            this.Controls.Add(this.tbTableDescription);
            this.Controls.Add(this.lblTableDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvETLMapping);
            this.Controls.Add(this.cbSourceDB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRowLevelDataDifferences);
            this.Controls.Add(this.dgvRowCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSchemaName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTableSchema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetTableStatistics);
            this.Name = "TableStatsForm";
            this.Text = "Table Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableSchema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRowCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvETLMapping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGetTableStatistics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTableSchema;
        private System.Windows.Forms.Label lblSchemaName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRowLevelDataDifferences;
        private System.Windows.Forms.DataGridView dgvRowCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSourceDB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvETLMapping;
        private System.Windows.Forms.Label lblTableDescription;
        private System.Windows.Forms.TextBox tbTableDescription;
        private System.Windows.Forms.ComboBox cbSchemaNames;
        private System.Windows.Forms.ComboBox cbTableName;
        private System.Windows.Forms.Button btnShowTransformSP;
    }
}
