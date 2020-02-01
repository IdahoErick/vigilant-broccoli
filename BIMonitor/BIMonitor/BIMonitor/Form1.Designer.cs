namespace BIMonitor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.btnRefreshSummary = new System.Windows.Forms.Button();
            this.dgvStatusSummary = new System.Windows.Forms.DataGridView();
            this.ProcessColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageFIQBI = new System.Windows.Forms.TabPage();
            this.wbADVBI3 = new System.Windows.Forms.WebBrowser();
            this.wbADVIBI2 = new System.Windows.Forms.WebBrowser();
            this.wbADVCOG1 = new System.Windows.Forms.WebBrowser();
            this.dgvFIQBISummary = new System.Windows.Forms.DataGridView();
            this.wbADVBI2 = new System.Windows.Forms.WebBrowser();
            this.tabPageIBI = new System.Windows.Forms.TabPage();
            this.label81 = new System.Windows.Forms.Label();
            this.dgvC8ReportsRan = new System.Windows.Forms.DataGridView();
            this.dgvEDWMetrics = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvODSMetrics = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eDWWfResultsTableDataGridView = new System.Windows.Forms.DataGridView();
            this.dgvLatestEDWLoad = new System.Windows.Forms.DataGridView();
            this.dgvLatestODSLoad = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageProjections = new System.Windows.Forms.TabPage();
            this.dgvProjectionsLoads = new System.Windows.Forms.DataGridView();
            this.label52 = new System.Windows.Forms.Label();
            this.dgvProjections = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageCinciDT = new System.Windows.Forms.TabPage();
            this.dgvCinciDataLoads = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPageSavings = new System.Windows.Forms.TabPage();
            this.dgvCinciSavingsLoads = new System.Windows.Forms.DataGridView();
            this.label51 = new System.Windows.Forms.Label();
            this.tabPagePPEDataLoad = new System.Windows.Forms.TabPage();
            this.dgvPPEDataLoad = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.tabELECFiles = new System.Windows.Forms.TabPage();
            this.tbELECFilesLogFile = new System.Windows.Forms.TextBox();
            this.dgvELECFiles = new System.Windows.Forms.DataGridView();
            this.tabPageStatsProd = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWFLastWeek = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvProdWFScheduled = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProdWFRunning = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabStatsDev = new System.Windows.Forms.TabPage();
            this.dgvDevWFPast7Days = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDevWFScheduled = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDevWFRunning = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageCognos = new System.Windows.Forms.TabPage();
            this.webBrowserCognos8 = new System.Windows.Forms.WebBrowser();
            this.tabPageStatsProd86 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbSelectedWorkflow = new System.Windows.Forms.TextBox();
            this.btnScheduleWorkflow = new System.Windows.Forms.Button();
            this.label79 = new System.Windows.Forms.Label();
            this.dgvProd86WFLastWeek = new System.Windows.Forms.DataGridView();
            this.label45 = new System.Windows.Forms.Label();
            this.dgvProd86WFScheduled = new System.Windows.Forms.DataGridView();
            this.label46 = new System.Windows.Forms.Label();
            this.dgvProd86WFRunning = new System.Windows.Forms.DataGridView();
            this.label47 = new System.Windows.Forms.Label();
            this.tabPageInfa86Dev = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dgvDev86WFLastWeek = new System.Windows.Forms.DataGridView();
            this.label48 = new System.Windows.Forms.Label();
            this.dgvDev86WFScheduled = new System.Windows.Forms.DataGridView();
            this.label49 = new System.Windows.Forms.Label();
            this.dgvDev86WFRunning = new System.Windows.Forms.DataGridView();
            this.label50 = new System.Windows.Forms.Label();
            this.tabPagePDSProd = new System.Windows.Forms.TabPage();
            this.dgvPDSProdLatestestWfs = new System.Windows.Forms.DataGridView();
            this.label76 = new System.Windows.Forms.Label();
            this.tabPagePDSDev = new System.Windows.Forms.TabPage();
            this.btnPDSLoadFilterLinkages = new System.Windows.Forms.Button();
            this.btnPDSLoadMetadata = new System.Windows.Forms.Button();
            this.btnRefreshInfaDev = new System.Windows.Forms.Button();
            this.dgvPDSDevLatestWfs = new System.Windows.Forms.DataGridView();
            this.label80 = new System.Windows.Forms.Label();
            this.btnStartPDSDevWorkflow = new System.Windows.Forms.Button();
            this.tbOracleIPAddress = new System.Windows.Forms.MaskedTextBox();
            this.tbSQLServerIPAddress = new System.Windows.Forms.MaskedTextBox();
            this.btnSchedulePDSWorkflow = new System.Windows.Forms.Button();
            this.btnSetupTrainingDL = new System.Windows.Forms.Button();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.btnTruncateTables = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button3 = new System.Windows.Forms.Button();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.webBrowser4 = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.label23 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView10 = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView11 = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.dataGridView12 = new System.Windows.Forms.DataGridView();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGridView13 = new System.Windows.Forms.DataGridView();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.dataGridView14 = new System.Windows.Forms.DataGridView();
            this.label27 = new System.Windows.Forms.Label();
            this.dataGridView15 = new System.Windows.Forms.DataGridView();
            this.label28 = new System.Windows.Forms.Label();
            this.dataGridView16 = new System.Windows.Forms.DataGridView();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.webBrowser5 = new System.Windows.Forms.WebBrowser();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView17 = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.webBrowser6 = new System.Windows.Forms.WebBrowser();
            this.button5 = new System.Windows.Forms.Button();
            this.webBrowser7 = new System.Windows.Forms.WebBrowser();
            this.webBrowser8 = new System.Windows.Forms.WebBrowser();
            this.webBrowser9 = new System.Windows.Forms.WebBrowser();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.dataGridView18 = new System.Windows.Forms.DataGridView();
            this.label31 = new System.Windows.Forms.Label();
            this.dataGridView19 = new System.Windows.Forms.DataGridView();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.dataGridView20 = new System.Windows.Forms.DataGridView();
            this.dataGridView21 = new System.Windows.Forms.DataGridView();
            this.dataGridView22 = new System.Windows.Forms.DataGridView();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.dataGridView23 = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.dataGridView24 = new System.Windows.Forms.DataGridView();
            this.label37 = new System.Windows.Forms.Label();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.dataGridView25 = new System.Windows.Forms.DataGridView();
            this.label38 = new System.Windows.Forms.Label();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView26 = new System.Windows.Forms.DataGridView();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView27 = new System.Windows.Forms.DataGridView();
            this.label39 = new System.Windows.Forms.Label();
            this.dataGridView28 = new System.Windows.Forms.DataGridView();
            this.label40 = new System.Windows.Forms.Label();
            this.dataGridView29 = new System.Windows.Forms.DataGridView();
            this.label41 = new System.Windows.Forms.Label();
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.dataGridView30 = new System.Windows.Forms.DataGridView();
            this.label42 = new System.Windows.Forms.Label();
            this.dataGridView31 = new System.Windows.Forms.DataGridView();
            this.label43 = new System.Windows.Forms.Label();
            this.dataGridView32 = new System.Windows.Forms.DataGridView();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.webBrowser10 = new System.Windows.Forms.WebBrowser();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.label53 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView33 = new System.Windows.Forms.DataGridView();
            this.dataGridViewLinkColumn3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage23 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.webBrowser11 = new System.Windows.Forms.WebBrowser();
            this.button7 = new System.Windows.Forms.Button();
            this.webBrowser12 = new System.Windows.Forms.WebBrowser();
            this.webBrowser13 = new System.Windows.Forms.WebBrowser();
            this.webBrowser14 = new System.Windows.Forms.WebBrowser();
            this.tabPage24 = new System.Windows.Forms.TabPage();
            this.dataGridView34 = new System.Windows.Forms.DataGridView();
            this.label54 = new System.Windows.Forms.Label();
            this.dataGridView35 = new System.Windows.Forms.DataGridView();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.dataGridView36 = new System.Windows.Forms.DataGridView();
            this.dataGridView37 = new System.Windows.Forms.DataGridView();
            this.dataGridView38 = new System.Windows.Forms.DataGridView();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tabPage25 = new System.Windows.Forms.TabPage();
            this.dataGridView39 = new System.Windows.Forms.DataGridView();
            this.label59 = new System.Windows.Forms.Label();
            this.dataGridView40 = new System.Windows.Forms.DataGridView();
            this.label60 = new System.Windows.Forms.Label();
            this.tabPage26 = new System.Windows.Forms.TabPage();
            this.dataGridView41 = new System.Windows.Forms.DataGridView();
            this.label61 = new System.Windows.Forms.Label();
            this.tabPage27 = new System.Windows.Forms.TabPage();
            this.dataGridView42 = new System.Windows.Forms.DataGridView();
            this.label62 = new System.Windows.Forms.Label();
            this.tabPage28 = new System.Windows.Forms.TabPage();
            this.dataGridView43 = new System.Windows.Forms.DataGridView();
            this.label63 = new System.Windows.Forms.Label();
            this.tabPage29 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGridView44 = new System.Windows.Forms.DataGridView();
            this.tabPage30 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dataGridView45 = new System.Windows.Forms.DataGridView();
            this.label64 = new System.Windows.Forms.Label();
            this.dataGridView46 = new System.Windows.Forms.DataGridView();
            this.label65 = new System.Windows.Forms.Label();
            this.dataGridView47 = new System.Windows.Forms.DataGridView();
            this.label66 = new System.Windows.Forms.Label();
            this.tabPage31 = new System.Windows.Forms.TabPage();
            this.dataGridView48 = new System.Windows.Forms.DataGridView();
            this.label67 = new System.Windows.Forms.Label();
            this.dataGridView49 = new System.Windows.Forms.DataGridView();
            this.label68 = new System.Windows.Forms.Label();
            this.dataGridView50 = new System.Windows.Forms.DataGridView();
            this.label69 = new System.Windows.Forms.Label();
            this.tabPage32 = new System.Windows.Forms.TabPage();
            this.webBrowser15 = new System.Windows.Forms.WebBrowser();
            this.tabPage33 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.dataGridView51 = new System.Windows.Forms.DataGridView();
            this.label70 = new System.Windows.Forms.Label();
            this.dataGridView52 = new System.Windows.Forms.DataGridView();
            this.label71 = new System.Windows.Forms.Label();
            this.dataGridView53 = new System.Windows.Forms.DataGridView();
            this.label72 = new System.Windows.Forms.Label();
            this.tabPage34 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.dataGridView54 = new System.Windows.Forms.DataGridView();
            this.label73 = new System.Windows.Forms.Label();
            this.dataGridView55 = new System.Windows.Forms.DataGridView();
            this.label74 = new System.Windows.Forms.Label();
            this.dataGridView56 = new System.Windows.Forms.DataGridView();
            this.label75 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusSummary)).BeginInit();
            this.tabPageFIQBI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFIQBISummary)).BeginInit();
            this.tabPageIBI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvC8ReportsRan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEDWMetrics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvODSMetrics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDWWfResultsTableDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestEDWLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestODSLoad)).BeginInit();
            this.tabPageProjections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectionsLoads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjections)).BeginInit();
            this.tabPageCinciDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinciDataLoads)).BeginInit();
            this.tabPageSavings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinciSavingsLoads)).BeginInit();
            this.tabPagePPEDataLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPEDataLoad)).BeginInit();
            this.tabELECFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvELECFiles)).BeginInit();
            this.tabPageStatsProd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWFLastWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdWFScheduled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdWFRunning)).BeginInit();
            this.tabStatsDev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFPast7Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFScheduled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFRunning)).BeginInit();
            this.tabPageCognos.SuspendLayout();
            this.tabPageStatsProd86.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFLastWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFScheduled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFRunning)).BeginInit();
            this.tabPageInfa86Dev.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFLastWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFScheduled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFRunning)).BeginInit();
            this.tabPagePDSProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDSProdLatestestWfs)).BeginInit();
            this.tabPagePDSDev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDSDevLatestWfs)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView16)).BeginInit();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView17)).BeginInit();
            this.tabPage13.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView22)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView23)).BeginInit();
            this.tabPage16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView24)).BeginInit();
            this.tabPage17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView25)).BeginInit();
            this.tabPage18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView26)).BeginInit();
            this.tabPage19.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView29)).BeginInit();
            this.tabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView32)).BeginInit();
            this.tabPage21.SuspendLayout();
            this.tabPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView33)).BeginInit();
            this.tabPage23.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView38)).BeginInit();
            this.tabPage25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView40)).BeginInit();
            this.tabPage26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView41)).BeginInit();
            this.tabPage27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView42)).BeginInit();
            this.tabPage28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView43)).BeginInit();
            this.tabPage29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView44)).BeginInit();
            this.tabPage30.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView47)).BeginInit();
            this.tabPage31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView50)).BeginInit();
            this.tabPage32.SuspendLayout();
            this.tabPage33.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView53)).BeginInit();
            this.tabPage34.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView56)).BeginInit();
            this.SuspendLayout();
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPageFIQBI);
            this.tabControl1.Controls.Add(this.tabPageIBI);
            this.tabControl1.Controls.Add(this.tabPageProjections);
            this.tabControl1.Controls.Add(this.tabPageCinciDT);
            this.tabControl1.Controls.Add(this.tabPageSavings);
            this.tabControl1.Controls.Add(this.tabPagePPEDataLoad);
            this.tabControl1.Controls.Add(this.tabELECFiles);
            this.tabControl1.Controls.Add(this.tabPageStatsProd);
            this.tabControl1.Controls.Add(this.tabStatsDev);
            this.tabControl1.Controls.Add(this.tabPageCognos);
            this.tabControl1.Controls.Add(this.tabPageStatsProd86);
            this.tabControl1.Controls.Add(this.tabPageInfa86Dev);
            this.tabControl1.Controls.Add(this.tabPagePDSProd);
            this.tabControl1.Controls.Add(this.tabPagePDSDev);
            this.tabControl1.Controls.Add(this.tabOptions);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(43, 19);
            this.tabControl1.Location = new System.Drawing.Point(7, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1100, 798);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage1.Controls.Add(this.lblLastUpdated);
            this.tabPage1.Controls.Add(this.btnRefreshSummary);
            this.tabPage1.Controls.Add(this.dgvStatusSummary);
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1044, 752);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Status";
            this.tabPage1.ToolTipText = "Process Status";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.AutoSize = true;
            this.lblLastUpdated.Location = new System.Drawing.Point(255, 419);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(79, 14);
            this.lblLastUpdated.TabIndex = 2;
            this.lblLastUpdated.Text = "Last  updated: ";
            // 
            // btnRefreshSummary
            // 
            this.btnRefreshSummary.Location = new System.Drawing.Point(703, 71);
            this.btnRefreshSummary.Name = "btnRefreshSummary";
            this.btnRefreshSummary.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshSummary.TabIndex = 1;
            this.btnRefreshSummary.Text = "Refresh";
            this.btnRefreshSummary.UseVisualStyleBackColor = true;
            this.btnRefreshSummary.Click += new System.EventHandler(this.btnRefreshSummary_Click);
            // 
            // dgvStatusSummary
            // 
            this.dgvStatusSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessColumn,
            this.StatusColumn});
            this.dgvStatusSummary.Location = new System.Drawing.Point(258, 71);
            this.dgvStatusSummary.Name = "dgvStatusSummary";
            this.dgvStatusSummary.ReadOnly = true;
            this.dgvStatusSummary.Size = new System.Drawing.Size(379, 345);
            this.dgvStatusSummary.TabIndex = 0;
            this.dgvStatusSummary.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStatusSummary_CellFormatting);
            // 
            // ProcessColumn
            // 
            this.ProcessColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProcessColumn.HeaderText = "Process";
            this.ProcessColumn.Name = "ProcessColumn";
            this.ProcessColumn.ReadOnly = true;
            this.ProcessColumn.Width = 53;
            // 
            // StatusColumn
            // 
            this.StatusColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            this.StatusColumn.Width = 63;
            // 
            // tabPageFIQBI
            // 
            this.tabPageFIQBI.BackColor = System.Drawing.Color.Transparent;
            this.tabPageFIQBI.Controls.Add(this.wbADVBI3);
            this.tabPageFIQBI.Controls.Add(this.wbADVIBI2);
            this.tabPageFIQBI.Controls.Add(this.wbADVCOG1);
            this.tabPageFIQBI.Controls.Add(this.dgvFIQBISummary);
            this.tabPageFIQBI.Controls.Add(this.wbADVBI2);
            this.tabPageFIQBI.Location = new System.Drawing.Point(4, 42);
            this.tabPageFIQBI.Name = "tabPageFIQBI";
            this.tabPageFIQBI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFIQBI.Size = new System.Drawing.Size(1044, 752);
            this.tabPageFIQBI.TabIndex = 3;
            this.tabPageFIQBI.Text = "FIQ BI Reporting";
            this.tabPageFIQBI.ToolTipText = "FIQ/BI Cognos 7 processes";
            this.tabPageFIQBI.UseVisualStyleBackColor = true;
            this.tabPageFIQBI.Enter += new System.EventHandler(this.tabPageFIQBI_Enter);
            // 
            // wbADVBI3
            // 
            this.wbADVBI3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbADVBI3.Location = new System.Drawing.Point(520, 88);
            this.wbADVBI3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wbADVBI3.MinimumSize = new System.Drawing.Size(24, 22);
            this.wbADVBI3.Name = "wbADVBI3";
            this.wbADVBI3.Size = new System.Drawing.Size(508, 339);
            this.wbADVBI3.TabIndex = 6;
            this.wbADVBI3.Url = new System.Uri("http://unixmgt01/bb/html/advbi3.Build.html", System.UriKind.Absolute);
            this.wbADVBI3.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbADVBI3_DocumentCompleted);
            // 
            // wbADVIBI2
            // 
            this.wbADVIBI2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.wbADVIBI2.Location = new System.Drawing.Point(21, 442);
            this.wbADVIBI2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wbADVIBI2.MinimumSize = new System.Drawing.Size(24, 22);
            this.wbADVIBI2.Name = "wbADVIBI2";
            this.wbADVIBI2.Size = new System.Drawing.Size(489, 297);
            this.wbADVIBI2.TabIndex = 7;
            this.wbADVIBI2.Url = new System.Uri("http://unixmgt01/bb/html/advibi2.Migrate.html", System.UriKind.Absolute);
            this.wbADVIBI2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbADVIBI2_DocumentCompleted);
            // 
            // wbADVCOG1
            // 
            this.wbADVCOG1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbADVCOG1.Location = new System.Drawing.Point(520, 442);
            this.wbADVCOG1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wbADVCOG1.MinimumSize = new System.Drawing.Size(24, 22);
            this.wbADVCOG1.Name = "wbADVCOG1";
            this.wbADVCOG1.Size = new System.Drawing.Size(506, 297);
            this.wbADVCOG1.TabIndex = 8;
            this.wbADVCOG1.Url = new System.Uri("http://unixmgt01/bb/html/advcog1.Migrate.html", System.UriKind.Absolute);
            this.wbADVCOG1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbADVCOG1_DocumentCompleted);
            // 
            // dgvFIQBISummary
            // 
            this.dgvFIQBISummary.AllowUserToAddRows = false;
            this.dgvFIQBISummary.AllowUserToDeleteRows = false;
            this.dgvFIQBISummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFIQBISummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvFIQBISummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFIQBISummary.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFIQBISummary.Location = new System.Drawing.Point(12, 6);
            this.dgvFIQBISummary.Name = "dgvFIQBISummary";
            this.dgvFIQBISummary.ReadOnly = true;
            this.dgvFIQBISummary.Size = new System.Drawing.Size(1023, 69);
            this.dgvFIQBISummary.TabIndex = 9;
            this.dgvFIQBISummary.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFIQBISummary_DataBindingComplete);
            // 
            // wbADVBI2
            // 
            this.wbADVBI2.Location = new System.Drawing.Point(12, 88);
            this.wbADVBI2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.wbADVBI2.MinimumSize = new System.Drawing.Size(24, 22);
            this.wbADVBI2.Name = "wbADVBI2";
            this.wbADVBI2.Size = new System.Drawing.Size(498, 339);
            this.wbADVBI2.TabIndex = 4;
            this.wbADVBI2.Url = new System.Uri("http://unixmgt01/bb/html/advbi2.Build.html", System.UriKind.Absolute);
            this.wbADVBI2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbADVBI2_DocumentCompleted);
            // 
            // tabPageIBI
            // 
            this.tabPageIBI.BackColor = System.Drawing.Color.Transparent;
            this.tabPageIBI.Controls.Add(this.label81);
            this.tabPageIBI.Controls.Add(this.dgvC8ReportsRan);
            this.tabPageIBI.Controls.Add(this.dgvEDWMetrics);
            this.tabPageIBI.Controls.Add(this.label13);
            this.tabPageIBI.Controls.Add(this.dgvODSMetrics);
            this.tabPageIBI.Controls.Add(this.label11);
            this.tabPageIBI.Controls.Add(this.label1);
            this.tabPageIBI.Controls.Add(this.eDWWfResultsTableDataGridView);
            this.tabPageIBI.Controls.Add(this.dgvLatestEDWLoad);
            this.tabPageIBI.Controls.Add(this.dgvLatestODSLoad);
            this.tabPageIBI.Controls.Add(this.label7);
            this.tabPageIBI.Controls.Add(this.label6);
            this.tabPageIBI.Location = new System.Drawing.Point(4, 42);
            this.tabPageIBI.Name = "tabPageIBI";
            this.tabPageIBI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIBI.Size = new System.Drawing.Size(1092, 752);
            this.tabPageIBI.TabIndex = 4;
            this.tabPageIBI.Text = "IBI";
            this.tabPageIBI.ToolTipText = "IBI Cognos 8 processes";
            this.tabPageIBI.UseVisualStyleBackColor = true;
            this.tabPageIBI.Enter += new System.EventHandler(this.tabPageIBI_Enter);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.Location = new System.Drawing.Point(978, 5);
            this.label81.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(92, 13);
            this.label81.TabIndex = 15;
            this.label81.Text = "C8 Reports ran";
            // 
            // dgvC8ReportsRan
            // 
            this.dgvC8ReportsRan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvC8ReportsRan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvC8ReportsRan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvC8ReportsRan.Location = new System.Drawing.Point(972, 21);
            this.dgvC8ReportsRan.Name = "dgvC8ReportsRan";
            this.dgvC8ReportsRan.RowHeadersVisible = false;
            this.dgvC8ReportsRan.Size = new System.Drawing.Size(114, 684);
            this.dgvC8ReportsRan.TabIndex = 14;
            // 
            // dgvEDWMetrics
            // 
            this.dgvEDWMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEDWMetrics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEDWMetrics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEDWMetrics.Location = new System.Drawing.Point(14, 627);
            this.dgvEDWMetrics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvEDWMetrics.Name = "dgvEDWMetrics";
            this.dgvEDWMetrics.ReadOnly = true;
            this.dgvEDWMetrics.Size = new System.Drawing.Size(951, 78);
            this.dgvEDWMetrics.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 610);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "EDW Metrics";
            // 
            // dgvODSMetrics
            // 
            this.dgvODSMetrics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvODSMetrics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvODSMetrics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvODSMetrics.Location = new System.Drawing.Point(14, 272);
            this.dgvODSMetrics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvODSMetrics.Name = "dgvODSMetrics";
            this.dgvODSMetrics.ReadOnly = true;
            this.dgvODSMetrics.Size = new System.Drawing.Size(951, 142);
            this.dgvODSMetrics.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 255);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 14);
            this.label11.TabIndex = 10;
            this.label11.Text = "ODS Metrics";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "IBI EDW Workflow status";
            // 
            // eDWWfResultsTableDataGridView
            // 
            this.eDWWfResultsTableDataGridView.AllowUserToAddRows = false;
            this.eDWWfResultsTableDataGridView.AllowUserToDeleteRows = false;
            this.eDWWfResultsTableDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eDWWfResultsTableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eDWWfResultsTableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eDWWfResultsTableDataGridView.Location = new System.Drawing.Point(14, 21);
            this.eDWWfResultsTableDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.eDWWfResultsTableDataGridView.Name = "eDWWfResultsTableDataGridView";
            this.eDWWfResultsTableDataGridView.Size = new System.Drawing.Size(951, 48);
            this.eDWWfResultsTableDataGridView.TabIndex = 9;
            this.eDWWfResultsTableDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.eDWWfResultsTableDataGridView_CellFormatting);
            // 
            // dgvLatestEDWLoad
            // 
            this.dgvLatestEDWLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLatestEDWLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLatestEDWLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLatestEDWLoad.Location = new System.Drawing.Point(14, 434);
            this.dgvLatestEDWLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvLatestEDWLoad.Name = "dgvLatestEDWLoad";
            this.dgvLatestEDWLoad.ReadOnly = true;
            this.dgvLatestEDWLoad.Size = new System.Drawing.Size(951, 160);
            this.dgvLatestEDWLoad.TabIndex = 7;
            this.dgvLatestEDWLoad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLatestEDWLoad_CellFormatting);
            // 
            // dgvLatestODSLoad
            // 
            this.dgvLatestODSLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLatestODSLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLatestODSLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLatestODSLoad.Location = new System.Drawing.Point(14, 103);
            this.dgvLatestODSLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvLatestODSLoad.Name = "dgvLatestODSLoad";
            this.dgvLatestODSLoad.ReadOnly = true;
            this.dgvLatestODSLoad.Size = new System.Drawing.Size(951, 149);
            this.dgvLatestODSLoad.TabIndex = 5;
            this.dgvLatestODSLoad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLatestODSLoad_CellFormatting);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 417);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "Latest EDW Loads";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Latest ODS Loads";
            // 
            // tabPageProjections
            // 
            this.tabPageProjections.BackColor = System.Drawing.Color.Transparent;
            this.tabPageProjections.Controls.Add(this.dgvProjectionsLoads);
            this.tabPageProjections.Controls.Add(this.label52);
            this.tabPageProjections.Controls.Add(this.dgvProjections);
            this.tabPageProjections.Controls.Add(this.label10);
            this.tabPageProjections.Location = new System.Drawing.Point(4, 42);
            this.tabPageProjections.Name = "tabPageProjections";
            this.tabPageProjections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjections.Size = new System.Drawing.Size(1044, 752);
            this.tabPageProjections.TabIndex = 5;
            this.tabPageProjections.Text = "Projections";
            this.tabPageProjections.ToolTipText = "Projections processes";
            this.tabPageProjections.UseVisualStyleBackColor = true;
            this.tabPageProjections.Enter += new System.EventHandler(this.tabPageProjections_Enter);
            // 
            // dgvProjectionsLoads
            // 
            this.dgvProjectionsLoads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjectionsLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectionsLoads.Location = new System.Drawing.Point(17, 178);
            this.dgvProjectionsLoads.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProjectionsLoads.Name = "dgvProjectionsLoads";
            this.dgvProjectionsLoads.Size = new System.Drawing.Size(895, 489);
            this.dgvProjectionsLoads.TabIndex = 13;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(20, 161);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(127, 14);
            this.label52.TabIndex = 12;
            this.label52.Text = "Latest workflow runs";
            // 
            // dgvProjections
            // 
            this.dgvProjections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjections.Location = new System.Drawing.Point(17, 36);
            this.dgvProjections.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProjections.Name = "dgvProjections";
            this.dgvProjections.Size = new System.Drawing.Size(895, 107);
            this.dgvProjections.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 14);
            this.label10.TabIndex = 7;
            this.label10.Text = "Workflows currently running";
            // 
            // tabPageCinciDT
            // 
            this.tabPageCinciDT.BackColor = System.Drawing.Color.Transparent;
            this.tabPageCinciDT.Controls.Add(this.dgvCinciDataLoads);
            this.tabPageCinciDT.Controls.Add(this.label12);
            this.tabPageCinciDT.Location = new System.Drawing.Point(4, 42);
            this.tabPageCinciDT.Name = "tabPageCinciDT";
            this.tabPageCinciDT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCinciDT.Size = new System.Drawing.Size(1044, 752);
            this.tabPageCinciDT.TabIndex = 6;
            this.tabPageCinciDT.Text = "Cincinnati Data Transfer";
            this.tabPageCinciDT.ToolTipText = "Cincinnati Data Transfer proces";
            this.tabPageCinciDT.UseVisualStyleBackColor = true;
            this.tabPageCinciDT.Enter += new System.EventHandler(this.tabPageCinciDT_Enter);
            // 
            // dgvCinciDataLoads
            // 
            this.dgvCinciDataLoads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCinciDataLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCinciDataLoads.Location = new System.Drawing.Point(18, 70);
            this.dgvCinciDataLoads.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCinciDataLoads.Name = "dgvCinciDataLoads";
            this.dgvCinciDataLoads.Size = new System.Drawing.Size(895, 420);
            this.dgvCinciDataLoads.TabIndex = 9;
            this.dgvCinciDataLoads.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCinciDataLoads_CellFormatting);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 53);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "Latest workflow runs";
            // 
            // tabPageSavings
            // 
            this.tabPageSavings.Controls.Add(this.dgvCinciSavingsLoads);
            this.tabPageSavings.Controls.Add(this.label51);
            this.tabPageSavings.Location = new System.Drawing.Point(4, 42);
            this.tabPageSavings.Name = "tabPageSavings";
            this.tabPageSavings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSavings.Size = new System.Drawing.Size(1044, 752);
            this.tabPageSavings.TabIndex = 12;
            this.tabPageSavings.Text = "Cincinnati Savings Transfer";
            this.tabPageSavings.ToolTipText = "Savings Transfer to Cincinnati";
            this.tabPageSavings.UseVisualStyleBackColor = true;
            this.tabPageSavings.Enter += new System.EventHandler(this.tabPageCinciST_Enter);
            // 
            // dgvCinciSavingsLoads
            // 
            this.dgvCinciSavingsLoads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCinciSavingsLoads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCinciSavingsLoads.Location = new System.Drawing.Point(17, 38);
            this.dgvCinciSavingsLoads.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCinciSavingsLoads.Name = "dgvCinciSavingsLoads";
            this.dgvCinciSavingsLoads.Size = new System.Drawing.Size(895, 632);
            this.dgvCinciSavingsLoads.TabIndex = 11;
            this.dgvCinciSavingsLoads.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCinciSavingsLoads_CellFormatting);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(20, 21);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(127, 14);
            this.label51.TabIndex = 10;
            this.label51.Text = "Latest workflow runs";
            // 
            // tabPagePPEDataLoad
            // 
            this.tabPagePPEDataLoad.BackColor = System.Drawing.Color.Transparent;
            this.tabPagePPEDataLoad.Controls.Add(this.dgvPPEDataLoad);
            this.tabPagePPEDataLoad.Controls.Add(this.label14);
            this.tabPagePPEDataLoad.Location = new System.Drawing.Point(4, 42);
            this.tabPagePPEDataLoad.Name = "tabPagePPEDataLoad";
            this.tabPagePPEDataLoad.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePPEDataLoad.Size = new System.Drawing.Size(1044, 752);
            this.tabPagePPEDataLoad.TabIndex = 7;
            this.tabPagePPEDataLoad.Text = "PPE Data Load";
            this.tabPagePPEDataLoad.ToolTipText = "Data load into PPE 1 and PPE 2";
            this.tabPagePPEDataLoad.UseVisualStyleBackColor = true;
            // 
            // dgvPPEDataLoad
            // 
            this.dgvPPEDataLoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPPEDataLoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPPEDataLoad.Location = new System.Drawing.Point(13, 32);
            this.dgvPPEDataLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPPEDataLoad.Name = "dgvPPEDataLoad";
            this.dgvPPEDataLoad.Size = new System.Drawing.Size(895, 420);
            this.dgvPPEDataLoad.TabIndex = 11;
            this.dgvPPEDataLoad.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPPEDataLoad_CellFormatting);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 15);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 14);
            this.label14.TabIndex = 10;
            this.label14.Text = "Latest workflow runs";
            // 
            // tabELECFiles
            // 
            this.tabELECFiles.BackColor = System.Drawing.Color.Transparent;
            this.tabELECFiles.Controls.Add(this.tbELECFilesLogFile);
            this.tabELECFiles.Controls.Add(this.dgvELECFiles);
            this.tabELECFiles.Location = new System.Drawing.Point(4, 42);
            this.tabELECFiles.Name = "tabELECFiles";
            this.tabELECFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabELECFiles.Size = new System.Drawing.Size(1044, 752);
            this.tabELECFiles.TabIndex = 8;
            this.tabELECFiles.Text = "Telecom ELEC report files";
            this.tabELECFiles.ToolTipText = "ELEC Inventory file creation";
            this.tabELECFiles.UseVisualStyleBackColor = true;
            this.tabELECFiles.Enter += new System.EventHandler(this.tabELECFiles_Enter);
            // 
            // tbELECFilesLogFile
            // 
            this.tbELECFilesLogFile.Location = new System.Drawing.Point(40, 625);
            this.tbELECFilesLogFile.Multiline = true;
            this.tbELECFilesLogFile.Name = "tbELECFilesLogFile";
            this.tbELECFilesLogFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbELECFilesLogFile.Size = new System.Drawing.Size(837, 63);
            this.tbELECFilesLogFile.TabIndex = 1;
            // 
            // dgvELECFiles
            // 
            this.dgvELECFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvELECFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvELECFiles.Location = new System.Drawing.Point(40, 16);
            this.dgvELECFiles.Name = "dgvELECFiles";
            this.dgvELECFiles.Size = new System.Drawing.Size(837, 584);
            this.dgvELECFiles.TabIndex = 0;
            this.dgvELECFiles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvELECFiles_CellFormatting);
            // 
            // tabPageStatsProd
            // 
            this.tabPageStatsProd.BackColor = System.Drawing.Color.Transparent;
            this.tabPageStatsProd.Controls.Add(this.groupBox1);
            this.tabPageStatsProd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageStatsProd.Location = new System.Drawing.Point(4, 42);
            this.tabPageStatsProd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageStatsProd.Name = "tabPageStatsProd";
            this.tabPageStatsProd.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageStatsProd.Size = new System.Drawing.Size(1044, 752);
            this.tabPageStatsProd.TabIndex = 1;
            this.tabPageStatsProd.Text = "Informatica 8.1 Production";
            this.tabPageStatsProd.ToolTipText = "Informatica 8.1 Production Stats";
            this.tabPageStatsProd.UseVisualStyleBackColor = true;
            this.tabPageStatsProd.Enter += new System.EventHandler(this.tabPageStatsProd_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvWFLastWeek);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvProdWFScheduled);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dgvProdWFRunning);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 668);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Production";
            // 
            // dgvWFLastWeek
            // 
            this.dgvWFLastWeek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWFLastWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWFLastWeek.Location = new System.Drawing.Point(7, 328);
            this.dgvWFLastWeek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvWFLastWeek.Name = "dgvWFLastWeek";
            this.dgvWFLastWeek.Size = new System.Drawing.Size(895, 186);
            this.dgvWFLastWeek.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 310);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Workflows ran past 7 days";
            // 
            // dgvProdWFScheduled
            // 
            this.dgvProdWFScheduled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdWFScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdWFScheduled.Location = new System.Drawing.Point(7, 177);
            this.dgvProdWFScheduled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProdWFScheduled.Name = "dgvProdWFScheduled";
            this.dgvProdWFScheduled.Size = new System.Drawing.Size(895, 129);
            this.dgvProdWFScheduled.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Workflows scheduled";
            // 
            // dgvProdWFRunning
            // 
            this.dgvProdWFRunning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdWFRunning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdWFRunning.Location = new System.Drawing.Point(7, 50);
            this.dgvProdWFRunning.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProdWFRunning.Name = "dgvProdWFRunning";
            this.dgvProdWFRunning.Size = new System.Drawing.Size(895, 107);
            this.dgvProdWFRunning.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Workflows currently running";
            // 
            // tabStatsDev
            // 
            this.tabStatsDev.BackColor = System.Drawing.Color.Transparent;
            this.tabStatsDev.Controls.Add(this.dgvDevWFPast7Days);
            this.tabStatsDev.Controls.Add(this.label5);
            this.tabStatsDev.Controls.Add(this.dgvDevWFScheduled);
            this.tabStatsDev.Controls.Add(this.label8);
            this.tabStatsDev.Controls.Add(this.dgvDevWFRunning);
            this.tabStatsDev.Controls.Add(this.label9);
            this.tabStatsDev.Location = new System.Drawing.Point(4, 42);
            this.tabStatsDev.Name = "tabStatsDev";
            this.tabStatsDev.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatsDev.Size = new System.Drawing.Size(1044, 752);
            this.tabStatsDev.TabIndex = 2;
            this.tabStatsDev.Text = "Informatica 8.1 Development";
            this.tabStatsDev.ToolTipText = "Informatica 8.1 Development Stats";
            this.tabStatsDev.UseVisualStyleBackColor = true;
            this.tabStatsDev.Enter += new System.EventHandler(this.tabStatsDev_Enter);
            // 
            // dgvDevWFPast7Days
            // 
            this.dgvDevWFPast7Days.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevWFPast7Days.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevWFPast7Days.Location = new System.Drawing.Point(16, 310);
            this.dgvDevWFPast7Days.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDevWFPast7Days.Name = "dgvDevWFPast7Days";
            this.dgvDevWFPast7Days.Size = new System.Drawing.Size(895, 186);
            this.dgvDevWFPast7Days.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Workflows ran past 7 days";
            // 
            // dgvDevWFScheduled
            // 
            this.dgvDevWFScheduled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevWFScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevWFScheduled.Location = new System.Drawing.Point(16, 159);
            this.dgvDevWFScheduled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDevWFScheduled.Name = "dgvDevWFScheduled";
            this.dgvDevWFScheduled.Size = new System.Drawing.Size(895, 129);
            this.dgvDevWFScheduled.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 142);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Workflows scheduled";
            // 
            // dgvDevWFRunning
            // 
            this.dgvDevWFRunning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevWFRunning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevWFRunning.Location = new System.Drawing.Point(16, 32);
            this.dgvDevWFRunning.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDevWFRunning.Name = "dgvDevWFRunning";
            this.dgvDevWFRunning.Size = new System.Drawing.Size(895, 107);
            this.dgvDevWFRunning.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 14);
            this.label9.TabIndex = 11;
            this.label9.Text = "Workflows currently running";
            // 
            // tabPageCognos
            // 
            this.tabPageCognos.Controls.Add(this.webBrowserCognos8);
            this.tabPageCognos.Location = new System.Drawing.Point(4, 42);
            this.tabPageCognos.Name = "tabPageCognos";
            this.tabPageCognos.Size = new System.Drawing.Size(1044, 752);
            this.tabPageCognos.TabIndex = 9;
            this.tabPageCognos.Text = "Cognos 8 Prod";
            this.tabPageCognos.ToolTipText = "Cognos 8 service stats";
            this.tabPageCognos.UseVisualStyleBackColor = true;
            // 
            // webBrowserCognos8
            // 
            this.webBrowserCognos8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserCognos8.Location = new System.Drawing.Point(0, 0);
            this.webBrowserCognos8.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserCognos8.Name = "webBrowserCognos8";
            this.webBrowserCognos8.Size = new System.Drawing.Size(1044, 752);
            this.webBrowserCognos8.TabIndex = 0;
            this.webBrowserCognos8.Url = new System.Uri("http://advibi2/cognos8", System.UriKind.Absolute);
            this.webBrowserCognos8.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserCognos8_DocumentCompleted);
            // 
            // tabPageStatsProd86
            // 
            this.tabPageStatsProd86.BackColor = System.Drawing.Color.Transparent;
            this.tabPageStatsProd86.Controls.Add(this.groupBox7);
            this.tabPageStatsProd86.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageStatsProd86.Location = new System.Drawing.Point(4, 42);
            this.tabPageStatsProd86.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageStatsProd86.Name = "tabPageStatsProd86";
            this.tabPageStatsProd86.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageStatsProd86.Size = new System.Drawing.Size(1044, 752);
            this.tabPageStatsProd86.TabIndex = 10;
            this.tabPageStatsProd86.Text = "Informatica 8.6 Production";
            this.tabPageStatsProd86.ToolTipText = "Informatica 8.6 Production Stats";
            this.tabPageStatsProd86.UseVisualStyleBackColor = true;
            this.tabPageStatsProd86.Enter += new System.EventHandler(this.tabPageStatsProd86_Enter);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbSelectedWorkflow);
            this.groupBox7.Controls.Add(this.btnScheduleWorkflow);
            this.groupBox7.Controls.Add(this.label79);
            this.groupBox7.Controls.Add(this.dgvProd86WFLastWeek);
            this.groupBox7.Controls.Add(this.label45);
            this.groupBox7.Controls.Add(this.dgvProd86WFScheduled);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Controls.Add(this.dgvProd86WFRunning);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(7, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(912, 668);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Production";
            // 
            // tbSelectedWorkflow
            // 
            this.tbSelectedWorkflow.Location = new System.Drawing.Point(403, 312);
            this.tbSelectedWorkflow.Name = "tbSelectedWorkflow";
            this.tbSelectedWorkflow.ReadOnly = true;
            this.tbSelectedWorkflow.Size = new System.Drawing.Size(347, 20);
            this.tbSelectedWorkflow.TabIndex = 13;
            // 
            // btnScheduleWorkflow
            // 
            this.btnScheduleWorkflow.Location = new System.Drawing.Point(784, 309);
            this.btnScheduleWorkflow.Name = "btnScheduleWorkflow";
            this.btnScheduleWorkflow.Size = new System.Drawing.Size(75, 23);
            this.btnScheduleWorkflow.TabIndex = 12;
            this.btnScheduleWorkflow.Text = "Schedule";
            this.btnScheduleWorkflow.UseVisualStyleBackColor = true;
            this.btnScheduleWorkflow.Click += new System.EventHandler(this.btnScheduleWorkflow_Click);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(300, 318);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(105, 14);
            this.label79.TabIndex = 11;
            this.label79.Text = "Selected workflow: ";
            // 
            // dgvProd86WFLastWeek
            // 
            this.dgvProd86WFLastWeek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProd86WFLastWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd86WFLastWeek.Location = new System.Drawing.Point(7, 379);
            this.dgvProd86WFLastWeek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProd86WFLastWeek.Name = "dgvProd86WFLastWeek";
            this.dgvProd86WFLastWeek.Size = new System.Drawing.Size(895, 186);
            this.dgvProd86WFLastWeek.TabIndex = 10;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(4, 361);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(153, 14);
            this.label45.TabIndex = 9;
            this.label45.Text = "Workflows ran past 7 days";
            // 
            // dgvProd86WFScheduled
            // 
            this.dgvProd86WFScheduled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProd86WFScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd86WFScheduled.Location = new System.Drawing.Point(7, 177);
            this.dgvProd86WFScheduled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProd86WFScheduled.Name = "dgvProd86WFScheduled";
            this.dgvProd86WFScheduled.Size = new System.Drawing.Size(895, 129);
            this.dgvProd86WFScheduled.TabIndex = 8;
            this.dgvProd86WFScheduled.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProd86WFScheduled_RowEnter);
            this.dgvProd86WFScheduled.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProd86WFScheduled_CellFormatting);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(7, 160);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(128, 14);
            this.label46.TabIndex = 7;
            this.label46.Text = "Workflows scheduled";
            // 
            // dgvProd86WFRunning
            // 
            this.dgvProd86WFRunning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProd86WFRunning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProd86WFRunning.Location = new System.Drawing.Point(7, 50);
            this.dgvProd86WFRunning.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProd86WFRunning.Name = "dgvProd86WFRunning";
            this.dgvProd86WFRunning.Size = new System.Drawing.Size(895, 107);
            this.dgvProd86WFRunning.TabIndex = 6;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(7, 33);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(166, 14);
            this.label47.TabIndex = 5;
            this.label47.Text = "Workflows currently running";
            // 
            // tabPageInfa86Dev
            // 
            this.tabPageInfa86Dev.BackColor = System.Drawing.Color.Transparent;
            this.tabPageInfa86Dev.Controls.Add(this.groupBox8);
            this.tabPageInfa86Dev.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageInfa86Dev.Location = new System.Drawing.Point(4, 42);
            this.tabPageInfa86Dev.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageInfa86Dev.Name = "tabPageInfa86Dev";
            this.tabPageInfa86Dev.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPageInfa86Dev.Size = new System.Drawing.Size(1044, 752);
            this.tabPageInfa86Dev.TabIndex = 11;
            this.tabPageInfa86Dev.Text = "Informatica 8.6 Development";
            this.tabPageInfa86Dev.ToolTipText = "Informatica 8.6 Development Stats";
            this.tabPageInfa86Dev.UseVisualStyleBackColor = true;
            this.tabPageInfa86Dev.Enter += new System.EventHandler(this.tabPageInfa86Dev_Enter);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dgvDev86WFLastWeek);
            this.groupBox8.Controls.Add(this.label48);
            this.groupBox8.Controls.Add(this.dgvDev86WFScheduled);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.dgvDev86WFRunning);
            this.groupBox8.Controls.Add(this.label50);
            this.groupBox8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(7, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(912, 668);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Production";
            // 
            // dgvDev86WFLastWeek
            // 
            this.dgvDev86WFLastWeek.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDev86WFLastWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDev86WFLastWeek.Location = new System.Drawing.Point(7, 328);
            this.dgvDev86WFLastWeek.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDev86WFLastWeek.Name = "dgvDev86WFLastWeek";
            this.dgvDev86WFLastWeek.Size = new System.Drawing.Size(895, 186);
            this.dgvDev86WFLastWeek.TabIndex = 10;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(4, 310);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(153, 14);
            this.label48.TabIndex = 9;
            this.label48.Text = "Workflows ran past 7 days";
            // 
            // dgvDev86WFScheduled
            // 
            this.dgvDev86WFScheduled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDev86WFScheduled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDev86WFScheduled.Location = new System.Drawing.Point(7, 177);
            this.dgvDev86WFScheduled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDev86WFScheduled.Name = "dgvDev86WFScheduled";
            this.dgvDev86WFScheduled.Size = new System.Drawing.Size(895, 129);
            this.dgvDev86WFScheduled.TabIndex = 8;
            this.dgvDev86WFScheduled.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDev86WFScheduled_CellFormatting);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(7, 160);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(128, 14);
            this.label49.TabIndex = 7;
            this.label49.Text = "Workflows scheduled";
            // 
            // dgvDev86WFRunning
            // 
            this.dgvDev86WFRunning.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDev86WFRunning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDev86WFRunning.Location = new System.Drawing.Point(7, 50);
            this.dgvDev86WFRunning.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvDev86WFRunning.Name = "dgvDev86WFRunning";
            this.dgvDev86WFRunning.Size = new System.Drawing.Size(895, 107);
            this.dgvDev86WFRunning.TabIndex = 6;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(7, 33);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(166, 14);
            this.label50.TabIndex = 5;
            this.label50.Text = "Workflows currently running";
            // 
            // tabPagePDSProd
            // 
            this.tabPagePDSProd.Controls.Add(this.dgvPDSProdLatestestWfs);
            this.tabPagePDSProd.Controls.Add(this.label76);
            this.tabPagePDSProd.Location = new System.Drawing.Point(4, 42);
            this.tabPagePDSProd.Name = "tabPagePDSProd";
            this.tabPagePDSProd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePDSProd.Size = new System.Drawing.Size(1044, 752);
            this.tabPagePDSProd.TabIndex = 13;
            this.tabPagePDSProd.Text = "PDS Production";
            this.tabPagePDSProd.UseVisualStyleBackColor = true;
            // 
            // dgvPDSProdLatestestWfs
            // 
            this.dgvPDSProdLatestestWfs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPDSProdLatestestWfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDSProdLatestestWfs.Location = new System.Drawing.Point(14, 31);
            this.dgvPDSProdLatestestWfs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPDSProdLatestestWfs.Name = "dgvPDSProdLatestestWfs";
            this.dgvPDSProdLatestestWfs.Size = new System.Drawing.Size(895, 640);
            this.dgvPDSProdLatestestWfs.TabIndex = 11;
            this.dgvPDSProdLatestestWfs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPDSProdLatestestWfs_CellFormatting);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(17, 14);
            this.label76.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(127, 14);
            this.label76.TabIndex = 10;
            this.label76.Text = "Latest workflow runs";
            // 
            // tabPagePDSDev
            // 
            this.tabPagePDSDev.Controls.Add(this.btnPDSLoadFilterLinkages);
            this.tabPagePDSDev.Controls.Add(this.btnPDSLoadMetadata);
            this.tabPagePDSDev.Controls.Add(this.btnRefreshInfaDev);
            this.tabPagePDSDev.Controls.Add(this.dgvPDSDevLatestWfs);
            this.tabPagePDSDev.Controls.Add(this.label80);
            this.tabPagePDSDev.Controls.Add(this.btnStartPDSDevWorkflow);
            this.tabPagePDSDev.Controls.Add(this.tbOracleIPAddress);
            this.tabPagePDSDev.Controls.Add(this.tbSQLServerIPAddress);
            this.tabPagePDSDev.Controls.Add(this.btnSchedulePDSWorkflow);
            this.tabPagePDSDev.Controls.Add(this.btnSetupTrainingDL);
            this.tabPagePDSDev.Controls.Add(this.label78);
            this.tabPagePDSDev.Controls.Add(this.label77);
            this.tabPagePDSDev.Controls.Add(this.btnTruncateTables);
            this.tabPagePDSDev.Location = new System.Drawing.Point(4, 42);
            this.tabPagePDSDev.Name = "tabPagePDSDev";
            this.tabPagePDSDev.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePDSDev.Size = new System.Drawing.Size(1044, 752);
            this.tabPagePDSDev.TabIndex = 14;
            this.tabPagePDSDev.Text = "PDS Development";
            this.tabPagePDSDev.UseVisualStyleBackColor = true;
            // 
            // btnPDSLoadFilterLinkages
            // 
            this.btnPDSLoadFilterLinkages.Location = new System.Drawing.Point(493, 262);
            this.btnPDSLoadFilterLinkages.Name = "btnPDSLoadFilterLinkages";
            this.btnPDSLoadFilterLinkages.Size = new System.Drawing.Size(177, 23);
            this.btnPDSLoadFilterLinkages.TabIndex = 16;
            this.btnPDSLoadFilterLinkages.Text = "Start PDS LoadFilterLinkages";
            this.btnPDSLoadFilterLinkages.UseVisualStyleBackColor = true;
            this.btnPDSLoadFilterLinkages.Click += new System.EventHandler(this.btnPDSLoadFilterLinkages_Click);
            // 
            // btnPDSLoadMetadata
            // 
            this.btnPDSLoadMetadata.Location = new System.Drawing.Point(289, 262);
            this.btnPDSLoadMetadata.Name = "btnPDSLoadMetadata";
            this.btnPDSLoadMetadata.Size = new System.Drawing.Size(177, 23);
            this.btnPDSLoadMetadata.TabIndex = 15;
            this.btnPDSLoadMetadata.Text = "Start PDS LoadMetadata workflow";
            this.btnPDSLoadMetadata.UseVisualStyleBackColor = true;
            this.btnPDSLoadMetadata.Click += new System.EventHandler(this.btnPDSLoadMetadata_Click);
            // 
            // btnRefreshInfaDev
            // 
            this.btnRefreshInfaDev.Location = new System.Drawing.Point(805, 267);
            this.btnRefreshInfaDev.Name = "btnRefreshInfaDev";
            this.btnRefreshInfaDev.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshInfaDev.TabIndex = 14;
            this.btnRefreshInfaDev.Text = "Refresh";
            this.btnRefreshInfaDev.UseVisualStyleBackColor = true;
            this.btnRefreshInfaDev.Click += new System.EventHandler(this.btnRefreshInfaDev_Click);
            // 
            // dgvPDSDevLatestWfs
            // 
            this.dgvPDSDevLatestWfs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPDSDevLatestWfs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDSDevLatestWfs.Location = new System.Drawing.Point(54, 325);
            this.dgvPDSDevLatestWfs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPDSDevLatestWfs.Name = "dgvPDSDevLatestWfs";
            this.dgvPDSDevLatestWfs.Size = new System.Drawing.Size(895, 375);
            this.dgvPDSDevLatestWfs.TabIndex = 13;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(51, 308);
            this.label80.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(127, 14);
            this.label80.TabIndex = 12;
            this.label80.Text = "Latest workflow runs";
            // 
            // btnStartPDSDevWorkflow
            // 
            this.btnStartPDSDevWorkflow.Location = new System.Drawing.Point(54, 262);
            this.btnStartPDSDevWorkflow.Name = "btnStartPDSDevWorkflow";
            this.btnStartPDSDevWorkflow.Size = new System.Drawing.Size(177, 23);
            this.btnStartPDSDevWorkflow.TabIndex = 9;
            this.btnStartPDSDevWorkflow.Text = "Start PDS Dev workflow";
            this.btnStartPDSDevWorkflow.UseVisualStyleBackColor = true;
            this.btnStartPDSDevWorkflow.Click += new System.EventHandler(this.btnStartPDSDevWorkflow_Click);
            // 
            // tbOracleIPAddress
            // 
            this.tbOracleIPAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.tbOracleIPAddress.Location = new System.Drawing.Point(208, 67);
            this.tbOracleIPAddress.Mask = "000.000.000.000";
            this.tbOracleIPAddress.Name = "tbOracleIPAddress";
            this.tbOracleIPAddress.Size = new System.Drawing.Size(118, 20);
            this.tbOracleIPAddress.TabIndex = 8;
            // 
            // tbSQLServerIPAddress
            // 
            this.tbSQLServerIPAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.tbSQLServerIPAddress.Location = new System.Drawing.Point(208, 31);
            this.tbSQLServerIPAddress.Mask = "000.000.000.000";
            this.tbSQLServerIPAddress.Name = "tbSQLServerIPAddress";
            this.tbSQLServerIPAddress.Size = new System.Drawing.Size(118, 20);
            this.tbSQLServerIPAddress.TabIndex = 7;
            // 
            // btnSchedulePDSWorkflow
            // 
            this.btnSchedulePDSWorkflow.Location = new System.Drawing.Point(54, 211);
            this.btnSchedulePDSWorkflow.Name = "btnSchedulePDSWorkflow";
            this.btnSchedulePDSWorkflow.Size = new System.Drawing.Size(158, 23);
            this.btnSchedulePDSWorkflow.TabIndex = 6;
            this.btnSchedulePDSWorkflow.Text = "Schedule PDS workflow";
            this.btnSchedulePDSWorkflow.UseVisualStyleBackColor = true;
            // 
            // btnSetupTrainingDL
            // 
            this.btnSetupTrainingDL.Location = new System.Drawing.Point(54, 169);
            this.btnSetupTrainingDL.Name = "btnSetupTrainingDL";
            this.btnSetupTrainingDL.Size = new System.Drawing.Size(158, 23);
            this.btnSetupTrainingDL.TabIndex = 5;
            this.btnSetupTrainingDL.Text = "Set up Training Data Load";
            this.btnSetupTrainingDL.UseVisualStyleBackColor = true;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(54, 67);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(95, 14);
            this.label78.TabIndex = 4;
            this.label78.Text = "Oracle IP Address";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(54, 35);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(120, 14);
            this.label77.TabIndex = 2;
            this.label77.Text = "SQL Server IP Address";
            // 
            // btnTruncateTables
            // 
            this.btnTruncateTables.Location = new System.Drawing.Point(54, 129);
            this.btnTruncateTables.Name = "btnTruncateTables";
            this.btnTruncateTables.Size = new System.Drawing.Size(118, 23);
            this.btnTruncateTables.TabIndex = 0;
            this.btnTruncateTables.Text = "Truncate Tables";
            this.btnTruncateTables.UseVisualStyleBackColor = true;
            this.btnTruncateTables.Click += new System.EventHandler(this.btnTruncateTables_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.groupBox2);
            this.tabOptions.Location = new System.Drawing.Point(4, 42);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(1044, 752);
            this.tabOptions.TabIndex = 15;
            this.tabOptions.Text = "Settings";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.propertyGrid1);
            this.groupBox2.Location = new System.Drawing.Point(40, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 399);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Settings";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(13, 15);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(715, 375);
            this.propertyGrid1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(930, 711);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Status";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(255, 356);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Last  updated: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(703, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Refresh";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn1,
            this.dataGridViewTextBoxColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(258, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(302, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "Process";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Status";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(930, 711);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "FIQ BI Reporting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.webBrowser2);
            this.groupBox3.Controls.Add(this.webBrowser3);
            this.groupBox3.Controls.Add(this.webBrowser4);
            this.groupBox3.Location = new System.Drawing.Point(9, -113);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(912, 818);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FIQ BI process status";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(460, 119);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(442, 340);
            this.webBrowser1.TabIndex = 6;
            this.webBrowser1.Url = new System.Uri("http://unixmgt01/bb/html/advbi3.Build.html", System.UriKind.Absolute);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(816, 785);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 27);
            this.button3.TabIndex = 1;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(460, 465);
            this.webBrowser2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(442, 314);
            this.webBrowser2.TabIndex = 8;
            this.webBrowser2.Url = new System.Uri("http://unixmgt01/bb/html/advcog1.Migrate.html", System.UriKind.Absolute);
            // 
            // webBrowser3
            // 
            this.webBrowser3.Location = new System.Drawing.Point(-2, 119);
            this.webBrowser3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(442, 340);
            this.webBrowser3.TabIndex = 4;
            this.webBrowser3.Url = new System.Uri("http://unixmgt01/bb/html/advbi2.Build.html", System.UriKind.Absolute);
            // 
            // webBrowser4
            // 
            this.webBrowser4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser4.Location = new System.Drawing.Point(-2, 465);
            this.webBrowser4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser4.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser4.Name = "webBrowser4";
            this.webBrowser4.Size = new System.Drawing.Size(442, 318);
            this.webBrowser4.TabIndex = 7;
            this.webBrowser4.Url = new System.Uri("http://unixmgt01/bb/html/advibi2.Migrate.html", System.UriKind.Absolute);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Transparent;
            this.tabPage4.Controls.Add(this.dataGridView2);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.dataGridView3);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Controls.Add(this.dataGridView5);
            this.tabPage4.Controls.Add(this.dataGridView6);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(930, 711);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "IBI";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(14, 627);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(903, 78);
            this.dataGridView2.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 610);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 14);
            this.label16.TabIndex = 12;
            this.label16.Text = "EDW Metrics";
            // 
            // dataGridView3
            // 
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(14, 272);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(903, 142);
            this.dataGridView3.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(11, 255);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 14);
            this.label17.TabIndex = 10;
            this.label17.Text = "ODS Metrics";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(11, 5);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "IBI EDW Workflow status";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(14, 21);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(903, 48);
            this.dataGridView4.TabIndex = 9;
            // 
            // dataGridView5
            // 
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(14, 434);
            this.dataGridView5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.Size = new System.Drawing.Size(903, 160);
            this.dataGridView5.TabIndex = 7;
            // 
            // dataGridView6
            // 
            this.dataGridView6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(14, 103);
            this.dataGridView6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.Size = new System.Drawing.Size(903, 149);
            this.dataGridView6.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 417);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 14);
            this.label19.TabIndex = 6;
            this.label19.Text = "Latest EDW Loads";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 86);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 14);
            this.label20.TabIndex = 4;
            this.label20.Text = "Latest ODS Loads";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Transparent;
            this.tabPage5.Controls.Add(this.dataGridView7);
            this.tabPage5.Controls.Add(this.label21);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(930, 711);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Projections";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(17, 36);
            this.dataGridView7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(895, 107);
            this.dataGridView7.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(17, 19);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(166, 14);
            this.label21.TabIndex = 7;
            this.label21.Text = "Workflows currently running";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Transparent;
            this.tabPage6.Controls.Add(this.dataGridView8);
            this.tabPage6.Controls.Add(this.label22);
            this.tabPage6.Location = new System.Drawing.Point(4, 23);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(930, 711);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Cincinnati Data Transfer";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView8
            // 
            this.dataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Location = new System.Drawing.Point(18, 70);
            this.dataGridView8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.Size = new System.Drawing.Size(895, 420);
            this.dataGridView8.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(21, 53);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(127, 14);
            this.label22.TabIndex = 8;
            this.label22.Text = "Latest workflow runs";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.Transparent;
            this.tabPage7.Controls.Add(this.dataGridView9);
            this.tabPage7.Controls.Add(this.label23);
            this.tabPage7.Location = new System.Drawing.Point(4, 23);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(930, 711);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "PPE Data Load";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dataGridView9
            // 
            this.dataGridView9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView9.Location = new System.Drawing.Point(13, 32);
            this.dataGridView9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.Size = new System.Drawing.Size(895, 420);
            this.dataGridView9.TabIndex = 11;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(16, 15);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(127, 14);
            this.label23.TabIndex = 10;
            this.label23.Text = "Latest workflow runs";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.Transparent;
            this.tabPage8.Controls.Add(this.textBox1);
            this.tabPage8.Controls.Add(this.dataGridView10);
            this.tabPage8.Location = new System.Drawing.Point(4, 23);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(930, 711);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "Telecom ELEC report files";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 625);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(837, 63);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView10
            // 
            this.dataGridView10.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView10.Location = new System.Drawing.Point(40, 16);
            this.dataGridView10.Name = "dataGridView10";
            this.dataGridView10.Size = new System.Drawing.Size(837, 584);
            this.dataGridView10.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.Transparent;
            this.tabPage9.Controls.Add(this.groupBox4);
            this.tabPage9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage9.Location = new System.Drawing.Point(4, 23);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage9.Size = new System.Drawing.Size(930, 711);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Infa Prod";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView11);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.dataGridView12);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.dataGridView13);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(7, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(912, 668);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Production";
            // 
            // dataGridView11
            // 
            this.dataGridView11.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView11.Location = new System.Drawing.Point(7, 328);
            this.dataGridView11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView11.Name = "dataGridView11";
            this.dataGridView11.Size = new System.Drawing.Size(895, 186);
            this.dataGridView11.TabIndex = 10;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(4, 310);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(153, 14);
            this.label24.TabIndex = 9;
            this.label24.Text = "Workflows ran past 7 days";
            // 
            // dataGridView12
            // 
            this.dataGridView12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView12.Location = new System.Drawing.Point(7, 177);
            this.dataGridView12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView12.Name = "dataGridView12";
            this.dataGridView12.Size = new System.Drawing.Size(895, 129);
            this.dataGridView12.TabIndex = 8;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(7, 160);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 14);
            this.label25.TabIndex = 7;
            this.label25.Text = "Workflows scheduled";
            // 
            // dataGridView13
            // 
            this.dataGridView13.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView13.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView13.Location = new System.Drawing.Point(7, 50);
            this.dataGridView13.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView13.Name = "dataGridView13";
            this.dataGridView13.Size = new System.Drawing.Size(895, 107);
            this.dataGridView13.TabIndex = 6;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(7, 33);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(166, 14);
            this.label26.TabIndex = 5;
            this.label26.Text = "Workflows currently running";
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.Transparent;
            this.tabPage10.Controls.Add(this.dataGridView14);
            this.tabPage10.Controls.Add(this.label27);
            this.tabPage10.Controls.Add(this.dataGridView15);
            this.tabPage10.Controls.Add(this.label28);
            this.tabPage10.Controls.Add(this.dataGridView16);
            this.tabPage10.Controls.Add(this.label29);
            this.tabPage10.Location = new System.Drawing.Point(4, 23);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(930, 711);
            this.tabPage10.TabIndex = 2;
            this.tabPage10.Text = "Infa Dev";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // dataGridView14
            // 
            this.dataGridView14.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView14.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView14.Location = new System.Drawing.Point(16, 310);
            this.dataGridView14.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView14.Name = "dataGridView14";
            this.dataGridView14.Size = new System.Drawing.Size(895, 186);
            this.dataGridView14.TabIndex = 16;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(13, 292);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(153, 14);
            this.label27.TabIndex = 15;
            this.label27.Text = "Workflows ran past 7 days";
            // 
            // dataGridView15
            // 
            this.dataGridView15.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView15.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView15.Location = new System.Drawing.Point(16, 159);
            this.dataGridView15.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView15.Name = "dataGridView15";
            this.dataGridView15.Size = new System.Drawing.Size(895, 129);
            this.dataGridView15.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(16, 142);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(128, 14);
            this.label28.TabIndex = 13;
            this.label28.Text = "Workflows scheduled";
            // 
            // dataGridView16
            // 
            this.dataGridView16.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView16.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView16.Location = new System.Drawing.Point(16, 32);
            this.dataGridView16.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView16.Name = "dataGridView16";
            this.dataGridView16.Size = new System.Drawing.Size(895, 107);
            this.dataGridView16.TabIndex = 12;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(16, 15);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(166, 14);
            this.label29.TabIndex = 11;
            this.label29.Text = "Workflows currently running";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.webBrowser5);
            this.tabPage11.Location = new System.Drawing.Point(4, 23);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(930, 711);
            this.tabPage11.TabIndex = 9;
            this.tabPage11.Text = "Cognos 8 Prod";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // webBrowser5
            // 
            this.webBrowser5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser5.Location = new System.Drawing.Point(0, 0);
            this.webBrowser5.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser5.Name = "webBrowser5";
            this.webBrowser5.Size = new System.Drawing.Size(930, 711);
            this.webBrowser5.TabIndex = 0;
            this.webBrowser5.Url = new System.Uri("http://advibi2/cognos8", System.UriKind.Absolute);
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage12.Controls.Add(this.label30);
            this.tabPage12.Controls.Add(this.button4);
            this.tabPage12.Controls.Add(this.dataGridView17);
            this.tabPage12.Location = new System.Drawing.Point(4, 23);
            this.tabPage12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage12.Size = new System.Drawing.Size(930, 711);
            this.tabPage12.TabIndex = 0;
            this.tabPage12.Text = "Status";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(255, 356);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Last  updated: ";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(703, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Refresh";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridView17
            // 
            this.dataGridView17.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView17.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn2,
            this.dataGridViewTextBoxColumn2});
            this.dataGridView17.Location = new System.Drawing.Point(258, 71);
            this.dataGridView17.Name = "dataGridView17";
            this.dataGridView17.ReadOnly = true;
            this.dataGridView17.Size = new System.Drawing.Size(302, 267);
            this.dataGridView17.TabIndex = 0;
            // 
            // dataGridViewLinkColumn2
            // 
            this.dataGridViewLinkColumn2.HeaderText = "Process";
            this.dataGridViewLinkColumn2.Name = "dataGridViewLinkColumn2";
            this.dataGridViewLinkColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.Color.Transparent;
            this.tabPage13.Controls.Add(this.groupBox5);
            this.tabPage13.Location = new System.Drawing.Point(4, 23);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(930, 711);
            this.tabPage13.TabIndex = 3;
            this.tabPage13.Text = "FIQ BI Reporting";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.webBrowser6);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.webBrowser7);
            this.groupBox5.Controls.Add(this.webBrowser8);
            this.groupBox5.Controls.Add(this.webBrowser9);
            this.groupBox5.Location = new System.Drawing.Point(9, -113);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(912, 818);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "FIQ BI process status";
            // 
            // webBrowser6
            // 
            this.webBrowser6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser6.Location = new System.Drawing.Point(460, 119);
            this.webBrowser6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser6.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser6.Name = "webBrowser6";
            this.webBrowser6.Size = new System.Drawing.Size(442, 340);
            this.webBrowser6.TabIndex = 6;
            this.webBrowser6.Url = new System.Uri("http://unixmgt01/bb/html/advbi3.Build.html", System.UriKind.Absolute);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(816, 785);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 27);
            this.button5.TabIndex = 1;
            this.button5.Text = "Refresh";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // webBrowser7
            // 
            this.webBrowser7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser7.Location = new System.Drawing.Point(460, 465);
            this.webBrowser7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser7.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser7.Name = "webBrowser7";
            this.webBrowser7.Size = new System.Drawing.Size(442, 314);
            this.webBrowser7.TabIndex = 8;
            this.webBrowser7.Url = new System.Uri("http://unixmgt01/bb/html/advcog1.Migrate.html", System.UriKind.Absolute);
            // 
            // webBrowser8
            // 
            this.webBrowser8.Location = new System.Drawing.Point(-2, 119);
            this.webBrowser8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser8.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser8.Name = "webBrowser8";
            this.webBrowser8.Size = new System.Drawing.Size(442, 340);
            this.webBrowser8.TabIndex = 4;
            this.webBrowser8.Url = new System.Uri("http://unixmgt01/bb/html/advbi2.Build.html", System.UriKind.Absolute);
            // 
            // webBrowser9
            // 
            this.webBrowser9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser9.Location = new System.Drawing.Point(-2, 465);
            this.webBrowser9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser9.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser9.Name = "webBrowser9";
            this.webBrowser9.Size = new System.Drawing.Size(442, 318);
            this.webBrowser9.TabIndex = 7;
            this.webBrowser9.Url = new System.Uri("http://unixmgt01/bb/html/advibi2.Migrate.html", System.UriKind.Absolute);
            // 
            // tabPage14
            // 
            this.tabPage14.BackColor = System.Drawing.Color.Transparent;
            this.tabPage14.Controls.Add(this.dataGridView18);
            this.tabPage14.Controls.Add(this.label31);
            this.tabPage14.Controls.Add(this.dataGridView19);
            this.tabPage14.Controls.Add(this.label32);
            this.tabPage14.Controls.Add(this.label33);
            this.tabPage14.Controls.Add(this.dataGridView20);
            this.tabPage14.Controls.Add(this.dataGridView21);
            this.tabPage14.Controls.Add(this.dataGridView22);
            this.tabPage14.Controls.Add(this.label34);
            this.tabPage14.Controls.Add(this.label35);
            this.tabPage14.Location = new System.Drawing.Point(4, 23);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(930, 711);
            this.tabPage14.TabIndex = 4;
            this.tabPage14.Text = "IBI";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // dataGridView18
            // 
            this.dataGridView18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView18.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView18.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView18.Location = new System.Drawing.Point(14, 627);
            this.dataGridView18.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView18.Name = "dataGridView18";
            this.dataGridView18.ReadOnly = true;
            this.dataGridView18.Size = new System.Drawing.Size(903, 78);
            this.dataGridView18.TabIndex = 13;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(11, 610);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(75, 14);
            this.label31.TabIndex = 12;
            this.label31.Text = "EDW Metrics";
            // 
            // dataGridView19
            // 
            this.dataGridView19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView19.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView19.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView19.Location = new System.Drawing.Point(14, 272);
            this.dataGridView19.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView19.Name = "dataGridView19";
            this.dataGridView19.ReadOnly = true;
            this.dataGridView19.Size = new System.Drawing.Size(903, 142);
            this.dataGridView19.TabIndex = 11;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(11, 255);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(74, 14);
            this.label32.TabIndex = 10;
            this.label32.Text = "ODS Metrics";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(11, 5);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(151, 13);
            this.label33.TabIndex = 8;
            this.label33.Text = "IBI EDW Workflow status";
            // 
            // dataGridView20
            // 
            this.dataGridView20.AllowUserToAddRows = false;
            this.dataGridView20.AllowUserToDeleteRows = false;
            this.dataGridView20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView20.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView20.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView20.Location = new System.Drawing.Point(14, 21);
            this.dataGridView20.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView20.Name = "dataGridView20";
            this.dataGridView20.Size = new System.Drawing.Size(903, 48);
            this.dataGridView20.TabIndex = 9;
            // 
            // dataGridView21
            // 
            this.dataGridView21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView21.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView21.Location = new System.Drawing.Point(14, 434);
            this.dataGridView21.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView21.Name = "dataGridView21";
            this.dataGridView21.ReadOnly = true;
            this.dataGridView21.Size = new System.Drawing.Size(903, 160);
            this.dataGridView21.TabIndex = 7;
            // 
            // dataGridView22
            // 
            this.dataGridView22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView22.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView22.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView22.Location = new System.Drawing.Point(14, 103);
            this.dataGridView22.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView22.Name = "dataGridView22";
            this.dataGridView22.ReadOnly = true;
            this.dataGridView22.Size = new System.Drawing.Size(903, 149);
            this.dataGridView22.TabIndex = 5;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(11, 417);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(105, 14);
            this.label34.TabIndex = 6;
            this.label34.Text = "Latest EDW Loads";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(11, 86);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(104, 14);
            this.label35.TabIndex = 4;
            this.label35.Text = "Latest ODS Loads";
            // 
            // tabPage15
            // 
            this.tabPage15.BackColor = System.Drawing.Color.Transparent;
            this.tabPage15.Controls.Add(this.dataGridView23);
            this.tabPage15.Controls.Add(this.label36);
            this.tabPage15.Location = new System.Drawing.Point(4, 23);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(930, 711);
            this.tabPage15.TabIndex = 5;
            this.tabPage15.Text = "Projections";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // dataGridView23
            // 
            this.dataGridView23.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView23.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView23.Location = new System.Drawing.Point(17, 36);
            this.dataGridView23.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView23.Name = "dataGridView23";
            this.dataGridView23.Size = new System.Drawing.Size(895, 107);
            this.dataGridView23.TabIndex = 8;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(17, 19);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(166, 14);
            this.label36.TabIndex = 7;
            this.label36.Text = "Workflows currently running";
            // 
            // tabPage16
            // 
            this.tabPage16.BackColor = System.Drawing.Color.Transparent;
            this.tabPage16.Controls.Add(this.dataGridView24);
            this.tabPage16.Controls.Add(this.label37);
            this.tabPage16.Location = new System.Drawing.Point(4, 23);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(930, 711);
            this.tabPage16.TabIndex = 6;
            this.tabPage16.Text = "Cincinnati Data Transfer";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // dataGridView24
            // 
            this.dataGridView24.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView24.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView24.Location = new System.Drawing.Point(18, 70);
            this.dataGridView24.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView24.Name = "dataGridView24";
            this.dataGridView24.Size = new System.Drawing.Size(895, 420);
            this.dataGridView24.TabIndex = 9;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(21, 53);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(127, 14);
            this.label37.TabIndex = 8;
            this.label37.Text = "Latest workflow runs";
            // 
            // tabPage17
            // 
            this.tabPage17.BackColor = System.Drawing.Color.Transparent;
            this.tabPage17.Controls.Add(this.dataGridView25);
            this.tabPage17.Controls.Add(this.label38);
            this.tabPage17.Location = new System.Drawing.Point(4, 23);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(930, 711);
            this.tabPage17.TabIndex = 7;
            this.tabPage17.Text = "PPE Data Load";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // dataGridView25
            // 
            this.dataGridView25.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView25.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView25.Location = new System.Drawing.Point(13, 32);
            this.dataGridView25.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView25.Name = "dataGridView25";
            this.dataGridView25.Size = new System.Drawing.Size(895, 420);
            this.dataGridView25.TabIndex = 11;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(16, 15);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(127, 14);
            this.label38.TabIndex = 10;
            this.label38.Text = "Latest workflow runs";
            // 
            // tabPage18
            // 
            this.tabPage18.BackColor = System.Drawing.Color.Transparent;
            this.tabPage18.Controls.Add(this.textBox2);
            this.tabPage18.Controls.Add(this.dataGridView26);
            this.tabPage18.Location = new System.Drawing.Point(4, 23);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage18.Size = new System.Drawing.Size(930, 711);
            this.tabPage18.TabIndex = 8;
            this.tabPage18.Text = "Telecom ELEC report files";
            this.tabPage18.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(40, 625);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(837, 63);
            this.textBox2.TabIndex = 1;
            // 
            // dataGridView26
            // 
            this.dataGridView26.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView26.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView26.Location = new System.Drawing.Point(40, 16);
            this.dataGridView26.Name = "dataGridView26";
            this.dataGridView26.Size = new System.Drawing.Size(837, 584);
            this.dataGridView26.TabIndex = 0;
            // 
            // tabPage19
            // 
            this.tabPage19.BackColor = System.Drawing.Color.Transparent;
            this.tabPage19.Controls.Add(this.groupBox6);
            this.tabPage19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage19.Location = new System.Drawing.Point(4, 23);
            this.tabPage19.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage19.Size = new System.Drawing.Size(930, 711);
            this.tabPage19.TabIndex = 1;
            this.tabPage19.Text = "Infa Prod";
            this.tabPage19.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView27);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.dataGridView28);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.dataGridView29);
            this.groupBox6.Controls.Add(this.label41);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(912, 668);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Production";
            // 
            // dataGridView27
            // 
            this.dataGridView27.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView27.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView27.Location = new System.Drawing.Point(7, 328);
            this.dataGridView27.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView27.Name = "dataGridView27";
            this.dataGridView27.Size = new System.Drawing.Size(895, 186);
            this.dataGridView27.TabIndex = 10;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(4, 310);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(153, 14);
            this.label39.TabIndex = 9;
            this.label39.Text = "Workflows ran past 7 days";
            // 
            // dataGridView28
            // 
            this.dataGridView28.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView28.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView28.Location = new System.Drawing.Point(7, 177);
            this.dataGridView28.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView28.Name = "dataGridView28";
            this.dataGridView28.Size = new System.Drawing.Size(895, 129);
            this.dataGridView28.TabIndex = 8;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(7, 160);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(128, 14);
            this.label40.TabIndex = 7;
            this.label40.Text = "Workflows scheduled";
            // 
            // dataGridView29
            // 
            this.dataGridView29.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView29.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView29.Location = new System.Drawing.Point(7, 50);
            this.dataGridView29.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView29.Name = "dataGridView29";
            this.dataGridView29.Size = new System.Drawing.Size(895, 107);
            this.dataGridView29.TabIndex = 6;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(7, 33);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(166, 14);
            this.label41.TabIndex = 5;
            this.label41.Text = "Workflows currently running";
            // 
            // tabPage20
            // 
            this.tabPage20.BackColor = System.Drawing.Color.Transparent;
            this.tabPage20.Controls.Add(this.dataGridView30);
            this.tabPage20.Controls.Add(this.label42);
            this.tabPage20.Controls.Add(this.dataGridView31);
            this.tabPage20.Controls.Add(this.label43);
            this.tabPage20.Controls.Add(this.dataGridView32);
            this.tabPage20.Controls.Add(this.label44);
            this.tabPage20.Location = new System.Drawing.Point(4, 23);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage20.Size = new System.Drawing.Size(930, 711);
            this.tabPage20.TabIndex = 2;
            this.tabPage20.Text = "Infa Dev";
            this.tabPage20.UseVisualStyleBackColor = true;
            // 
            // dataGridView30
            // 
            this.dataGridView30.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView30.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView30.Location = new System.Drawing.Point(16, 310);
            this.dataGridView30.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView30.Name = "dataGridView30";
            this.dataGridView30.Size = new System.Drawing.Size(895, 186);
            this.dataGridView30.TabIndex = 16;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(13, 292);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(153, 14);
            this.label42.TabIndex = 15;
            this.label42.Text = "Workflows ran past 7 days";
            // 
            // dataGridView31
            // 
            this.dataGridView31.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView31.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView31.Location = new System.Drawing.Point(16, 159);
            this.dataGridView31.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView31.Name = "dataGridView31";
            this.dataGridView31.Size = new System.Drawing.Size(895, 129);
            this.dataGridView31.TabIndex = 14;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(16, 142);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(128, 14);
            this.label43.TabIndex = 13;
            this.label43.Text = "Workflows scheduled";
            // 
            // dataGridView32
            // 
            this.dataGridView32.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView32.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView32.Location = new System.Drawing.Point(16, 32);
            this.dataGridView32.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView32.Name = "dataGridView32";
            this.dataGridView32.Size = new System.Drawing.Size(895, 107);
            this.dataGridView32.TabIndex = 12;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(16, 15);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(166, 14);
            this.label44.TabIndex = 11;
            this.label44.Text = "Workflows currently running";
            // 
            // tabPage21
            // 
            this.tabPage21.Controls.Add(this.webBrowser10);
            this.tabPage21.Location = new System.Drawing.Point(4, 23);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Size = new System.Drawing.Size(930, 711);
            this.tabPage21.TabIndex = 9;
            this.tabPage21.Text = "Cognos 8 Prod";
            this.tabPage21.UseVisualStyleBackColor = true;
            // 
            // webBrowser10
            // 
            this.webBrowser10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser10.Location = new System.Drawing.Point(0, 0);
            this.webBrowser10.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser10.Name = "webBrowser10";
            this.webBrowser10.Size = new System.Drawing.Size(930, 711);
            this.webBrowser10.TabIndex = 0;
            this.webBrowser10.Url = new System.Uri("http://advibi2/cognos8", System.UriKind.Absolute);
            // 
            // tabPage22
            // 
            this.tabPage22.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage22.Controls.Add(this.label53);
            this.tabPage22.Controls.Add(this.button6);
            this.tabPage22.Controls.Add(this.dataGridView33);
            this.tabPage22.Location = new System.Drawing.Point(4, 42);
            this.tabPage22.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage22.Size = new System.Drawing.Size(930, 692);
            this.tabPage22.TabIndex = 0;
            this.tabPage22.Text = "Status";
            this.tabPage22.ToolTipText = "Process Status";
            this.tabPage22.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(255, 419);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(78, 13);
            this.label53.TabIndex = 2;
            this.label53.Text = "Last  updated: ";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(703, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Refresh";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dataGridView33
            // 
            this.dataGridView33.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView33.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewLinkColumn3,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView33.Location = new System.Drawing.Point(258, 71);
            this.dataGridView33.Name = "dataGridView33";
            this.dataGridView33.ReadOnly = true;
            this.dataGridView33.Size = new System.Drawing.Size(379, 345);
            this.dataGridView33.TabIndex = 0;
            // 
            // dataGridViewLinkColumn3
            // 
            this.dataGridViewLinkColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewLinkColumn3.HeaderText = "Process";
            this.dataGridViewLinkColumn3.Name = "dataGridViewLinkColumn3";
            this.dataGridViewLinkColumn3.ReadOnly = true;
            this.dataGridViewLinkColumn3.Width = 51;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Status";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 62;
            // 
            // tabPage23
            // 
            this.tabPage23.BackColor = System.Drawing.Color.Transparent;
            this.tabPage23.Controls.Add(this.groupBox9);
            this.tabPage23.Location = new System.Drawing.Point(4, 42);
            this.tabPage23.Name = "tabPage23";
            this.tabPage23.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage23.Size = new System.Drawing.Size(930, 692);
            this.tabPage23.TabIndex = 3;
            this.tabPage23.Text = "FIQ BI Reporting";
            this.tabPage23.ToolTipText = "FIQ/BI Cognos 7 processes";
            this.tabPage23.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.webBrowser11);
            this.groupBox9.Controls.Add(this.button7);
            this.groupBox9.Controls.Add(this.webBrowser12);
            this.groupBox9.Controls.Add(this.webBrowser13);
            this.groupBox9.Controls.Add(this.webBrowser14);
            this.groupBox9.Location = new System.Drawing.Point(9, -113);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Size = new System.Drawing.Size(912, 818);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "FIQ BI process status";
            // 
            // webBrowser11
            // 
            this.webBrowser11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser11.Location = new System.Drawing.Point(460, 119);
            this.webBrowser11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser11.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser11.Name = "webBrowser11";
            this.webBrowser11.Size = new System.Drawing.Size(442, 340);
            this.webBrowser11.TabIndex = 6;
            this.webBrowser11.Url = new System.Uri("http://unixmgt01/bb/html/advbi3.Build.html", System.UriKind.Absolute);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(816, 785);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(88, 27);
            this.button7.TabIndex = 1;
            this.button7.Text = "Refresh";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // webBrowser12
            // 
            this.webBrowser12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser12.Location = new System.Drawing.Point(460, 465);
            this.webBrowser12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser12.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser12.Name = "webBrowser12";
            this.webBrowser12.Size = new System.Drawing.Size(442, 314);
            this.webBrowser12.TabIndex = 8;
            this.webBrowser12.Url = new System.Uri("http://unixmgt01/bb/html/advcog1.Migrate.html", System.UriKind.Absolute);
            // 
            // webBrowser13
            // 
            this.webBrowser13.Location = new System.Drawing.Point(-2, 119);
            this.webBrowser13.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser13.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser13.Name = "webBrowser13";
            this.webBrowser13.Size = new System.Drawing.Size(442, 340);
            this.webBrowser13.TabIndex = 4;
            this.webBrowser13.Url = new System.Uri("http://unixmgt01/bb/html/advbi2.Build.html", System.UriKind.Absolute);
            // 
            // webBrowser14
            // 
            this.webBrowser14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.webBrowser14.Location = new System.Drawing.Point(-2, 465);
            this.webBrowser14.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.webBrowser14.MinimumSize = new System.Drawing.Size(24, 22);
            this.webBrowser14.Name = "webBrowser14";
            this.webBrowser14.Size = new System.Drawing.Size(442, 318);
            this.webBrowser14.TabIndex = 7;
            this.webBrowser14.Url = new System.Uri("http://unixmgt01/bb/html/advibi2.Migrate.html", System.UriKind.Absolute);
            // 
            // tabPage24
            // 
            this.tabPage24.BackColor = System.Drawing.Color.Transparent;
            this.tabPage24.Controls.Add(this.dataGridView34);
            this.tabPage24.Controls.Add(this.label54);
            this.tabPage24.Controls.Add(this.dataGridView35);
            this.tabPage24.Controls.Add(this.label55);
            this.tabPage24.Controls.Add(this.label56);
            this.tabPage24.Controls.Add(this.dataGridView36);
            this.tabPage24.Controls.Add(this.dataGridView37);
            this.tabPage24.Controls.Add(this.dataGridView38);
            this.tabPage24.Controls.Add(this.label57);
            this.tabPage24.Controls.Add(this.label58);
            this.tabPage24.Location = new System.Drawing.Point(4, 42);
            this.tabPage24.Name = "tabPage24";
            this.tabPage24.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage24.Size = new System.Drawing.Size(930, 692);
            this.tabPage24.TabIndex = 4;
            this.tabPage24.Text = "IBI";
            this.tabPage24.ToolTipText = "IBI Cognos 8 processes";
            this.tabPage24.UseVisualStyleBackColor = true;
            // 
            // dataGridView34
            // 
            this.dataGridView34.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView34.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView34.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView34.Location = new System.Drawing.Point(14, 627);
            this.dataGridView34.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView34.Name = "dataGridView34";
            this.dataGridView34.ReadOnly = true;
            this.dataGridView34.Size = new System.Drawing.Size(903, 78);
            this.dataGridView34.TabIndex = 13;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(11, 610);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(75, 14);
            this.label54.TabIndex = 12;
            this.label54.Text = "EDW Metrics";
            // 
            // dataGridView35
            // 
            this.dataGridView35.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView35.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView35.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView35.Location = new System.Drawing.Point(14, 272);
            this.dataGridView35.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView35.Name = "dataGridView35";
            this.dataGridView35.ReadOnly = true;
            this.dataGridView35.Size = new System.Drawing.Size(903, 142);
            this.dataGridView35.TabIndex = 11;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(11, 255);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(74, 14);
            this.label55.TabIndex = 10;
            this.label55.Text = "ODS Metrics";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(11, 5);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(151, 13);
            this.label56.TabIndex = 8;
            this.label56.Text = "IBI EDW Workflow status";
            // 
            // dataGridView36
            // 
            this.dataGridView36.AllowUserToAddRows = false;
            this.dataGridView36.AllowUserToDeleteRows = false;
            this.dataGridView36.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView36.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView36.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView36.Location = new System.Drawing.Point(14, 21);
            this.dataGridView36.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView36.Name = "dataGridView36";
            this.dataGridView36.Size = new System.Drawing.Size(903, 48);
            this.dataGridView36.TabIndex = 9;
            // 
            // dataGridView37
            // 
            this.dataGridView37.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView37.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView37.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView37.Location = new System.Drawing.Point(14, 434);
            this.dataGridView37.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView37.Name = "dataGridView37";
            this.dataGridView37.ReadOnly = true;
            this.dataGridView37.Size = new System.Drawing.Size(903, 160);
            this.dataGridView37.TabIndex = 7;
            // 
            // dataGridView38
            // 
            this.dataGridView38.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView38.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView38.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView38.Location = new System.Drawing.Point(14, 103);
            this.dataGridView38.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView38.Name = "dataGridView38";
            this.dataGridView38.ReadOnly = true;
            this.dataGridView38.Size = new System.Drawing.Size(903, 149);
            this.dataGridView38.TabIndex = 5;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(11, 417);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(105, 14);
            this.label57.TabIndex = 6;
            this.label57.Text = "Latest EDW Loads";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(11, 86);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(104, 14);
            this.label58.TabIndex = 4;
            this.label58.Text = "Latest ODS Loads";
            // 
            // tabPage25
            // 
            this.tabPage25.BackColor = System.Drawing.Color.Transparent;
            this.tabPage25.Controls.Add(this.dataGridView39);
            this.tabPage25.Controls.Add(this.label59);
            this.tabPage25.Controls.Add(this.dataGridView40);
            this.tabPage25.Controls.Add(this.label60);
            this.tabPage25.Location = new System.Drawing.Point(4, 42);
            this.tabPage25.Name = "tabPage25";
            this.tabPage25.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage25.Size = new System.Drawing.Size(930, 692);
            this.tabPage25.TabIndex = 5;
            this.tabPage25.Text = "Projections";
            this.tabPage25.ToolTipText = "Projections processes";
            this.tabPage25.UseVisualStyleBackColor = true;
            // 
            // dataGridView39
            // 
            this.dataGridView39.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView39.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView39.Location = new System.Drawing.Point(17, 178);
            this.dataGridView39.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView39.Name = "dataGridView39";
            this.dataGridView39.Size = new System.Drawing.Size(895, 489);
            this.dataGridView39.TabIndex = 13;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(20, 161);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(127, 14);
            this.label59.TabIndex = 12;
            this.label59.Text = "Latest workflow runs";
            // 
            // dataGridView40
            // 
            this.dataGridView40.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView40.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView40.Location = new System.Drawing.Point(17, 36);
            this.dataGridView40.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView40.Name = "dataGridView40";
            this.dataGridView40.Size = new System.Drawing.Size(895, 107);
            this.dataGridView40.TabIndex = 8;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(17, 19);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(166, 14);
            this.label60.TabIndex = 7;
            this.label60.Text = "Workflows currently running";
            // 
            // tabPage26
            // 
            this.tabPage26.BackColor = System.Drawing.Color.Transparent;
            this.tabPage26.Controls.Add(this.dataGridView41);
            this.tabPage26.Controls.Add(this.label61);
            this.tabPage26.Location = new System.Drawing.Point(4, 42);
            this.tabPage26.Name = "tabPage26";
            this.tabPage26.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage26.Size = new System.Drawing.Size(930, 692);
            this.tabPage26.TabIndex = 6;
            this.tabPage26.Text = "Cincinnati Data Transfer";
            this.tabPage26.ToolTipText = "Cincinnati Data Transfer proces";
            this.tabPage26.UseVisualStyleBackColor = true;
            // 
            // dataGridView41
            // 
            this.dataGridView41.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView41.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView41.Location = new System.Drawing.Point(18, 70);
            this.dataGridView41.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView41.Name = "dataGridView41";
            this.dataGridView41.Size = new System.Drawing.Size(895, 420);
            this.dataGridView41.TabIndex = 9;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(21, 53);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(127, 14);
            this.label61.TabIndex = 8;
            this.label61.Text = "Latest workflow runs";
            // 
            // tabPage27
            // 
            this.tabPage27.Controls.Add(this.dataGridView42);
            this.tabPage27.Controls.Add(this.label62);
            this.tabPage27.Location = new System.Drawing.Point(4, 42);
            this.tabPage27.Name = "tabPage27";
            this.tabPage27.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage27.Size = new System.Drawing.Size(930, 692);
            this.tabPage27.TabIndex = 12;
            this.tabPage27.Text = "Cincinnati Savings Transfer";
            this.tabPage27.ToolTipText = "Savings Transfer to Cincinnati";
            this.tabPage27.UseVisualStyleBackColor = true;
            // 
            // dataGridView42
            // 
            this.dataGridView42.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView42.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView42.Location = new System.Drawing.Point(17, 38);
            this.dataGridView42.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView42.Name = "dataGridView42";
            this.dataGridView42.Size = new System.Drawing.Size(895, 632);
            this.dataGridView42.TabIndex = 11;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(20, 21);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(127, 14);
            this.label62.TabIndex = 10;
            this.label62.Text = "Latest workflow runs";
            // 
            // tabPage28
            // 
            this.tabPage28.BackColor = System.Drawing.Color.Transparent;
            this.tabPage28.Controls.Add(this.dataGridView43);
            this.tabPage28.Controls.Add(this.label63);
            this.tabPage28.Location = new System.Drawing.Point(4, 42);
            this.tabPage28.Name = "tabPage28";
            this.tabPage28.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage28.Size = new System.Drawing.Size(930, 692);
            this.tabPage28.TabIndex = 7;
            this.tabPage28.Text = "PPE Data Load";
            this.tabPage28.ToolTipText = "Data load into PPE 1 and PPE 2";
            this.tabPage28.UseVisualStyleBackColor = true;
            // 
            // dataGridView43
            // 
            this.dataGridView43.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView43.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView43.Location = new System.Drawing.Point(13, 32);
            this.dataGridView43.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView43.Name = "dataGridView43";
            this.dataGridView43.Size = new System.Drawing.Size(895, 420);
            this.dataGridView43.TabIndex = 11;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(16, 15);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(127, 14);
            this.label63.TabIndex = 10;
            this.label63.Text = "Latest workflow runs";
            // 
            // tabPage29
            // 
            this.tabPage29.BackColor = System.Drawing.Color.Transparent;
            this.tabPage29.Controls.Add(this.textBox3);
            this.tabPage29.Controls.Add(this.dataGridView44);
            this.tabPage29.Location = new System.Drawing.Point(4, 42);
            this.tabPage29.Name = "tabPage29";
            this.tabPage29.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage29.Size = new System.Drawing.Size(930, 692);
            this.tabPage29.TabIndex = 8;
            this.tabPage29.Text = "Telecom ELEC report files";
            this.tabPage29.ToolTipText = "ELEC Inventory file creation";
            this.tabPage29.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(40, 625);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(837, 63);
            this.textBox3.TabIndex = 1;
            // 
            // dataGridView44
            // 
            this.dataGridView44.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView44.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView44.Location = new System.Drawing.Point(40, 16);
            this.dataGridView44.Name = "dataGridView44";
            this.dataGridView44.Size = new System.Drawing.Size(837, 584);
            this.dataGridView44.TabIndex = 0;
            // 
            // tabPage30
            // 
            this.tabPage30.BackColor = System.Drawing.Color.Transparent;
            this.tabPage30.Controls.Add(this.groupBox10);
            this.tabPage30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage30.Location = new System.Drawing.Point(4, 42);
            this.tabPage30.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage30.Name = "tabPage30";
            this.tabPage30.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage30.Size = new System.Drawing.Size(930, 692);
            this.tabPage30.TabIndex = 1;
            this.tabPage30.Text = "Informatica 8.1 Production";
            this.tabPage30.ToolTipText = "Informatica 8.1 Production Stats";
            this.tabPage30.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dataGridView45);
            this.groupBox10.Controls.Add(this.label64);
            this.groupBox10.Controls.Add(this.dataGridView46);
            this.groupBox10.Controls.Add(this.label65);
            this.groupBox10.Controls.Add(this.dataGridView47);
            this.groupBox10.Controls.Add(this.label66);
            this.groupBox10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(7, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(912, 668);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Production";
            // 
            // dataGridView45
            // 
            this.dataGridView45.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView45.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView45.Location = new System.Drawing.Point(7, 328);
            this.dataGridView45.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView45.Name = "dataGridView45";
            this.dataGridView45.Size = new System.Drawing.Size(895, 186);
            this.dataGridView45.TabIndex = 10;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(4, 310);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(153, 14);
            this.label64.TabIndex = 9;
            this.label64.Text = "Workflows ran past 7 days";
            // 
            // dataGridView46
            // 
            this.dataGridView46.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView46.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView46.Location = new System.Drawing.Point(7, 177);
            this.dataGridView46.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView46.Name = "dataGridView46";
            this.dataGridView46.Size = new System.Drawing.Size(895, 129);
            this.dataGridView46.TabIndex = 8;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(7, 160);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(128, 14);
            this.label65.TabIndex = 7;
            this.label65.Text = "Workflows scheduled";
            // 
            // dataGridView47
            // 
            this.dataGridView47.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView47.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView47.Location = new System.Drawing.Point(7, 50);
            this.dataGridView47.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView47.Name = "dataGridView47";
            this.dataGridView47.Size = new System.Drawing.Size(895, 107);
            this.dataGridView47.TabIndex = 6;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(7, 33);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(166, 14);
            this.label66.TabIndex = 5;
            this.label66.Text = "Workflows currently running";
            // 
            // tabPage31
            // 
            this.tabPage31.BackColor = System.Drawing.Color.Transparent;
            this.tabPage31.Controls.Add(this.dataGridView48);
            this.tabPage31.Controls.Add(this.label67);
            this.tabPage31.Controls.Add(this.dataGridView49);
            this.tabPage31.Controls.Add(this.label68);
            this.tabPage31.Controls.Add(this.dataGridView50);
            this.tabPage31.Controls.Add(this.label69);
            this.tabPage31.Location = new System.Drawing.Point(4, 42);
            this.tabPage31.Name = "tabPage31";
            this.tabPage31.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage31.Size = new System.Drawing.Size(930, 692);
            this.tabPage31.TabIndex = 2;
            this.tabPage31.Text = "Informatica 8.1 Development";
            this.tabPage31.ToolTipText = "Informatica 8.1 Development Stats";
            this.tabPage31.UseVisualStyleBackColor = true;
            // 
            // dataGridView48
            // 
            this.dataGridView48.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView48.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView48.Location = new System.Drawing.Point(16, 310);
            this.dataGridView48.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView48.Name = "dataGridView48";
            this.dataGridView48.Size = new System.Drawing.Size(895, 186);
            this.dataGridView48.TabIndex = 16;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(13, 292);
            this.label67.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(153, 14);
            this.label67.TabIndex = 15;
            this.label67.Text = "Workflows ran past 7 days";
            // 
            // dataGridView49
            // 
            this.dataGridView49.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView49.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView49.Location = new System.Drawing.Point(16, 159);
            this.dataGridView49.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView49.Name = "dataGridView49";
            this.dataGridView49.Size = new System.Drawing.Size(895, 129);
            this.dataGridView49.TabIndex = 14;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(16, 142);
            this.label68.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(128, 14);
            this.label68.TabIndex = 13;
            this.label68.Text = "Workflows scheduled";
            // 
            // dataGridView50
            // 
            this.dataGridView50.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView50.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView50.Location = new System.Drawing.Point(16, 32);
            this.dataGridView50.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView50.Name = "dataGridView50";
            this.dataGridView50.Size = new System.Drawing.Size(895, 107);
            this.dataGridView50.TabIndex = 12;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.Location = new System.Drawing.Point(16, 15);
            this.label69.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(166, 14);
            this.label69.TabIndex = 11;
            this.label69.Text = "Workflows currently running";
            // 
            // tabPage32
            // 
            this.tabPage32.Controls.Add(this.webBrowser15);
            this.tabPage32.Location = new System.Drawing.Point(4, 42);
            this.tabPage32.Name = "tabPage32";
            this.tabPage32.Size = new System.Drawing.Size(930, 692);
            this.tabPage32.TabIndex = 9;
            this.tabPage32.Text = "Cognos 8 Prod";
            this.tabPage32.ToolTipText = "Cognos 8 service stats";
            this.tabPage32.UseVisualStyleBackColor = true;
            // 
            // webBrowser15
            // 
            this.webBrowser15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser15.Location = new System.Drawing.Point(0, 0);
            this.webBrowser15.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser15.Name = "webBrowser15";
            this.webBrowser15.Size = new System.Drawing.Size(930, 692);
            this.webBrowser15.TabIndex = 0;
            this.webBrowser15.Url = new System.Uri("http://advibi2/cognos8", System.UriKind.Absolute);
            // 
            // tabPage33
            // 
            this.tabPage33.BackColor = System.Drawing.Color.Transparent;
            this.tabPage33.Controls.Add(this.groupBox11);
            this.tabPage33.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage33.Location = new System.Drawing.Point(4, 42);
            this.tabPage33.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage33.Name = "tabPage33";
            this.tabPage33.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage33.Size = new System.Drawing.Size(930, 692);
            this.tabPage33.TabIndex = 10;
            this.tabPage33.Text = "Informatica 8.6 Production";
            this.tabPage33.ToolTipText = "Informatica 8.6 Production Stats";
            this.tabPage33.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.dataGridView51);
            this.groupBox11.Controls.Add(this.label70);
            this.groupBox11.Controls.Add(this.dataGridView52);
            this.groupBox11.Controls.Add(this.label71);
            this.groupBox11.Controls.Add(this.dataGridView53);
            this.groupBox11.Controls.Add(this.label72);
            this.groupBox11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(7, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(912, 668);
            this.groupBox11.TabIndex = 7;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Production";
            // 
            // dataGridView51
            // 
            this.dataGridView51.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView51.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView51.Location = new System.Drawing.Point(7, 328);
            this.dataGridView51.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView51.Name = "dataGridView51";
            this.dataGridView51.Size = new System.Drawing.Size(895, 186);
            this.dataGridView51.TabIndex = 10;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(4, 310);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(153, 14);
            this.label70.TabIndex = 9;
            this.label70.Text = "Workflows ran past 7 days";
            // 
            // dataGridView52
            // 
            this.dataGridView52.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView52.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView52.Location = new System.Drawing.Point(7, 177);
            this.dataGridView52.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView52.Name = "dataGridView52";
            this.dataGridView52.Size = new System.Drawing.Size(895, 129);
            this.dataGridView52.TabIndex = 8;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(7, 160);
            this.label71.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(128, 14);
            this.label71.TabIndex = 7;
            this.label71.Text = "Workflows scheduled";
            // 
            // dataGridView53
            // 
            this.dataGridView53.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView53.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView53.Location = new System.Drawing.Point(7, 50);
            this.dataGridView53.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView53.Name = "dataGridView53";
            this.dataGridView53.Size = new System.Drawing.Size(895, 107);
            this.dataGridView53.TabIndex = 6;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(7, 33);
            this.label72.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(166, 14);
            this.label72.TabIndex = 5;
            this.label72.Text = "Workflows currently running";
            // 
            // tabPage34
            // 
            this.tabPage34.BackColor = System.Drawing.Color.Transparent;
            this.tabPage34.Controls.Add(this.groupBox12);
            this.tabPage34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage34.Location = new System.Drawing.Point(4, 42);
            this.tabPage34.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage34.Name = "tabPage34";
            this.tabPage34.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage34.Size = new System.Drawing.Size(930, 692);
            this.tabPage34.TabIndex = 11;
            this.tabPage34.Text = "Informatica 8.6 Development";
            this.tabPage34.ToolTipText = "Informatica 8.6 Development Stats";
            this.tabPage34.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.dataGridView54);
            this.groupBox12.Controls.Add(this.label73);
            this.groupBox12.Controls.Add(this.dataGridView55);
            this.groupBox12.Controls.Add(this.label74);
            this.groupBox12.Controls.Add(this.dataGridView56);
            this.groupBox12.Controls.Add(this.label75);
            this.groupBox12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(7, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(912, 668);
            this.groupBox12.TabIndex = 7;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Production";
            // 
            // dataGridView54
            // 
            this.dataGridView54.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView54.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView54.Location = new System.Drawing.Point(7, 328);
            this.dataGridView54.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView54.Name = "dataGridView54";
            this.dataGridView54.Size = new System.Drawing.Size(895, 186);
            this.dataGridView54.TabIndex = 10;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(4, 310);
            this.label73.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(153, 14);
            this.label73.TabIndex = 9;
            this.label73.Text = "Workflows ran past 7 days";
            // 
            // dataGridView55
            // 
            this.dataGridView55.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView55.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView55.Location = new System.Drawing.Point(7, 177);
            this.dataGridView55.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView55.Name = "dataGridView55";
            this.dataGridView55.Size = new System.Drawing.Size(895, 129);
            this.dataGridView55.TabIndex = 8;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(7, 160);
            this.label74.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(128, 14);
            this.label74.TabIndex = 7;
            this.label74.Text = "Workflows scheduled";
            // 
            // dataGridView56
            // 
            this.dataGridView56.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView56.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView56.Location = new System.Drawing.Point(7, 50);
            this.dataGridView56.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView56.Name = "dataGridView56";
            this.dataGridView56.Size = new System.Drawing.Size(895, 107);
            this.dataGridView56.TabIndex = 6;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(7, 33);
            this.label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(166, 14);
            this.label75.TabIndex = 5;
            this.label75.Text = "Workflows currently running";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 817);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "BI Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusSummary)).EndInit();
            this.tabPageFIQBI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFIQBISummary)).EndInit();
            this.tabPageIBI.ResumeLayout(false);
            this.tabPageIBI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvC8ReportsRan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEDWMetrics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvODSMetrics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eDWWfResultsTableDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestEDWLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLatestODSLoad)).EndInit();
            this.tabPageProjections.ResumeLayout(false);
            this.tabPageProjections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectionsLoads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjections)).EndInit();
            this.tabPageCinciDT.ResumeLayout(false);
            this.tabPageCinciDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinciDataLoads)).EndInit();
            this.tabPageSavings.ResumeLayout(false);
            this.tabPageSavings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinciSavingsLoads)).EndInit();
            this.tabPagePPEDataLoad.ResumeLayout(false);
            this.tabPagePPEDataLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPEDataLoad)).EndInit();
            this.tabELECFiles.ResumeLayout(false);
            this.tabELECFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvELECFiles)).EndInit();
            this.tabPageStatsProd.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWFLastWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdWFScheduled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdWFRunning)).EndInit();
            this.tabStatsDev.ResumeLayout(false);
            this.tabStatsDev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFPast7Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFScheduled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevWFRunning)).EndInit();
            this.tabPageCognos.ResumeLayout(false);
            this.tabPageStatsProd86.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFLastWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFScheduled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProd86WFRunning)).EndInit();
            this.tabPageInfa86Dev.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFLastWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFScheduled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDev86WFRunning)).EndInit();
            this.tabPagePDSProd.ResumeLayout(false);
            this.tabPagePDSProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDSProdLatestestWfs)).EndInit();
            this.tabPagePDSDev.ResumeLayout(false);
            this.tabPagePDSDev.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDSDevLatestWfs)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView13)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView16)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView17)).EndInit();
            this.tabPage13.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView22)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView23)).EndInit();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView24)).EndInit();
            this.tabPage17.ResumeLayout(false);
            this.tabPage17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView25)).EndInit();
            this.tabPage18.ResumeLayout(false);
            this.tabPage18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView26)).EndInit();
            this.tabPage19.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView29)).EndInit();
            this.tabPage20.ResumeLayout(false);
            this.tabPage20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView32)).EndInit();
            this.tabPage21.ResumeLayout(false);
            this.tabPage22.ResumeLayout(false);
            this.tabPage22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView33)).EndInit();
            this.tabPage23.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.tabPage24.ResumeLayout(false);
            this.tabPage24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView38)).EndInit();
            this.tabPage25.ResumeLayout(false);
            this.tabPage25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView40)).EndInit();
            this.tabPage26.ResumeLayout(false);
            this.tabPage26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView41)).EndInit();
            this.tabPage27.ResumeLayout(false);
            this.tabPage27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView42)).EndInit();
            this.tabPage28.ResumeLayout(false);
            this.tabPage28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView43)).EndInit();
            this.tabPage29.ResumeLayout(false);
            this.tabPage29.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView44)).EndInit();
            this.tabPage30.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView47)).EndInit();
            this.tabPage31.ResumeLayout(false);
            this.tabPage31.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView50)).EndInit();
            this.tabPage32.ResumeLayout(false);
            this.tabPage33.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView53)).EndInit();
            this.tabPage34.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView56)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPageStatsProd;
        private System.Windows.Forms.DataGridView dgvProdWFRunning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvWFLastWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvProdWFScheduled;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabStatsDev;
        private System.Windows.Forms.DataGridView dgvDevWFPast7Days;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDevWFScheduled;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDevWFRunning;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPageFIQBI;
        private System.Windows.Forms.TabPage tabPageIBI;
        private System.Windows.Forms.TabPage tabPageProjections;
        private System.Windows.Forms.TabPage tabPageCinciDT;
        private System.Windows.Forms.TabPage tabPagePPEDataLoad;
        private System.Windows.Forms.TabPage tabELECFiles;
        private System.Windows.Forms.WebBrowser wbADVBI3;
        private System.Windows.Forms.WebBrowser wbADVCOG1;
        private System.Windows.Forms.WebBrowser wbADVBI2;
        private System.Windows.Forms.WebBrowser wbADVIBI2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView eDWWfResultsTableDataGridView;
        private System.Windows.Forms.DataGridView dgvLatestEDWLoad;
        private System.Windows.Forms.DataGridView dgvLatestODSLoad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvProjections;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvCinciDataLoads;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvStatusSummary;
        private System.Windows.Forms.DataGridView dgvELECFiles;
        private System.Windows.Forms.TextBox tbELECFilesLogFile;
        private System.Windows.Forms.Button btnRefreshSummary;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.DataGridView dgvODSMetrics;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvEDWMetrics;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvPPEDataLoad;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPageCognos;
        private System.Windows.Forms.WebBrowser webBrowserCognos8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.WebBrowser webBrowser4;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridView9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView10;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView11;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dataGridView12;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dataGridView13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.DataGridView dataGridView14;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DataGridView dataGridView15;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DataGridView dataGridView16;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.WebBrowser webBrowser5;
        private System.Windows.Forms.TabPage tabPageStatsProd86;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvProd86WFLastWeek;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DataGridView dgvProd86WFScheduled;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.DataGridView dgvProd86WFRunning;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView17;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.WebBrowser webBrowser6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.WebBrowser webBrowser7;
        private System.Windows.Forms.WebBrowser webBrowser8;
        private System.Windows.Forms.WebBrowser webBrowser9;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.DataGridView dataGridView18;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DataGridView dataGridView19;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridView dataGridView20;
        private System.Windows.Forms.DataGridView dataGridView21;
        private System.Windows.Forms.DataGridView dataGridView22;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.DataGridView dataGridView23;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.DataGridView dataGridView24;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.DataGridView dataGridView25;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TabPage tabPage18;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView26;
        private System.Windows.Forms.TabPage tabPage19;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView27;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.DataGridView dataGridView28;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dataGridView29;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TabPage tabPage20;
        private System.Windows.Forms.DataGridView dataGridView30;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.DataGridView dataGridView31;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DataGridView dataGridView32;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TabPage tabPage21;
        private System.Windows.Forms.WebBrowser webBrowser10;
        private System.Windows.Forms.TabPage tabPageInfa86Dev;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dgvDev86WFLastWeek;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.DataGridView dgvDev86WFScheduled;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.DataGridView dgvDev86WFRunning;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TabPage tabPageSavings;
        private System.Windows.Forms.DataGridView dgvCinciSavingsLoads;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.DataGridViewLinkColumn ProcessColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridView dgvProjectionsLoads;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TabPage tabPage22;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView33;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewLinkColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabPage tabPage23;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.WebBrowser webBrowser11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.WebBrowser webBrowser12;
        private System.Windows.Forms.WebBrowser webBrowser13;
        private System.Windows.Forms.WebBrowser webBrowser14;
        private System.Windows.Forms.TabPage tabPage24;
        private System.Windows.Forms.DataGridView dataGridView34;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.DataGridView dataGridView35;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.DataGridView dataGridView36;
        private System.Windows.Forms.DataGridView dataGridView37;
        private System.Windows.Forms.DataGridView dataGridView38;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TabPage tabPage25;
        private System.Windows.Forms.DataGridView dataGridView39;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.DataGridView dataGridView40;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TabPage tabPage26;
        private System.Windows.Forms.DataGridView dataGridView41;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TabPage tabPage27;
        private System.Windows.Forms.DataGridView dataGridView42;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TabPage tabPage28;
        private System.Windows.Forms.DataGridView dataGridView43;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TabPage tabPage29;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView44;
        private System.Windows.Forms.TabPage tabPage30;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dataGridView45;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.DataGridView dataGridView46;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.DataGridView dataGridView47;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TabPage tabPage31;
        private System.Windows.Forms.DataGridView dataGridView48;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.DataGridView dataGridView49;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.DataGridView dataGridView50;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TabPage tabPage32;
        private System.Windows.Forms.WebBrowser webBrowser15;
        private System.Windows.Forms.TabPage tabPage33;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.DataGridView dataGridView51;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.DataGridView dataGridView52;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.DataGridView dataGridView53;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TabPage tabPage34;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dataGridView54;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.DataGridView dataGridView55;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.DataGridView dataGridView56;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TabPage tabPagePDSProd;
        private System.Windows.Forms.DataGridView dgvPDSProdLatestestWfs;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TabPage tabPagePDSDev;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Button btnTruncateTables;
        private System.Windows.Forms.Button btnSetupTrainingDL;
        private System.Windows.Forms.Button btnSchedulePDSWorkflow;
        private System.Windows.Forms.MaskedTextBox tbSQLServerIPAddress;
        private System.Windows.Forms.MaskedTextBox tbOracleIPAddress;
        private System.Windows.Forms.DataGridView dgvFIQBISummary;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TextBox tbSelectedWorkflow;
        private System.Windows.Forms.Button btnScheduleWorkflow;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Button btnStartPDSDevWorkflow;
        private System.Windows.Forms.DataGridView dgvPDSDevLatestWfs;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button btnRefreshInfaDev;
        private System.Windows.Forms.Button btnPDSLoadFilterLinkages;
        private System.Windows.Forms.Button btnPDSLoadMetadata;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.DataGridView dgvC8ReportsRan;
    }
}

