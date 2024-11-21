/*
 * TODO:
 * - Make source and target database configurable
 * - Allow user to specify source / target query
 * - Compare between two servers
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DIMonitor
{
    public partial class TableStatsForm : DIMonitor.BaseForm
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private bool _comboBoxesInitialized = false;

        public TableStatsForm()
        {
            InitializeComponent();
        }

        private void btnRunDataCompare_Click(object sender, EventArgs e)
        {
            GetTableStatistics();
        }

        public TableStatsForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

            // Set form title
            this.Text = "Table Statistics - " + _eNV.ToString();

            // Get available databases
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            DataSet DSAvailableDatabases = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_AVAILABLE_DATABASES, false);

            // Fill database comoboboxes
            DataTable dtSourceDBs = DSAvailableDatabases.Tables[0].Copy();

            cbSourceDB.DataSource = dtSourceDBs;
            cbSourceDB.DisplayMember = "Name";
            cbSourceDB.ValueMember = "Name";
            cbSourceDB.SelectedIndex = cbSourceDB.FindString("EDWOlap");

            //cbSourceDB.SelectedText = "IDS_Qlik";
            //cbSourceDB.SelectedIndex = 0;
            cbSourceDB.Refresh();
        }

        private void GetTableStatistics()
        {
            Cursor.Current = Cursors.WaitCursor;

            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, cbSourceDB.SelectedValue.ToString());

            /* Get Table Description */
            string query = SQLQueries.SQL_GET_TABLE_DESCRIPTION.Replace("<tableName>", cbTableName.Text).Replace("<schemaName>", cbSchemaNames.Text);
            try
            {
                // Get Table description
                DataSet dsTableDescription = _sqlDA.GetQueryDataSet(cs, query, false);
                if (dsTableDescription.Tables[0].Rows.Count > 0)
                    tbTableDescription.Text = dsTableDescription.Tables[0].Rows[0][0].ToString();
                else
                    tbTableDescription.Text = "No Description found for table " + cbTableName.Text + "." + cbTableName.Text + "\n" + query;
            }
            catch (Exception e)
            {
                throw e;
            }

            /* Get Table Schema */
            query = SQLQueries.SQL_GET_TABLE_SCHEMA.Replace("<FULL_TABLE_NAME>", cbSchemaNames.Text + "." + cbTableName.Text);
            try
            {
                // Get Table schema
                DataSet dsTableSchema = _sqlDA.GetQueryDataSet(cs, query, false);
                if (dsTableSchema.Tables.Count > 1)
                {
                    dgvTableSchema.DataSource = dsTableSchema.Tables[1];
                }
            }
            catch (Exception e)
            {
                //throw e;
                MessageBox.Show(e.Message);
            }

            /* Get Row count */
            query = SQLQueries.SQL_GET_TABLE_ROW_COUNT.Replace("<TABLE_NAME>", cbTableName.Text).Replace("<SCHEMA_NAME>", cbSchemaNames.Text);
            try
            {
                // Get Table schema
                DataSet dsRowCount = _sqlDA.GetQueryDataSet(cs, query, false);
                if (dsRowCount.Tables.Count > 0)
                {
                    dgvRowCount.DataSource = dsRowCount.Tables[0];
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            /* Get ETL mapping */
            query = SQLQueries.SQL_ETL_MAPPING.Replace("<TABLE_NAME>", cbTableName.Text).Replace("<SCHEMA_NAME>", cbSchemaNames.Text);
            try
            {
                // Get Table schema
                DataSet dsETLMapping = _sqlDA.GetQueryDataSet(cs, query, false);
                if (dsETLMapping.Tables.Count > 0)
                {
                    dgvETLMapping.DataSource = dsETLMapping.Tables[0];
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            /* Get FKs */

            /* Get referenced by FKs */

            Cursor.Current = Cursors.Default;
        }

        private void cbSourceDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Database changed: get schema names
            String databaseName = ((System.Data.DataRowView)cbSourceDB.SelectedItem).Row.ItemArray[0].ToString();
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, databaseName); // cbSourceDB.SelectedText);
            DataSet DSSchemaNames = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_DATABASE_SCHEMAS, false);

            // Fill schema name comobobox
            cbSchemaNames.DataSource = DSSchemaNames.Tables[0];
            cbSchemaNames.DisplayMember = "SCHEMA_NAME";
            cbSchemaNames.ValueMember = "SCHEMA_NAME";
            //cbSchemaNames.SelectedIndex = cbSchemaNames.FindString("general");
            cbSchemaNames.Refresh();
        }

        private void cbSchemaNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Schema changed: get table names
            String databaseName = ((System.Data.DataRowView)cbSourceDB.SelectedItem).Row.ItemArray[0].ToString();
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, databaseName); // cbSourceDB.SelectedText);
            string schemaName = ((System.Data.DataRowView)cbSchemaNames.SelectedItem).Row.ItemArray[0].ToString();
            DataSet DSSTableNames = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_DATABASE_TABLE_NAMES.Replace("<SCHEMA_NAME>", schemaName), false);

            // Fill schema name comobobox
            cbTableName.DataSource = DSSTableNames.Tables[0];
            cbTableName.DisplayMember = "TABLE_NAME";
            cbTableName.ValueMember = "TABLE_NAME";
            //cbTableName.SelectedIndex = cbTableName.FindString("DimOrganization");
            cbTableName.Refresh();
            _comboBoxesInitialized = true;
        }

        private void btnShowTransformSP_Click(object sender, EventArgs e)
        {
            TransformSPForm transformSPForm = new TransformSPForm(_eNV, _bU, _period, cbSchemaNames.Text, cbTableName.Text);
            transformSPForm.Show();
        }

        private void cbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_comboBoxesInitialized == true)
                GetTableStatistics();
        }

        private void cbTableName_TextUpdate(object sender, EventArgs e)
        {
         }

        private void cbTableName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_comboBoxesInitialized == true)
                    GetTableStatistics();
            }
        }
    }
}
