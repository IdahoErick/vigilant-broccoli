/*
 * Backlog:
 * - Create form to get overview of all files available in IN map
 * - From Detail form, start local run
 * - From Detail form, generate script to update kalender with new settings
 * - From Dashboard form switch to clicked process
 * - Go to previous runs
 * - Add problem solving text (with link to wiki?)
 */ 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

namespace DIMonitor
{
    public partial class MainForm : Form
    {
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private bool _initialized = false;
        private string _lastStep = "";
        private string _status = "";
        //private bool _showDetails = false;
        private DateTime _kalenderDatum = DateTime.Now;
        private DIMonitor.Properties.Settings _appSettings = new DIMonitor.Properties.Settings();
        private LogBoekForm _logBoekForm;
        private RunDetailLogForm _runDetailLogForm;
        private SSISLogForm _ssisLogForm;
        private SourceFilesForm _sourceFilesForm;
        private Int64 _SSISRunID;
        private int _runID;

        
        [DllImport("user32.dll")]
        public static extern int FlashWindow(IntPtr Hwnd, bool Revert);

        // Add form's resize event to judge whether a form has been minimized or not.

        public MainForm()
        {
            InitializeComponent();
            cbEnvironment.SelectedIndex = (int)Utility.ENV.LOCAL;
            cbPeriod.SelectedIndex = (int)Utility.PERIOD.DAG;
            cbBU.SelectedIndex = (int)Utility.BU.ILVB;
            _initialized = true;

            this.Text = "DI Monitor (" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + ")";

            timer1.Interval = Properties.Settings.Default.RefreshTime*1000;

            // Add event handler for settings changes
            _appSettings.SettingChanging += new SettingChangingEventHandler(appSettings_SettingChanging);

            RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RefreshData()==-1)
                MessageBox.Show("Select an environment first");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int rc = RefreshData();
            
            // Set form on top if checkbox is checked or there is new info
            if (cbOnTop.Checked == true || rc == 1)
            {
                this.TopMost = true;
                FlashWindow(this.Handle, false);
                //this.FlashWindow(FlashOptions.ALL, True, 5)  
            }
            else
                this.TopMost = false;

            // Refresh logboek
            if (_logBoekForm != null)
                _logBoekForm.Refresh();

            // Refresh logboek
            if (_runDetailLogForm != null)
                _runDetailLogForm.Refresh();
        }

        private int RefreshData()
        {
            string cs;
            int rc = 0;
            bool bNewInfo = false;
            tssLabel.Text = "";
 
            if (_initialized == true)
            {
                string BUPart = cbBU.SelectedIndex == (int)Utility.BU.ILVB ? "ILH" : "ILSB";
                //string periodPart = cbPeriod.SelectedIndex == (int)Utility.PERIOD.DAG ? "DAG" : "MAAND";
                //string databasePart = "; Database=" + BUPart + "_LOGGING_" + periodPart;
                string statusQuery = (BUPart == "ILH" ? SQLQueries.SQL_RUN_STATUS_ILH : SQLQueries.SQL_RUN_STATUS_ILSB);

                Utility.ENV env = (Utility.ENV)cbEnvironment.SelectedIndex;
                Utility.BU bu = (Utility.BU)cbBU.SelectedIndex;
                Utility.PERIOD period = (Utility.PERIOD)cbPeriod.SelectedIndex;
                cs = Utility.GetConnectionString((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, false);

                if (cs != "")
                {
                    string runStatus = "Unknown";
                    try
                    {
                        DataSet ds = _sqlDA.GetQueryDataSet(cs, statusQuery, false);

                        // set process status
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _runID = (int)(ds.Tables[0].Rows[0]["RunID"]);
                            runStatus = ds.Tables[0].Rows[0]["RunStatus"].ToString();
                            lblResult.Text = runStatus;
                            if (runStatus != _status)
                                bNewInfo = true;
                            _status = runStatus;

                            _kalenderDatum = Convert.ToDateTime(ds.Tables[0].Rows[0]["KalenderDatum"]);
                            lblKalenderDatum.Text = _kalenderDatum.ToString("dd-MM-yyyy");
                            lblBeginDTM.Text = ds.Tables[0].Rows[0]["StartDatumTijd"].ToString();
                            lblEndDTM.Text = ds.Tables[0].Rows[0]["EindDatumTijd"].ToString();
                            _SSISRunID = Convert.ToInt64(ds.Tables[0].Rows[0]["Execution_ID"]);
                            lblSSISRunID.Text = _SSISRunID.ToString();
                            // Set label background color depending on the SSIS status
                            //Created (1), running (2), canceled (3), failed (4), pending (5), ended unexpectedly (6), succeeded (7), stopping (8), and completed (9).
                            Color c = Color.Transparent;
                            string toolTipText = "";
                            if (ds.Tables[0].Rows[0]["SSISStatus"] != DBNull.Value)
                            {
                                switch (Convert.ToInt16(ds.Tables[0].Rows[0]["SSISStatus"]))
                        	    {
                                    case 1: 
                                        c = Color.Aqua;
                                        toolTipText="Created (1)";
                                        break;
                                    case 2:
                                        c = Color.SkyBlue;
                                        toolTipText = "Running (2)";
                                        break;
                                    case 3:
                                        c = Color.Yellow;
                                        toolTipText = "Canceled (3)";
                                        break;
                                    case 4:
                                        c = Color.Red;
                                        toolTipText = "Failed (4)";
                                        break;
                                    case 5:
                                        c = Color.Orange;
                                        toolTipText = "Pending (5)";
                                        break;
                                    case 6:
                                        c = Color.Purple;
                                        toolTipText = "Ended unexpectedly (6)";
                                        break;
                                    case 7:
                                        c = Color.LightGreen;
                                        toolTipText = "Succeeded (7)";
                                        break;
                                    case 8:
                                        c = Color.Blue;
                                        toolTipText = "Stopping (8)";
                                        break;
                                    case 9:
                                        c = Color.YellowGreen;
                                        toolTipText = "Completed (9)";
                                        break;
                                    default:
                                        c = Color.Pink;
                                        toolTipText = "Status Unknown";
                                        break;

	                            }
                            }
                            lblSSISRunID.BackColor = c;
                            System.Windows.Forms.ToolTip SSISStatusToolTip = new System.Windows.Forms.ToolTip();
                            SSISStatusToolTip.SetToolTip(lblSSISRunID, toolTipText);
                            //lblLatestSSISMessage.Text = GetLatestSSISMessage(cs, _SSISRunID);

                            if (ds.Tables[0].Rows[0]["PeilDatum"].ToString() != "")
                                lblPeilDatum.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["PeilDatum"]).ToString("dd-MM-yyyy");
                            else
                                lblPeilDatum.Text = "";
                            if (ds.Tables[0].Rows[0]["Stepomschrijving"].ToString() != "")
                                lblLastStep.Text = ds.Tables[0].Rows[0]["Stepomschrijving"].ToString();
                            else
                                lblLastStep.Text = "";
                            if (lblLastStep.Text != _lastStep)
                                bNewInfo = true;
                            _lastStep = lblLastStep.Text;

                            lblControleType.Text = ds.Tables[0].Rows[0]["ControleType"].ToString();
                            lblPackage.Text = ds.Tables[0].Rows[0]["Packagenaam"].ToString();
                            lblDetailDTM.Text = ds.Tables[0].Rows[0]["DetailDTM"].ToString();
                            lblOpmerkingen.Text = ds.Tables[0].Rows[0]["Opmerkingen"].ToString();
                            lblBronsysteem.Text = ds.Tables[0].Rows[0]["Bronsysteem"].ToString();


  
                        }
                        else
                            ReportMessage("There is no run information available", "Info");
                    }
                    catch(Exception e)
                    {
                        ReportMessage(e.Message, "Error");
                    };

                    if (runStatus == "OK")
                    {
                        lblResult.BackColor = Color.LightGreen;
                    }
                    else if (runStatus == "NOK")
                    {
                        lblResult.BackColor = Color.Red;
                    }
                    else
                    {
                        lblResult.BackColor = Color.Yellow;
                    }

                    lblLastRefreshDTM.Text = DateTime.Now.ToString();

                    if (bNewInfo == true)
                        rc = 1;
                }
                else
                    rc = -1;
            }
            return rc;
        }

        private void cbEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void cbBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utility.BU bu = (Utility.BU)cbBU.SelectedIndex;
            btnRunDetails.Enabled = (bu == Utility.BU.ILVB);
            RefreshData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cbOnTop.Checked;
        }

        private void btnRunDetails_Click(object sender, EventArgs e)
        {
            Utility.ENV env = (Utility.ENV)cbEnvironment.SelectedIndex;
            Utility.BU bu = (Utility.BU)cbBU.SelectedIndex;
            Utility.PERIOD period = (Utility.PERIOD)cbPeriod.SelectedIndex;

            RunDetailsForm runDetailsForm = new RunDetailsForm(env, bu, period, _kalenderDatum, _SSISRunID);
            runDetailsForm.ShowDialog();
            RefreshData();
        }

        private void btnTroubleshooting_Click(object sender, EventArgs e)
        {
            Utility.ENV env = (Utility.ENV)cbEnvironment.SelectedIndex;
            Utility.BU bu = (Utility.BU)cbBU.SelectedIndex;
            Utility.PERIOD period = (Utility.PERIOD)cbPeriod.SelectedIndex;

            TroublehsootingForm tsForm = new TroublehsootingForm(env, bu, period, _kalenderDatum);
            tsForm.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.ShowDialog();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.AppSettings = _appSettings;
            settingsForm.ShowDialog();

        }

        private void setLocalAdminPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPasswordForm passwordForm = new SetPasswordForm();
            passwordForm.ShowDialog();
        }

        private void logBoekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logBoekForm = new LogBoekForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex);
            _logBoekForm.ShowDialog();
        }

        void appSettings_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            UpdateAppSettings(e);
        }

        // Update the application settings and all related objects
        private void UpdateAppSettings(System.Configuration.SettingChangingEventArgs e)
        {
            if ((e != null) && (e.SettingName == "RefreshTime"))
                ChangeRefreshTimer(Convert.ToInt16(e.NewValue));
        }

        private void ChangeRefreshTimer(short p)
        {
            timer1.Interval = p*1000;
        }

        private void transferDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferDataForm transferDataForm = new TransferDataForm();
            transferDataForm.Show();
        }

        private void runDetailLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _runDetailLogForm = new RunDetailLogForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, _runID);
            _runDetailLogForm.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _appSettings.Save();
        }

        private string GetLatestSSISMessage(string connectionString, Int64 SSISRunID)
        {
            string message = "";
            if ((SSISRunID > 0) && (connectionString != ""))
            {
                DataSet ds = _sqlDA.GetQueryDataSet(connectionString, SQLQueries.SQL_LATEST_SSIS_MESSAGE.Replace("<RunID>", SSISRunID.ToString()), false);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    message = ds.Tables[0].Rows[0]["execution_path"].ToString();
                }
            }
            return message;
        }

        private void btnSSISRefresh_Click(object sender, EventArgs e)
        {
            //Utility.ENV env = (Utility.ENV)cbEnvironment.SelectedIndex;
            //Utility.BU bu = (Utility.BU)cbBU.SelectedIndex;
            //Utility.PERIOD period = (Utility.PERIOD)cbPeriod.SelectedIndex;
            string cs = Utility.GetConnectionString((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, false);

            lblLatestSSISMessage.Text = GetLatestSSISMessage(cs, _SSISRunID);
        }

        private void ReportMessage(string message, string messageType)
        {
            tssLabel.Text = message;
            if (messageType == "Error")
                tssLabel.BackColor = Color.Red;
            else
                tssLabel.BackColor = Color.Transparent;
        }

        private void logBoekToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _logBoekForm = new LogBoekForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex);
            _logBoekForm.ShowDialog();
        }

        private void runDetailLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _runDetailLogForm = new RunDetailLogForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, _runID);
            _runDetailLogForm.ShowDialog();
        }

        private void sSISLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ssisLogForm = new SSISLogForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, _SSISRunID);
            _ssisLogForm.ShowDialog();
        }

        private void sourceFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sourceFilesForm = new SourceFilesForm((Utility.ENV)cbEnvironment.SelectedIndex, (Utility.BU)cbBU.SelectedIndex, (Utility.PERIOD)cbPeriod.SelectedIndex, _SSISRunID);
            _sourceFilesForm.ShowDialog();
        }
                        

    }
}
