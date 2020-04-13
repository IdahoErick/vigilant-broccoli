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
 
        public VVRunDetailsForm(Utility.ENV env, Utility.BU bu, Utility.PERIOD period, DateTime kalenderDatum, Int64 ssisRunID)
        {
            InitializeComponent();

            Init(env, bu, period, ILRunID, ssisRunID, kalenderDatum, toolStripStatusLabel1);

            lblEnvironment.Text = env.ToString();
            lblBU.Text = bu.ToString();
            lblPeriod.Text = period.ToString();

            // Fill Kalenderdatum dropbox with dates from kalender
            FillCalendarDateDropbox(kalenderDatum, cbCalendarDates);

            SetupDetailsList();

            RefreshData();

            _initialized = true;
        }
 
        private void SetupDetailsList()
        {
            RunDetailList.Add(new clsRunDetail("Peildatum", clsRunDetail.DetailType.DateTimeLabel, lblPeilDatum));
            RunDetailList.Add(new clsRunDetail("LEGEN_STG", clsRunDetail.DetailType.Checkbox, cbLegenStaging));
            RunDetailList.Add(new clsRunDetail("LAAD_STG", clsRunDetail.DetailType.Checkbox, cbLaadStaging));
            RunDetailList.Add(new clsRunDetail("DOEL_OFS_KLANTDATA", clsRunDetail.DetailType.Checkbox, cbDoelOFSKlantdata));
            RunDetailList.Add(new clsRunDetail("BRON_OFS_MIDAS", clsRunDetail.DetailType.Checkbox, cbLaadOFSMidas));
            RunDetailList.Add(new clsRunDetail("BRON_EP_NN", clsRunDetail.DetailType.Checkbox, cbLaadEPNN));
            RunDetailList.Add(new clsRunDetail("BRON_OFS", clsRunDetail.DetailType.Checkbox, cbLaadOFS));
            RunDetailList.Add(new clsRunDetail("BRON_EP_MIDAS", clsRunDetail.DetailType.Checkbox, cbLaadEPMidas));
            RunDetailList.Add(new clsRunDetail("BRON_IKV", clsRunDetail.DetailType.Checkbox, cbLaadIKV));
            RunDetailList.Add(new clsRunDetail("LEGEN_DDS", clsRunDetail.DetailType.Checkbox, cbLegenDDS));
            RunDetailList.Add(new clsRunDetail("LAAD_DDS", clsRunDetail.DetailType.Checkbox, cbLaadDDS));
            RunDetailList.Add(new clsRunDetail("LAAD_DDS_DWH", clsRunDetail.DetailType.Checkbox, cbLaadDDSDWH));
            RunDetailList.Add(new clsRunDetail("MAAK_CF", clsRunDetail.DetailType.Checkbox, cbMaakCF));
            RunDetailList.Add(new clsRunDetail("CFDistributielijst", clsRunDetail.DetailType.TextBox,tbDistributieLijst));
        }

        public override int RefreshData()
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

                    //lblPeilDatum.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PeilDatum"]).ToString("dd-MM-yyyy");
                    
                    //cbLegenStaging.Checked = (ds.Tables[0].Rows[0]["LEGEN_STG"].ToString() == "J");
                    //cbLaadStaging.Checked = (ds.Tables[0].Rows[0]["LAAD_STG"].ToString() == "J");
                    
                    //cbLaadEPMidas.Checked = (ds.Tables[0].Rows[0]["BRON_EP_MIDAS"].ToString() == "J");
                    //cbLaadEPNN.Checked = (ds.Tables[0].Rows[0]["BRON_EP_NN"].ToString() == "J");
                    //cbLaadIKV.Checked = (ds.Tables[0].Rows[0]["BRON_IKV"].ToString() == "J");
                    //cbLaadOFS.Checked = (ds.Tables[0].Rows[0]["BRON_OFS"].ToString() == "J");
                    //cbLaadOFSMidas.Checked = (ds.Tables[0].Rows[0]["BRON_OFS_MIDAS"].ToString() == "J");
                    //cbDoelOFSKlantdata.Checked = (ds.Tables[0].Rows[0]["DOEL_OFS_KLANTDATA"].ToString() == "J");
                    //cbLaadDDS.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS"].ToString() == "J");
                    //cbLaadDDSDWH.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS_DWH"].ToString() == "J");
                    //cbMaakCF.Checked = (ds.Tables[0].Rows[0]["MAAK_CF"].ToString() == "J");

                    //tbDistributieLijst.Text = ds.Tables[0].Rows[0]["CFDistributielijst"].ToString();

                    //cbLegenDDS.Checked = (ds.Tables[0].Rows[0]["LEGEN_DDS"].ToString() == "J");
                    //cbLaadDDS.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS"].ToString() == "J");
                    //cbLaadDDSDWH.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS_DWH"].ToString() == "J");
                }
            }
            else
            {
                rc = -1;
            }
            return rc;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            StartRun();
        }

        private void cbCalendarDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initialized == true && cbCalendarDates.Text != "")
            {
                CalendarDate = DateTime.Parse(cbCalendarDates.Text);
                RefreshData();
            }
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            GenerateUpdateScript(false);
        }

        private void btnAbortRun_Click(object sender, EventArgs e)
        {
            AbortRun();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GenerateUpdateScript(true);
        }
    }
}
