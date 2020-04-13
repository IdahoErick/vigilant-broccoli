using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DIMonitor
{
    public partial class VVRunDetailsForm : RunDetailBaseForm
    {
        private bool _initialized = false;
        private List<clsILProcess> _processList = new List<clsILProcess>();
        private List<clsRunDetail> _runDetailList = new List<clsRunDetail>();
 
        public VVRunDetailsForm(Utility.ENV env, Utility.BU bu, Utility.PERIOD period, DateTime kalenderDatum, Int64 ssisRunID)
        {
            InitializeComponent();

            Init(env, bu, period, ILRunID, ssisRunID, kalenderDatum);

            lblEnvironment.Text = env.ToString();
            lblBU.Text = bu.ToString();
            lblPeriod.Text = period.ToString();

            // Fill Kalenderdatum dropbox with dates from kalender
            FillCalendarDateDropbox(kalenderDatum, cbCalendarDates);

            SetupDetailsList();

            RefreshData();

            _initialized = true;
        }

 
        private void cbLegenStaging_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SetupDetailsList()
        {
            _runDetailList.Add(new clsRunDetail("Peildatum", clsRunDetail.DetailType.DateTimeLabel, lblPeilDatum));
            _runDetailList.Add(new clsRunDetail("LEGEN_STG", clsRunDetail.DetailType.Checkbox, cbLegenStaging));
            _runDetailList.Add(new clsRunDetail("LAAD_STG", clsRunDetail.DetailType.Checkbox, cbLaadStaging));
            _runDetailList.Add(new clsRunDetail("DOEL_OFS_KLANTDATA", clsRunDetail.DetailType.Checkbox, cbDoelOFSKlantdata, true));
            _runDetailList.Add(new clsRunDetail("BRON_OFS_MIDAS", clsRunDetail.DetailType.Checkbox, cbLaadOFSMidas, true));
            _runDetailList.Add(new clsRunDetail("BRON_EP_NN", clsRunDetail.DetailType.Checkbox, cbLaadEPNN, true));
            _runDetailList.Add(new clsRunDetail("BRON_OFS", clsRunDetail.DetailType.Checkbox, cbLaadOFS, true));
            _runDetailList.Add(new clsRunDetail("BRON_EP_MIDAS", clsRunDetail.DetailType.Checkbox, cbLaadEPMidas));
            _runDetailList.Add(new clsRunDetail("BRON_IKV", clsRunDetail.DetailType.Checkbox, cbLaadIKV, true));
            _runDetailList.Add(new clsRunDetail("LEGEN_DDS", clsRunDetail.DetailType.Checkbox, cbLegenDDS));
            _runDetailList.Add(new clsRunDetail("LAAD_DDS", clsRunDetail.DetailType.Checkbox, cbLaadDDS));
            _runDetailList.Add(new clsRunDetail("LAAD_DDS_DWH", clsRunDetail.DetailType.Checkbox, cbLaadDDSDWH));
            _runDetailList.Add(new clsRunDetail("MAAK_CF", clsRunDetail.DetailType.Checkbox, cbMaakCF));
            _runDetailList.Add(new clsRunDetail("CFDistributielijst", clsRunDetail.DetailType.Label,lblCFDistributieLijst));
        }

        private int RefreshData()
        {
            string cs;
            int rc = 0;

            cs = Utility.GetConnectionString(ENV, BU, Period, false);

            if (cs != "")
            {
                string detailsQuery = (BU == Utility.BU.ILVB ? SQLQueries.SQL_RUN_DETAILS_ILH : SQLQueries.SQL_RUN_DETAILS_ILSB);
                // Replace DAG with MAAND if this is a MAAND process
                if (Period == Utility.PERIOD.MAAND)
                    detailsQuery = detailsQuery.Replace("_DAG", "_MAAND");

                // Replace <kalenderdatum> with real date
                detailsQuery = detailsQuery.Replace("<Kalenderdatum>", CalendarDate.Year + "-" + CalendarDate.Month + "-" + CalendarDate.Day);

                DataSet ds = this.SqlDA.GetQueryDataSet(cs, detailsQuery, false);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Load details list
                    LoadDetailsList(ds.Tables[0]);

                    lblPeilDatum.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PeilDatum"]).ToString("dd-MM-yyyy");
                    
                    cbLegenStaging.Checked = (ds.Tables[0].Rows[0]["LEGEN_STG"].ToString() == "J");
                    cbLaadStaging.Checked = (ds.Tables[0].Rows[0]["LAAD_STG"].ToString() == "J");
                    
                    cbLaadEPMidas.Checked = (ds.Tables[0].Rows[0]["BRON_EP_MIDAS"].ToString() == "J");
                    cbLaadEPNN.Checked = (ds.Tables[0].Rows[0]["BRON_EP_NN"].ToString() == "J");
                    cbLaadIKV.Checked = (ds.Tables[0].Rows[0]["BRON_IKV"].ToString() == "J");
                    cbLaadOFS.Checked = (ds.Tables[0].Rows[0]["BRON_OFS"].ToString() == "J");
                    cbLaadOFSMidas.Checked = (ds.Tables[0].Rows[0]["BRON_OFS_MIDAS"].ToString() == "J");
                    cbDoelOFSKlantdata.Checked = (ds.Tables[0].Rows[0]["DOEL_OFS_KLANTDATA"].ToString() == "J");
                    cbLaadDDS.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS"].ToString() == "P");
                    cbLaadDDSDWH.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS_DWH"].ToString() == "P");
                    cbMaakCF.Checked = (ds.Tables[0].Rows[0]["MAAK_CF"].ToString() == "J");

                    lblCFDistributieLijst.Text = ds.Tables[0].Rows[0]["CFDistributielijst"].ToString();

                    cbLegenDDS.Checked = (ds.Tables[0].Rows[0]["LEGEN_DDS"].ToString() == "J");
                    cbLaadDDS.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS"].ToString() == "J");
                    cbLaadDDSDWH.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS_DWH"].ToString() == "J");
                }
            }
            else
            {
                rc = -1;
            }
            return rc;
        }

        private void LoadDetailsList(DataTable dtDetails)
        {
            foreach (DataColumn dc in dtDetails.Columns)
            {
                clsRunDetail rd = _runDetailList.Find(x => x.Name.Equals(dc.Caption));
                if (rd != null)
                    rd.SetValue(dtDetails.Rows[0][dc.Caption].ToString());
                else
                    MessageBox.Show("Detail not found in list for column:" + dc.Caption);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            if (ENV == Utility.ENV.LOCAL)
            {
                try
                {
                    string envMessage = BU.ToString() + " - " + ENV.ToString() + " - " + Period.ToString();

                    if (MessageBox.Show("Start run " + envMessage + " ?", "Start Run", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string cs = Utility.GetConnectionString(ENV, BU, Period);

                        string startRunQuery = (BU == Utility.BU.ILVB ? SQLQueries.SQL_START_RUN_ILH : SQLQueries.SQL_START_RUN_ILH);
                        startRunQuery = startRunQuery.Replace("<PERIOD>", Period == Utility.PERIOD.MAAND ? "MAAND" : "DAG");
                        startRunQuery = startRunQuery.Replace("<Kalenderdatum>", FormatDate4DB(CalendarDate));

                        int rc = this.SqlDA.ExecuteSQLCommand(cs, startRunQuery);
                        string message = "Run Started, " + envMessage;
                        toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": " + message;
                        MessageBox.Show(message);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (message.Length > 100)
                        message = message.Substring(0, 100);
                    toolStripStatusLabel1.Text = DateTime.Now.ToString() +  ": " + message;
                    MessageBox.Show(ex.Message);
                }
            }
            else
                toolStripStatusLabel1.Text = DateTime.Now.ToString() +  ": Function only available on local machine";
        }

        private void cbCalendarDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initialized == true && cbCalendarDates.Text != "")
            {
                CalendarDate = DateTime.Parse(cbCalendarDates.Text);
                RefreshData();
            }
        }

        private string GenerateUpdateQuery()
        {
            bool firstDetail = true;
            StringBuilder query = new StringBuilder("UPDATE ILH_METADATA.MDA.KALENDERVERWERKING_");
            query.Append(Period == Utility.PERIOD.MAAND ? "MAAND" : "DAG");
            query.Append(" SET ");

            foreach (clsRunDetail rd in _runDetailList)
            {
                if (rd.HasChanged)
                {
                    query.AppendFormat("{0}{1} = {2}", firstDetail ? "" : " ,", rd.Name, rd.NewValueDBFormatted);
                    firstDetail = false;
                }
            }
            if (firstDetail)
                query.Clear();
            else
                query.AppendFormat(" WHERE Kalenderdatum = '{0}-{1}-{2}'", CalendarDate.Year, CalendarDate.Month, CalendarDate.Day);

            return query.ToString();
        }

        private string FormatDate4DB(DateTime date)
        {
            return String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            string query = GenerateUpdateQuery();
            if (query.Length > 0)
            {
                QueryOutputForm queryForm = new QueryOutputForm(query.ToString());
                queryForm.Show();
            }
            else
                MessageBox.Show("Nothing to update!");
        }

        private void btnAbortRun_Click(object sender, EventArgs e)
        {
            if (ENV == Utility.ENV.LOCAL)
            {
                if (SsisRunID > 0)
                {
                    try
                    {
                        string envMessage = BU.ToString() + " - " + ENV.ToString() + " - " + Period.ToString();

                        if (MessageBox.Show("Abort run " + envMessage + " ?", "Abort Run", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string cs = Utility.GetConnectionString(ENV, BU, Period);

                            string abortRunQuery = SQLQueries.SQL_ABORT_RUN.Replace("<RunID>", this.SsisRunID.ToString());
                            int rc = SqlDA.ExecuteSQLCommand(cs, abortRunQuery);
                            string message = "Run Aborted, " + envMessage;
                            toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": " + message;
                            MessageBox.Show(message);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message);
                    }
                }
                else
                    toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": No valid SSIS Run ID available";
            }
            else
                toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": Function only available on local machine";
       
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = GenerateUpdateQuery();
            if (query.Length > 0)
            {
                string cs = Utility.GetConnectionString(ENV, BU, Period);
                try
                {
                    int rc = SqlDA.ExecuteSQLCommand(cs, query);
                    if (rc == 1)
                        MessageBox.Show("Calendar updated!");
                    else
                        MessageBox.Show("Failed to update calendar");

                    RefreshData();  // Refresh form data
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            else
                MessageBox.Show("Nothing to update!");
        }
        private void ShowMessage(string exceptionMessage)
        {
            string message = exceptionMessage;
            if (message.Length > 100)
                message = message.Substring(0, 100);
            toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": " + message;
            MessageBox.Show(exceptionMessage);
        }
    }
}
