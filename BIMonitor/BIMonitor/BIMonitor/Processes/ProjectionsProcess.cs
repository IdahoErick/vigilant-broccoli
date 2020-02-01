using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class ProjectionsProcess : BaseProcess
    {
        private BIFramework.SQLDBAccess sqlDA = new BIFramework.SQLDBAccess();

        internal override String ProcessName
        {
            get
            {
                return "Projections";
            }
        }

        internal DataSet GetProjectionsRuns()
        {
            DataSet ds = sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_RUNNING, false);
            return ds;
        }

        protected override DataView GetDataView(string dataGridViewName, System.Data.DataSet viewDataSet)
        {
            if (dataGridViewName != "dgvProjections")
                return viewDataSet.Tables[0].DefaultView;
            else
            {
                DataView dv = new DataView(viewDataSet.Tables[0], "Name in ('wf_ODS_Projections', 'wf_EDW_Projections')", "Name asc", DataViewRowState.Unchanged);
                Status = (dv.Count == 2) ? ProcessStatus.Success : ProcessStatus.Failed;
                return dv;
            }

        }
        internal DataSet GetLatestDataLoads()
        {
            DataSet ds = sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_PROJECTIONS_LATEST, false);
            return ds;
        }
    }
}
