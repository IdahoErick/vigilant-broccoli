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
    public partial class RunDetailsForm : RunDetailBaseForm
    {
        //        Utility.ENV ENV;
        //        Utility.BU BU;
        //        Utility.PERIOD Period;
        //        DateTime CalendarDate;
        //        Int64 _SSISRunID = 0;
        //        private SQLDBAccess SqlDA = new SQLDBAccess();
        private bool _initialized = false;
        //       private List<clsILProcess> _processList = new List<clsILProcess>();
        //       private List<clsRunDetail> RunDetailList = new List<clsRunDetail>();

        public RunDetailsForm(Utility.ENV env, Utility.BU bu, Utility.PERIOD period, DateTime kalenderDatum, Int64 SSISRunID)
        {
            InitializeComponent();

            Init(env, bu, period, ILRunID, SSISRunID, kalenderDatum, toolStripStatusLabel1);

            lblEnvironment.Text = env.ToString();
            lblBU.Text = bu.ToString();
            lblPeriod.Text = period.ToString();
            //cbCalendarDates.SelectedValue = kalenderDatum;

            // Fill Kalenderdatum dropbox with dates from kalender
            FillCalendarDateDropbox(kalenderDatum, cbCalendarDates);

            SetupDetailsList();

            RefreshData();

            _initialized = true;
        }

        /*
        private void FillCalendarDateDropbox(DateTime kalenderDatum)
        {
            string sqlQuery = SQLQueries.SQL_CALENDAR_DATES.Replace("<period>", Period.ToString());
            DataSet ds = SqlDA.GetQueryDataSet(Utility.GetConnectionString(ENV, BU, Period, false), sqlQuery, false);
   
            cbCalendarDates.DataSource = ds.Tables[0];
            cbCalendarDates.DisplayMember = "Kalenderdatum";

            // Set selected item
            foreach (DataRowView item in cbCalendarDates.Items)
            {
                if (DateTime.Parse(item[0].ToString()) == kalenderDatum)
                {
                    cbCalendarDates.SelectedItem = item;
                    break;
                }
            }
        }
         */

        private void cbLegenStaging_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SetupDetailsList()
        {
            RunDetailList.Add(new clsRunDetail("CycleLogDetailId", clsRunDetail.DetailType.Label, lblPeilDatum));
/*
            RunDetailList.Add(new clsRunDetail("CLOSE_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpClosePeilDatum, false, cbLaadClosePDNull));
            //RunDetailList.Add(new clsRunDetail("CLOSE_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("CLOSE_CM_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpCloseCMPeilDatum, false, cbLaadCloseCMPDNull));
            //RunDetailList.Add(new clsRunDetail("CLOSE_CM_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("DAYBREAK_Verwacht_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpDaybreakPeilDatum, false, cbLaadDaybreakPDNull));
            //RunDetailList.Add(new clsRunDetail("DAYBREAK_Vorige_Peildatum"));
            //RunDetailList.Add(new clsRunDetail("DAYBREAK_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("HOMES_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpHomesPeilDatum, false, cbLaadHomesPDNull));
            //RunDetailList.Add(new clsRunDetail("HOMES_Maand_Ultimo"));
            //RunDetailList.Add(new clsRunDetail("HIST_HOMES_Peildatum"));
            //RunDetailList.Add(new clsRunDetail("HIST_HOMES_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("MIDAS_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpMidasPeilDatum, false, cbLaadMidasPDNull));
            //RunDetailList.Add(new clsRunDetail("MIDAS_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("MIDAS_CK_Verwacht_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpMidasCKPeilDatum, false, cbLaadMidasCKPDNull));
            //RunDetailList.Add(new clsRunDetail("MIDAS_CK_Vorige_Peildatum"));
            //RunDetailList.Add(new clsRunDetail("MIDAS_CK_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("HOUSE_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpHousePeilDatum, false, cbLaadHousePDNull));
            //RunDetailList.Add(new clsRunDetail("HOUSE_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("QUION_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpQuionPeilDatum, false, cbLaadQuionPDNull));
            //RunDetailList.Add(new clsRunDetail("QUION_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("SAPBW_Achterstand_PolisData_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpSAPAchterstandPeilDatum, false, cbLaadSAPAchterstandPDNull));
            RunDetailList.Add(new clsRunDetail("SAPBW_KlantData_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpSAPKlantPeilDatum, false, cbLaadSAPKlantPDNull));
            RunDetailList.Add(new clsRunDetail("SAPBW_PolisData_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpSAPPolisPeilDatum, false, cbLaadSAPPolisPDNull));
            RunDetailList.Add(new clsRunDetail("SAP_ICM_Verwacht_Peildatum", clsRunDetail.DetailType.DateTimePicker, dtpSAPICMPeilDatum, false, cbLaadSAPICMPDNull));
            //RunDetailList.Add(new clsRunDetail("SAP_ICM_Vorige_Peildatum"));
            //RunDetailList.Add(new clsRunDetail("SAP_ICM_Maand_Ultimo"));
            RunDetailList.Add(new clsRunDetail("VOORBEREIDEN_RUN", clsRunDetail.DetailType.Checkbox, cbVoorbereidenRun));
            RunDetailList.Add(new clsRunDetail("ARCHIEFBESTANDEN_ZIPPEN", clsRunDetail.DetailType.Checkbox, cbArchiefbestandenZippen));
            RunDetailList.Add(new clsRunDetail("LAAD_HOUSE_FP", clsRunDetail.DetailType.Checkbox, cbLaadHouseFP, true));
            RunDetailList.Add(new clsRunDetail("LEGEN_STG", clsRunDetail.DetailType.Checkbox, cbLegenStaging));
            RunDetailList.Add(new clsRunDetail("LAAD_STG", clsRunDetail.DetailType.Checkbox, cbLaadStaging));
            RunDetailList.Add(new clsRunDetail("LAAD_CBS", clsRunDetail.DetailType.Checkbox, cbLaadCBS, true));
            RunDetailList.Add(new clsRunDetail("LAAD_CLOSE", clsRunDetail.DetailType.Checkbox, cbLaadCloseBO, true));
            RunDetailList.Add(new clsRunDetail("LAAD_CLOSE_CM", clsRunDetail.DetailType.Checkbox, cbLaadCloseCM, true));
            RunDetailList.Add(new clsRunDetail("LAAD_DAYBREAK", clsRunDetail.DetailType.Checkbox, cbLaadDaybreak, true));
            RunDetailList.Add(new clsRunDetail("LAAD_HOMES", clsRunDetail.DetailType.Checkbox, cbLaadHomes));
            //RunDetailList.Add(new clsRunDetail("LAAD_HIST_HOMES", clsRunDetail.DetailType.Checkbox, cbLaadHis));
            RunDetailList.Add(new clsRunDetail("LAAD_MIDAS", clsRunDetail.DetailType.Checkbox, cbLaadMidas, true));
            RunDetailList.Add(new clsRunDetail("LAAD_MIDAS_CK", clsRunDetail.DetailType.Checkbox, cbLaadMidasCK, true));
            RunDetailList.Add(new clsRunDetail("LAAD_HOUSE", clsRunDetail.DetailType.Checkbox, cbLaadHouse, true));
            RunDetailList.Add(new clsRunDetail("LAAD_MDS", clsRunDetail.DetailType.Checkbox, cbLaadMDS));
            RunDetailList.Add(new clsRunDetail("LAAD_QUION", clsRunDetail.DetailType.Checkbox, cbLaadQuion, true));
            RunDetailList.Add(new clsRunDetail("LAAD_SAPBW_ACHTERSTAND_POLISDATA", clsRunDetail.DetailType.Checkbox, cbLaadSAPAchterstandPolisData, true));
            RunDetailList.Add(new clsRunDetail("LAAD_SAPBW_KLANTDATA", clsRunDetail.DetailType.Checkbox, cbLaadSAPKlantData, true));
            RunDetailList.Add(new clsRunDetail("LAAD_SAPBW_POLISDATA", clsRunDetail.DetailType.Checkbox, cbLaadSAPPolisData, true));
            RunDetailList.Add(new clsRunDetail("LAAD_SAP_ICM", clsRunDetail.DetailType.Checkbox, cbLaadSAPICM, true));
            RunDetailList.Add(new clsRunDetail("LAAD_DDS", clsRunDetail.DetailType.Checkbox, cbLaadDDS));
            RunDetailList.Add(new clsRunDetail("LAAD_DDS_DWH", clsRunDetail.DetailType.Checkbox, cbLaadDDSDWH));
            RunDetailList.Add(new clsRunDetail("MAAK_CF", clsRunDetail.DetailType.Checkbox, cbMaakCF));
            RunDetailList.Add(new clsRunDetail("CFDistributielijst", clsRunDetail.DetailType.TextBox, tbCFDistributieLijst));
            RunDetailList.Add(new clsRunDetail("SoortRun", clsRunDetail.DetailType.Label, lblSoortRun));
*/
        }

        public override int RefreshData()
        {
            string cs;
            int rc = 0;

            cs = Utility.GetConnectionString(ENV, BU, Period, false);

            if (cs != "")
            {
                string detailsQuery = SQLQueries.SQL_RUN_DETAILS;

                // Replace <kalenderdatum> with real date
                detailsQuery = detailsQuery.Replace("<Kalenderdatum>", CalendarDate.Year + "-" + CalendarDate.Month + "-" + CalendarDate.Day);

                DataSet ds = SqlDA.GetQueryDataSet(cs, detailsQuery, false);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Load details list
                    LoadDetailsList(ds.Tables[0]);

                    //lblPeilDatum.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PeilDatum"]).ToString("dd-MM-yyyy");

                    //cbLegenStaging.Checked = (ds.Tables[0].Rows[0]["LEGEN_STG"].ToString() == "J");
                    //cbLaadStaging.Checked = (ds.Tables[0].Rows[0]["LAAD_STG"].ToString() == "J");
                    //cbLaadCloseBO.Checked = (ds.Tables[0].Rows[0]["LAAD_CLOSE"].ToString() == "P");
                    //cbVoorbereidenRun.Checked = (ds.Tables[0].Rows[0]["VOORBEREIDEN_RUN"].ToString() == "J");
                    //cbArchiefbestandenZippen.Checked = (ds.Tables[0].Rows[0]["ARCHIEFBESTANDEN_ZIPPEN"].ToString() == "J");
                    //cbLaadHouseFP.Checked = (ds.Tables[0].Rows[0]["LAAD_HOUSE_FP"].ToString() == "P");
                    //cbLaadCBS.Checked = (ds.Tables[0].Rows[0]["LAAD_CBS"].ToString() == "P");
                    //cbLaadCloseCM.Checked = (ds.Tables[0].Rows[0]["LAAD_CLOSE_CM"].ToString() == "P");
                    //cbLaadDaybreak.Checked = (ds.Tables[0].Rows[0]["LAAD_DAYBREAK"].ToString() == "P");
                    //cbLaadHomes.Checked = (ds.Tables[0].Rows[0]["LAAD_HOMES"].ToString() == "J");
                    //cbLaadMidas.Checked = (ds.Tables[0].Rows[0]["LAAD_MIDAS"].ToString() == "P");
                    //cbLaadMidasCK.Checked = (ds.Tables[0].Rows[0]["LAAD_MIDAS_CK"].ToString() == "P");
                    //cbLaadHouse.Checked = (ds.Tables[0].Rows[0]["LAAD_HOUSE"].ToString() == "P");
                    //cbLaadMDS.Checked = (ds.Tables[0].Rows[0]["LAAD_MDS"].ToString() == "J");
                    //cbLaadQuion.Checked = (ds.Tables[0].Rows[0]["LAAD_QUION"].ToString() == "P");
                    //cbLaadSAPAchterstandPolisData.Checked = (ds.Tables[0].Rows[0]["LAAD_SAPBW_ACHTERSTAND_POLISDATA"].ToString() == "P");
                    //cbLaadSAPKlantData.Checked = (ds.Tables[0].Rows[0]["LAAD_SAPBW_KLANTDATA"].ToString() == "P");
                    //cbLaadSAPPolisData.Checked = (ds.Tables[0].Rows[0]["LAAD_SAPBW_POLISDATA"].ToString() == "P");
                    //cbLaadSAPICM.Checked = (ds.Tables[0].Rows[0]["LAAD_SAP_ICM"].ToString() == "P");
                    //cbLaadDDS.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS"].ToString() == "P");
                    //cbLaadDDSDWH.Checked = (ds.Tables[0].Rows[0]["LAAD_DDS_DWH"].ToString() == "P");
                    //cbMaakCF.Checked = (ds.Tables[0].Rows[0]["MAAK_CF"].ToString() == "J");

                    //dtpClosePeilDatum.Text = ds.Tables[0].Rows[0]["CLOSE_Peildatum"].ToString();
                    //dtpCloseCMPeilDatum.Text = ds.Tables[0].Rows[0]["CLOSE_CM_Peildatum"].ToString();
                    //dtpDaybreakPeilDatum.Text = ds.Tables[0].Rows[0]["DAYBREAK_Verwacht_Peildatum"].ToString();
                    //dtpHomesPeilDatum.Text = ds.Tables[0].Rows[0]["HOMES_Peildatum"].ToString();
                    //dtpMidasPeilDatum.Text = ds.Tables[0].Rows[0]["MIDAS_Peildatum"].ToString();
                    //dtpMidasCKPeilDatum.Text = ds.Tables[0].Rows[0]["MIDAS_CK_Verwacht_Peildatum"].ToString();
                    //dtpHousePeilDatum.Text = ds.Tables[0].Rows[0]["HOUSE_Peildatum"].ToString();
                    //dtpQuionPeilDatum.Text = ds.Tables[0].Rows[0]["QUION_Peildatum"].ToString();
                    //dtpSAPAchterstandPeilDatum.Text = ds.Tables[0].Rows[0]["SAPBW_Achterstand_PolisData_Peildatum"].ToString();
                    //dtpSAPKlantPeilDatum.Text = ds.Tables[0].Rows[0]["SAPBW_KlantData_Peildatum"].ToString();
                    //dtpSAPPolisPeilDatum.Text = ds.Tables[0].Rows[0]["SAPBW_PolisData_Peildatum"].ToString();
                    //dtpSAPICMPeilDatum.Text = ds.Tables[0].Rows[0]["SAP_ICM_Verwacht_Peildatum"].ToString();

                    //lblCFDistributieLijst.Text = ds.Tables[0].Rows[0]["CFDistributielijst"].ToString();
                    //lblSoortRun.Text = ds.Tables[0].Rows[0]["SoortRun"].ToString();

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
        /*
                private void LoadDetailsList(DataTable dtDetails)
                {
                    foreach (DataColumn dc in dtDetails.Columns)
                    {
                        clsRunDetail rd = RunDetailList.Find(x => x.Name.Equals(dc.Caption));
                        if (rd != null)
                            rd.SetValue(dtDetails.Rows[0][dc.Caption].ToString());
                        else
                            MessageBox.Show("Detail not found in list for column:" + dc.Caption);
                    }
                }
        */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            StartRun();
            //if (ENV == Utility.ENV.LOCAL)
            //{
            //    try
            //    {
            //        string envMessage = BU.ToString() + " - " + ENV.ToString() + " - " + Period.ToString();

            //        if (MessageBox.Show("Start run " + envMessage + " ?", "Start Run", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            string cs = Utility.GetConnectionString(ENV, BU, Period);

            //            string startRunQuery = (BU == Utility.BU.ILVB ? SQLQueries.SQL_START_RUN_ILH : SQLQueries.SQL_START_RUN_ILH);
            //            startRunQuery = startRunQuery.Replace("<PERIOD>", Period == Utility.PERIOD.MAAND ? "MAAND" : "DAG");
            //            startRunQuery = startRunQuery.Replace("<Kalenderdatum>", FormatDate4DB(CalendarDate));

            //            //// Replace DAG with MAAND if this is a MAAND process
            //            //if (Period == Utility.PERIOD.MAAND)
            //            //    startRunQuery = startRunQuery.Replace("<PERIOD>", "MAAND");
            //            //else
            //            //    startRunQuery = startRunQuery.Replace("<PERIOD>", "DAG");

            //            // Replace <kalenderdatum> with real date
            //            //detailsQuery = detailsQuery.Replace("<Kalenderdatum>", CalendarDate.Year + "-" + CalendarDate.Month + "-" + CalendarDate.Day);

            //            int rc = SqlDA.ExecuteSQLCommand(cs, startRunQuery);
            //            string message = "Run Started, " + envMessage;
            //            toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": " + message;
            //            MessageBox.Show(message);
            //            this.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string message = ex.Message;
            //        if (message.Length > 100)
            //            message = message.Substring(0, 100);
            //        toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": " + message;
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else
            //    toolStripStatusLabel1.Text = DateTime.Now.ToString() + ": Function only available on local machine";
        }

        private void cbCalendarDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initialized == true && cbCalendarDates.Text != "")
            {
                CalendarDate = DateTime.Parse(cbCalendarDates.Text);
                RefreshData();
            }
        }
        /*
                private string GenerateUpdateQuery()
                {
                    bool firstDetail = true;
                    StringBuilder query = new StringBuilder("UPDATE ILH_METADATA.MDA.KALENDERVERWERKING_");
                    query.Append(Period == Utility.PERIOD.MAAND ? "MAAND" : "DAG");
                    query.Append(" SET ");

                    foreach (clsRunDetail rd in RunDetailList)
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
        */
        /*
        private string FormatDate4DB(DateTime date)
        {
            return String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
        }
*/
        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            GenerateUpdateScript(false);
            /*
                       string query = GenerateUpdateQuery();
                       if (query.Length > 0)
                       {
                           QueryOutputForm queryForm = new QueryOutputForm(query.ToString());
                           queryForm.Show();
                       }
                       else
                           MessageBox.Show("Nothing to update!");

             */
        }

        private void btnAbortRun_Click(object sender, EventArgs e)
        {
            AbortRun();
            /*
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

                            string abortRunQuery = SQLQueries.SQL_ABORT_RUN.Replace("<RunID>", SsisRunID.ToString());
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
            */
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GenerateUpdateScript(true);
            /*            string query = GenerateUpdateQuery();
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
 
             */
        }
    }
}
