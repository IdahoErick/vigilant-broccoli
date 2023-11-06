//To do list:
// - Check Informatica services are up
// - Encrypt Infa pmcmd password (see http://weblogs.asp.net/jgalloway/archive/2008/04/13/encrypting-passwords-in-a-net-app-config-file.aspx)
// - Check the ACISDW FIQ Status flag

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using BIFramework;
using System.Configuration;

namespace BIMonitor
{
    public partial class Form1 : Form
    {
        private ArrayList _BIProcesses = new ArrayList();
        private LoadIBIProcess _loadIBIProcess = new LoadIBIProcess();
        private ELECReportFilesProcess _ELECReportFilesProcess = new ELECReportFilesProcess();
        private FIQBIProcess _FIQBIProcess = new FIQBIProcess();
        private PPEDataLoadProcess _PPEDataLoadProcess = new PPEDataLoadProcess();
        private ProjectionsProcess _projectionsProcess = new ProjectionsProcess();
        private CinciDataTransferProcess _cinciDataTransferProcess = new CinciDataTransferProcess();
        private CinciSavingsTransferProcess _cinciSavingsTransferProcess = new CinciSavingsTransferProcess();
        private Cognos8App _cognos8App = new Cognos8App();
        private InfaStatistics _Infa80ProdStats = new InfaStatistics("Informatica 8.1 Production", BaseDBAccess.DBType.Oracle, AIQConnectionStrings.ORA_INFREP_PROD, "SPOInfaProd_IS", "SPOInfaProd");
        private InfaStatistics _Infa80DevStats = new InfaStatistics("Informatica 8.1 Development", BaseDBAccess.DBType.Oracle, AIQConnectionStrings.ORA_INFREP_DEV, "INFA_IS", "AdvantageIQDev");
        private InfaStatistics _Infa86ProdStats = new InfaStatistics("Informatica 8.6 Production", BaseDBAccess.DBType.SQLServer, AIQConnectionStrings.SQL_INFAREP86_PROD, "SPOInfaProd_IS", "SPOInfaProd");
        private InfaStatistics _Infa86DevStats = new InfaStatistics("Informatica 8.6 Development", BaseDBAccess.DBType.SQLServer, AIQConnectionStrings.SQL_INFAREP86_DEV, "SPOInfaDev_IS", "SPOInfaDev");
        private PDSProcess _PDSProd = new PDSProcess("PDS Production", BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, "SPOInfaDev_IS", "SPOInfaDev");
        private PDSProcess _PDSDev = new PDSProcess("PDS Development", BIFramework.AIQConnectionStrings.SQL_INFAREP86_DEV, "SPOInfaDev_IS", "SPOInfaDev");
        private OracleDBAccess oDA = new OracleDBAccess();

        public const string WF_START_DATE_LABEL = "StartDate";
        public const string WF_STATUS_LABEL = "Status";

        private BIMonitor.Properties.Settings appSettings = new BIMonitor.Properties.Settings();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Add event handler for settings changes
            appSettings.SettingChanging += new SettingChangingEventHandler(appSettings_SettingChanging);
            propertyGrid1.SelectedObject = appSettings;
            System.Configuration.UserScopedSettingAttribute userAttr = new System.Configuration.UserScopedSettingAttribute();
            System.ComponentModel.AttributeCollection attrs = new System.ComponentModel.AttributeCollection(userAttr);
            propertyGrid1.BrowsableAttributes = attrs;

            // Add event handler for summary grid
            this.dgvStatusSummary.CellContentClick += new DataGridViewCellEventHandler(dgvStatusSummary_CellContentClick);

            // Add data grid views to process objects
/*
            _loadIBIProcess.AddGridView(eDWWfResultsTableDataGridView, _loadIBIProcess.GetEDWWorkflowData);
            _loadIBIProcess.AddGridView(dgvLatestEDWLoad, _loadIBIProcess.GetLatestEDWLoad);
            _loadIBIProcess.AddGridView(dgvLatestODSLoad, _loadIBIProcess.GetLatestODSLoad);
            _loadIBIProcess.AddGridView(dgvEDWMetrics, _loadIBIProcess.GetEDWMetrics);
            _loadIBIProcess.AddGridView(dgvODSMetrics, _loadIBIProcess.GetODSMetrics);
            _loadIBIProcess.AddGridView(dgvC8ReportsRan, _loadIBIProcess.GetNumberC8ReportsRan);
            _projectionsProcess.AddGridView(dgvProjections, _projectionsProcess.GetProjectionsRuns);
            _projectionsProcess.AddGridView(dgvProjectionsLoads, _projectionsProcess.GetLatestDataLoads);
            _cinciDataTransferProcess.AddGridView(dgvCinciDataLoads, _cinciDataTransferProcess.GetLatestCinciDataLoad);
            _cinciSavingsTransferProcess.AddGridView(dgvCinciSavingsLoads, _cinciSavingsTransferProcess.GetLatestCinciSavingsLoad);
            _ELECReportFilesProcess.AddGridView(dgvELECFiles, _ELECReportFilesProcess.UpdateELECFilesListView);
            _PPEDataLoadProcess.AddGridView(dgvPPEDataLoad, _PPEDataLoadProcess.GetLatestDataLoads);
            _Infa80ProdStats.AddGridView(dgvWFLastWeek, _Infa80ProdStats.GetWFPast7Days);
            _Infa80ProdStats.AddGridView(dgvProdWFScheduled, _Infa80ProdStats.GetWFScheduled);
            _Infa80ProdStats.AddGridView(dgvProdWFRunning, _Infa80ProdStats.GetWFRunning);
            _Infa80DevStats.AddGridView(dgvDevWFPast7Days, _Infa80DevStats.GetWFPast7Days);
            _Infa80DevStats.AddGridView(dgvDevWFScheduled, _Infa80DevStats.GetWFScheduled);
            _Infa80DevStats.AddGridView(dgvDevWFRunning, _Infa80DevStats.GetWFRunning);
            _Infa86ProdStats.AddGridView(dgvProd86WFLastWeek, _Infa86ProdStats.GetWFPast7Days);
            _Infa86ProdStats.AddGridView(dgvProd86WFScheduled, _Infa86ProdStats.GetWFScheduled);
            _Infa86ProdStats.AddGridView(dgvProd86WFRunning, _Infa86ProdStats.GetWFRunning);
            _Infa86DevStats.AddGridView(dgvDev86WFLastWeek, _Infa86DevStats.GetWFPast7Days);
            _Infa86DevStats.AddGridView(dgvDev86WFScheduled, _Infa86DevStats.GetWFScheduled);
            _Infa86DevStats.AddGridView(dgvDev86WFRunning, _Infa86DevStats.GetWFRunning);
            _PDSProd.AddGridView(dgvPDSProdLatestestWfs, _PDSProd.GetLatestPDSRun);
            _PDSDev.AddGridView(dgvPDSDevLatestWfs, _PDSDev.GetLatestPDSRun);
            _FIQBIProcess.AddGridView(dgvFIQBISummary, _FIQBIProcess.GetFIQBISummary);

            // Add web pages
            _FIQBIProcess.AddWebPages("ADVBI2", wbADVBI2);
            _FIQBIProcess.AddWebPages("ADVBI3", wbADVBI3);
            _FIQBIProcess.AddWebPages("ADVCOG1", wbADVCOG1);
            _FIQBIProcess.AddWebPages("ADVIBI2", wbADVIBI2);
            _cognos8App.AddWebPages("Cognos 8", webBrowserCognos8);

            _FIQBIProcess.StatusUpdateEvent += new BaseProcess.StatusUpdatedEventHandler(_FIQBIProcess_StatusUpdateEvent);
            _cognos8App.StatusUpdateEvent += new BaseProcess.StatusUpdatedEventHandler(_cognos8App_StatusUpdateEvent);

            _ELECReportFilesProcess.ELECFilesLogFile = tbELECFilesLogFile;

            // Add processes to process array
            _BIProcesses.Add(_loadIBIProcess);
            _BIProcesses.Add(_ELECReportFilesProcess);
            _BIProcesses.Add(_FIQBIProcess);
            _BIProcesses.Add(_PPEDataLoadProcess);
            _BIProcesses.Add(_projectionsProcess);
            _BIProcesses.Add(_cinciDataTransferProcess);
            _BIProcesses.Add(_cinciSavingsTransferProcess);
            _BIProcesses.Add(_cognos8App);
            _BIProcesses.Add(_Infa86ProdStats);
            //_BIProcesses.Add(_Infa86DevStats);
            //_BIProcesses.Add(_Infa80DevStats);
            _BIProcesses.Add(_PDSProd);
            _BIProcesses.Add(_PDSDev);
            _PDSDev.ShowSummaryStatus = false;  // don't show the process in the summary grid

            // Add scheduled workflows to Infa objects
            //_Infa86ProdStats.AddRequiredScheduledWorkflow("Cincinnati Data Transfer", "wf_DataTransfer_Daily");
            //_Infa86ProdStats.AddRequiredScheduledWorkflow("Cincinnati Data Transfer", "wf_ImageTransfer_Daily");
            _Infa86ProdStats.AddRequiredScheduledWorkflow("Data Warehouse", "wf_EDW_DataLoad");
            _Infa86ProdStats.AddRequiredScheduledWorkflow("Operational Data Store", "wf_ODS_DataLoad_IDL");
            _Infa86ProdStats.AddRequiredScheduledWorkflow("Production Data Subsetting", "wf_RunDataloads");
            _Infa86ProdStats.AddRequiredScheduledWorkflow("Savings Transfer To Cincinnati", "wf_SavingsTransfer_Daily");
            _Infa86ProdStats.AddRequiredScheduledWorkflow("Telecom - Interm", "wf_SiteAccount");

            //_Infa86DevStats.AddRequiredScheduledWorkflow("Production Data Subsetting", "wf_RunDataloads");
*/
            //BuildSummaryStatusDataset();
            timerRefresh.Interval = 60000 * appSettings.RefreshRateMin;
            timerRefresh.Start();

            // Propagate app settings to all processes
            UpdateAppSettings(null);

            RefreshFormData();
        }

        private void btnRefreshSummary_Click(object sender, EventArgs e)
        {
            RefreshFormData();
        }

        private void RefreshFormData()
        {
            foreach (BaseProcess p in _BIProcesses)
            {
                p.RefreshTabData();
            }
            UpdateSummaryStatus();
        }

        private void UpdateSummaryStatus()
        {
            dgvStatusSummary.Rows.Clear();
            foreach (BaseProcess p in _BIProcesses)
            {
                if (p.ShowSummaryStatus == true)
                {
                    int newRowIndex = dgvStatusSummary.Rows.Add();
                    dgvStatusSummary.Rows[newRowIndex].Cells[0].Value = p.ProcessName;
                    BaseProcess.ProcessStatus currentStatus = p.GetCurrentStatus();
                    dgvStatusSummary.Rows[newRowIndex].Cells[1].Value = currentStatus.ToString();
                }
            }
            lblLastUpdated.Text = "Last updated: " + DateTime.Now.ToLongTimeString();
        }

        private void dgvStatusSummary_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStatusSummary.Columns[e.ColumnIndex].Name == "StatusColumn")
            {
                if (e.Value != null)
                {
                    // Convert column value to enum
                    BaseProcess.ProcessStatus s = (BaseProcess.ProcessStatus)Enum.Parse(typeof(BaseProcess.ProcessStatus), e.Value.ToString());
                    // Set color based on value
                    switch (s)
                    {
                        case BaseProcess.ProcessStatus.Failed:
                            e.CellStyle.BackColor = Color.Red;
                            break;
                        case BaseProcess.ProcessStatus.Running:
                            e.CellStyle.BackColor = Color.Yellow;
                            break;
                        case BaseProcess.ProcessStatus.Success:
                            e.CellStyle.BackColor = Color.Green;
                            break;
                        case BaseProcess.ProcessStatus.UserActionRequired:
                            e.CellStyle.BackColor = Color.OrangeRed;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        // Go to tab page when user clicks on process name
        void dgvStatusSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvStatusSummary.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                string link = this.dgvStatusSummary[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (link == _loadIBIProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageIBI;
                else if (link == _ELECReportFilesProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabELECFiles;
                else if (link == _projectionsProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageProjections;
                else if (link == _cinciDataTransferProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageCinciDT;
                else if (link == _cinciSavingsTransferProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageSavings;
                else if (link == _PPEDataLoadProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPagePPEDataLoad;
                else if (link == _FIQBIProcess.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageFIQBI;
                else if (link == _cognos8App.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageCognos;
                else if (link == _Infa86ProdStats.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPageStatsProd86;
                else if (link == _PDSProd.ProcessName)
                    this.tabControl1.SelectedTab = this.tabPagePDSProd;
            }
        }


#region "FIQ"
        private void tabPageFIQBI_Enter(object sender, EventArgs e)
        {
            _FIQBIProcess.RefreshTabData();
        }
        private void wbADVBI2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _FIQBIProcess.UpdateWebPageStatus("ADVBI2");
        }

        private void wbADVBI3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _FIQBIProcess.UpdateWebPageStatus("ADVBI3");
        }

        private void wbADVIBI2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _FIQBIProcess.UpdateWebPageStatus("ADVIBI2");
        }

        private void wbADVCOG1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _FIQBIProcess.UpdateWebPageStatus("ADVCOG1");
        }
        void _FIQBIProcess_StatusUpdateEvent(object sender, BaseProcess.StatusUpdatedEventArgs e)
        {
            UpdateSummaryStatus();
        }
        private void dgvFIQBISummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvFIQBISummary.Columns["Date"].DefaultCellStyle.Format = "d";
            string dateFormat = "M/d/yyyy H:mm";
            this.dgvFIQBISummary.Columns["BI2Start"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["BI2End"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["BI3Start"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["BI3End"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["IBI2Start"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["IBI2End"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["COG1Start"].DefaultCellStyle.Format = dateFormat;
            this.dgvFIQBISummary.Columns["COG1End"].DefaultCellStyle.Format = dateFormat;
        }
#endregion

#region "IBI"
        private void tabPageIBI_Enter(object sender, EventArgs e)
        {
            _loadIBIProcess.RefreshTabData();
        }
        private void eDWWfResultsTableDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (eDWWfResultsTableDataGridView.Columns[e.ColumnIndex].Name == "STATUS")
            {
                if (e.Value != null)
                {
                    e.Value = _loadIBIProcess.GetWorkflowStatusDescription(e.Value.ToString());
                }
            }
        }
        private void dgvLatestODSLoad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLatestODSLoad.Columns[e.ColumnIndex].Name == "STATUS")
            {
                if (e.Value != null)
                {
                    e.Value = _loadIBIProcess.GetWorkflowStatusDescription(e.Value.ToString());
                }
            }
        }
        private void dgvLatestEDWLoad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLatestEDWLoad.Columns[e.ColumnIndex].Name == "STATUS")
            {
                if (e.Value != null)
                {
                    e.Value = _loadIBIProcess.GetWorkflowStatusDescription(e.Value.ToString());
                }
            }
        }

#endregion

#region "Informatica"
        private void tabPageStatsProd_Enter(object sender, EventArgs e)
        {
            _Infa80ProdStats.RefreshTabData();
        }

        private void tabStatsDev_Enter(object sender, EventArgs e)
        {
            _Infa80DevStats.RefreshTabData();
        }
        private void tabPageStatsProd86_Enter(object sender, EventArgs e)
        {
            _Infa86ProdStats.RefreshTabData();
        }
        private void tabPageInfa86Dev_Enter(object sender, EventArgs e)
        {
            _Infa86DevStats.RefreshTabData();
        }
        private void dgvProd86WFScheduled_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            tbSelectedWorkflow.Text = dgvProd86WFScheduled.Rows[e.RowIndex].Cells["task_name"].Value.ToString();
        }
        private void btnScheduleWorkflow_Click(object sender, EventArgs e)
        {
            string workflowName = tbSelectedWorkflow.Text;  // get the selected workflow name so it does not change if grid is refreshed
            if (MessageBox.Show("Do you want to schedule workflow " + workflowName + "?", "Schedule workflow", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Schedule selected workflow
                _Infa86ProdStats.ScheduleWorkflow(workflowName);
                //System.Threading.Thread.Sleep(5000); // give Informatica service some time to process
                _Infa86ProdStats.RefreshTabData();
            }
        }
#endregion

#region "Projections"
        private void tabPageProjections_Enter(object sender, EventArgs e)
        {
            _projectionsProcess.RefreshTabData();
        }
#endregion

#region "Cincinnati Data Transfer"
        private void tabPageCinciDT_Enter(object sender, EventArgs e)
        {
            _cinciDataTransferProcess.RefreshTabData();
        }
        private void dgvCinciDataLoads_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCinciDataLoads.Columns[e.ColumnIndex].Name == "STATUS")
            {
                if (e.Value != null)
                {
                    e.Value = _cinciDataTransferProcess.GetWorkflowStatusDescription(e.Value.ToString());
                }
            }
        }

 

#endregion

#region "Cincinnati Savings Transfer"

    private void tabPageCinciST_Enter(object sender, EventArgs e)
    {
        _cinciSavingsTransferProcess.RefreshTabData();
    }

    private void dgvCinciSavingsLoads_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvCinciSavingsLoads.Columns[e.ColumnIndex].Name == WF_STATUS_LABEL)
        {
            if (e.Value != null)
            {
                e.Value = _cinciSavingsTransferProcess.GetWorkflowStatusDescription(e.Value.ToString());
            }
        }
    }

#endregion

#region "ELEC Files"
        private void tabELECFiles_Enter(object sender, EventArgs e)
        {
            _ELECReportFilesProcess.RefreshTabData();
        }

        private void dgvELECFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvELECFiles.Columns[e.ColumnIndex].Name == "Date Modified")
            {
                if (e.Value != null)
                {
                    if (_ELECReportFilesProcess.IsCurrentFile((DateTime)e.Value)==false)
                        e.CellStyle.BackColor = Color.Red;
                }
            }
        }
#endregion

#region "PPE Data Load"
    private void dgvPPEDataLoad_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvPPEDataLoad.Columns[e.ColumnIndex].Name == "STATUS")
        {
            if (e.Value != null)
            {
                e.Value = _PPEDataLoadProcess.GetWorkflowStatusDescription(e.Value.ToString());
            }
        }
    }

#endregion

#region "Cognos 8"
    void _cognos8App_StatusUpdateEvent(object sender, BaseProcess.StatusUpdatedEventArgs e)
    {
        UpdateSummaryStatus();
    }
    private void webBrowserCognos8_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        _cognos8App.UpdateWebPageStatus("Cognos 8");
    }
#endregion

#region PDSProd
    private void dgvPDSProdLatestestWfs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dgvPDSProdLatestestWfs.Columns[e.ColumnIndex].Name == WF_STATUS_LABEL)
        {
            if (e.Value != null)
            {
                e.Value = _PDSProd.GetWorkflowStatusDescription(e.Value.ToString());
            }
        }
    }
#endregion

    #region "Utility functions"

    private DataView GetDataView(DataSet viewDataSet)
        {
            return viewDataSet.Tables[0].DefaultView;
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshFormData();
        }

#endregion

        private void dgvDev86WFScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDev86WFScheduled.Columns[e.ColumnIndex].Name == WF_START_DATE_LABEL)
            {
                if ((e.Value != null) && ((e.Value.ToString() == InfaStatistics.NOT_SCHEDULED_LABEL) || (e.Value.ToString() == InfaStatistics.UNSCHEDULED_LABEL)))
                    e.CellStyle.BackColor = Color.Red;
            }
        }

        private void dgvProd86WFScheduled_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProd86WFScheduled.Columns[e.ColumnIndex].Name == WF_START_DATE_LABEL)
            {
                if ((e.Value != null) && ((e.Value.ToString() == InfaStatistics.NOT_SCHEDULED_LABEL) || (e.Value.ToString() == InfaStatistics.UNSCHEDULED_LABEL)))
                    e.CellStyle.BackColor = Color.Red;
            }
        }
#region PDSTest
        private void btnTruncateTables_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void btnStartPDSDevWorkflow_Click(object sender, EventArgs e)
        {
            _PDSDev.StartWorkflow("Production Data Subsetting", "wf_RunDataLoads");
        }
        private void btnRefreshInfaDev_Click(object sender, EventArgs e)
        {
            _PDSDev.RefreshTabData();
        }

        private void btnPDSLoadMetadata_Click(object sender, EventArgs e)
        {
            _PDSDev.StartWorkflow("Production Data Subsetting", "wf_LoadMetadata");
        }
        private void btnPDSLoadFilterLinkages_Click(object sender, EventArgs e)
        {
            _PDSDev.StartWorkflow("Production Data Subsetting", "wf_FilterLinkages_Load");
        }

#endregion

        void appSettings_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            UpdateAppSettings(e);
        }

        // Update the application settings and all related objects
        private void UpdateAppSettings(System.Configuration.SettingChangingEventArgs e)
        {
            foreach (BaseProcess p in _BIProcesses)
                p.AppSettings = appSettings;
            // Also set app setting s for Infa development process, which is not in standard BI processes array
            _Infa86DevStats.AppSettings = appSettings;

            if ((e != null) && (e.SettingName == "RefreshRateMin"))
                ChangeRefreshTimer(Convert.ToInt16(e.NewValue));
        }

        // Timer refresh rate has been changed: reset timer
        private void ChangeRefreshTimer(int refreshRateInMin)
        {
            timerRefresh.Interval = refreshRateInMin * 60000;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            appSettings.Save();
        }

    
    }
}
