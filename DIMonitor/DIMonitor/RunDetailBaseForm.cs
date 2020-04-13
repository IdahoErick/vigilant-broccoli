using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DIMonitor
{
    public partial class RunDetailBaseForm : Form
    {
        private ToolStripStatusLabel _toolStripStatusLabel;

        public ToolStripStatusLabel ToolStripStatusLabel
        {
            get { return _toolStripStatusLabel; }
            set { _toolStripStatusLabel = value; }
        }

        private Utility.BU _bU;
        private Utility.ENV _eNV;
        
        public Utility.ENV ENV
        {
            get { return _eNV; }
            set { _eNV = value; }
        }
        private Utility.PERIOD _period;

        public Utility.PERIOD Period
        {
            get { return _period; }
            set { _period = value; }
        }
        public string EnglishPeriod
        {
            get { return _period.ToString()=="DAG"?"DAY":"MONTH"; }
        }

        private SQLDBAccess _sqlDA = new SQLDBAccess();

        public SQLDBAccess SqlDA
        {
            get { return _sqlDA; }
            set { _sqlDA = value; }
        }
        private Boolean _sortAsc = true;

        public Boolean SortAsc
        {
            get { return _sortAsc; }
            set { _sortAsc = value; }
        }
        private Int64 _ssisRunID = 0;

        public Int64 SsisRunID
        {
            get { return _ssisRunID; }
            set { _ssisRunID = value; }
        }

        public Utility.BU BU
        {
            get { return _bU; }
            set { _bU = value; }
        }

        DateTime _calendarDate;

        public DateTime CalendarDate
        {
            get { return _calendarDate; }
            set { _calendarDate = value; }
        }

        private int _ILRunID;

        public int ILRunID
        {
            get { return _ILRunID; }
            set { _ILRunID = value; }
        }

        private List<clsILProcess> _processList = new List<clsILProcess>();

        internal List<clsILProcess> ProcessList
        {
            get { return _processList; }
            set { _processList = value; }
        }
        private List<clsRunDetail> _runDetailList = new List<clsRunDetail>();

        internal List<clsRunDetail> RunDetailList
        {
            get { return _runDetailList; }
            set { _runDetailList = value; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
        protected void Init(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, int ILRunID, Int64 ssisRunID, DateTime calendarDate, ToolStripStatusLabel toolStripStatusLabel)
        {
            _eNV = eNV;
            _period = period;
            _bU = bU;
            _ILRunID = ILRunID;
            _ssisRunID = ssisRunID;
            _calendarDate = calendarDate;
            _toolStripStatusLabel = toolStripStatusLabel;

            Refresh();
        }
        public override void Refresh()
        {
        }

        protected void FillCalendarDateDropbox(DateTime kalenderDatum, ComboBox cbCalendarDates)
        {
            string sqlQuery = (BU==Utility.BU.ILVB ? SQLQueries.SQL_CALENDAR_DATES_ILH : SQLQueries.SQL_CALENDAR_DATES_ILSB).Replace("<period>", Period.ToString());
            DataSet ds = SqlDA.GetQueryDataSet(Utility.GetConnectionString(this.ENV, this.BU, Period, false), sqlQuery, false);

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
        protected void LoadDetailsList(DataTable dtDetails)
        {
            foreach (DataColumn dc in dtDetails.Columns)
            {
                clsRunDetail rd = _runDetailList.Find(x => x.Name.Equals(dc.Caption));
                if (rd != null)
                {
                    rd.SetValue(dtDetails.Rows[0][dc.Caption].ToString());
                    rd.UpdateControls();
                }
                else
                    MessageBox.Show("Detail not found in list for column:" + dc.Caption);
            }
        }
        protected string GenerateUpdateQuery()
        {
            bool firstDetail = true;
            StringBuilder query = new StringBuilder("UPDATE ");
            query.Append(BU==Utility.BU.ILVB ? "ILH" : "ILSB");
            query.Append("_METADATA.MDA.KALENDERVERWERKING_");
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
            {
                query.Append(" WHERE ");
                query.Append(BU==Utility.BU.ILVB ? "Kalenderdatum" : "Draaidatum");
                query.AppendFormat(" = '{0}-{1}-{2}'", CalendarDate.Year.ToString("D2"), CalendarDate.Month.ToString("D2"), CalendarDate.Day.ToString("D2"));
            }
            return query.ToString();
        }

        protected string FormatDate4DB(DateTime date)
        {
            return String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day);
        }
        
        protected void GenerateUpdateScript(bool executeScript)
        {
            string query = GenerateUpdateQuery();
            if (query.Length > 0)
            {
                if (executeScript)
                {
                    string cs = Utility.GetConnectionString(ENV, BU, Period);
                    try
                    {
                        int rc = SqlDA.ExecuteSQLCommand(cs, query);
                        if (rc >= 1)
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
                {
                    QueryOutputForm queryForm = new QueryOutputForm(query.ToString());
                    queryForm.Show();
                }
            }
            else
                MessageBox.Show("Nothing to update!");
        }

        protected void AbortRun()
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
                            _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": " + message;
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
                    _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": No valid SSIS Run ID available";
            }
            else
                _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": Function only available on local machine";
        }

        protected void ShowMessage(string exceptionMessage)
        {
            string message = exceptionMessage;
            if (message.Length > 100)
                message = message.Substring(0, 100);
            _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": " + message;
            MessageBox.Show(exceptionMessage);
        }

        public virtual int RefreshData()
        {
            return -1;
        }

        protected void StartRun()
        {
            if (ENV == Utility.ENV.LOCAL)
            {
                try
                {
                    string envMessage = BU.ToString() + " - " + ENV.ToString() + " - " + Period.ToString();

                    if (MessageBox.Show("Start run " + envMessage + " ?", "Start Run", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string cs = Utility.GetConnectionString(ENV, BU, Period);

                        string startRunQuery = (BU == Utility.BU.ILVB ? SQLQueries.SQL_START_RUN_ILH : SQLQueries.SQL_START_RUN_ILSB);
                        startRunQuery = startRunQuery.Replace("<PERIOD>", Period == Utility.PERIOD.MAAND ? "MAAND" : "DAG");
                        startRunQuery = startRunQuery.Replace("<Kalenderdatum>", FormatDate4DB(CalendarDate));

                        int rc = this.SqlDA.ExecuteSQLCommand(cs, startRunQuery);
                        string message = "Run Started, " + envMessage;
                        _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": " + message;
                        MessageBox.Show(message);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    if (message.Length > 100)
                        message = message.Substring(0, 100);
                    _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": " + message;
                    MessageBox.Show(ex.Message);
                }
            }
            else
                _toolStripStatusLabel.Text = DateTime.Now.ToString() + ": Function only available on local machine";
        }
    }
}

