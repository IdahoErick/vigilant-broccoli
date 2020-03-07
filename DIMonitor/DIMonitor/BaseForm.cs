using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIMonitor
{
    public partial class BaseForm : Form
    {
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


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
        protected void Init(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, int ILRunID, Int64 ssisRunID, DateTime calendarDate)
        {
            _eNV = eNV;
            _period = period;
            _bU = bU;
            _ILRunID = ILRunID;
            _ssisRunID = ssisRunID;
            _calendarDate = calendarDate;

            Refresh();
        }
        public override void Refresh()
        {
        }
    }
}

