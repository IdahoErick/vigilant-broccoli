using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace BIFramework
{
    public class OracleDBAccess : BaseDBAccess
    {
        private string SQL_WF_ENABLE_DISABLE_CONSTRAINTS =
            "begin" +
            "			for cur in (select fk.owner, fk.constraint_name , fk.table_name " +
            "				from all_constraints fk, all_constraints pk " +
            "				where fk.CONSTRAINT_TYPE = 'R' and" +
            "				pk.owner = 'EDW' and" +
            "				fk.R_CONSTRAINT_NAME = pk.CONSTRAINT_NAME and " +
            "				lower(pk.TABLE_NAME) = lower('<TABLE_NAME>')) loop" +
            "			    execute immediate 'ALTER TABLE '||cur.owner||'.'||cur.table_name||' MODIFY CONSTRAINT '||cur.constraint_name||' <ENABLE_DISABLE>';" +
            "		   end loop;" +
            "		end;";

        public override DataSet GetQueryDataSet(string connectionString, string sql, bool ignoreExceptions)
        {
            DataSet ds = new DataSet();
            try
            {
                string queryString = sql;
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    OracleDataAdapter da = new OracleDataAdapter(queryString, connection);
                    da.Fill(ds);
                }
                //return ds;
            }
            catch (System.Data.OracleClient.OracleException ex)
            {
                System.Diagnostics.EventLog.WriteEntry("BI Monitor", ex.Message);
                if (ex.InnerException != null)
                    System.Diagnostics.EventLog.WriteEntry("BI Monitor", ex.InnerException.Message);
            }
            catch (Exception)
            {
                // Ignore exceptions on request
                if (!ignoreExceptions)
                    throw;
            }
            return ds;
        }
        public override int ExecuteSQLCommand(string connectionString, string commandText)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                OracleCommand ac = new OracleCommand(commandText, connection);
                return ac.ExecuteNonQuery();
            }
        }
        public override int ExecuteSQLCommandWithParams(string connectionString, string commandText, List<CommandParams> commandParams)
        {
            // Replace the parameters in the command text
            foreach (CommandParams parameters in commandParams)
            {
                commandText = commandText.Replace(parameters.ParamName, parameters.ParamValue);
            }
            // Execute the command
            return ExecuteSQLCommand(connectionString, commandText);
        }
        private int EnableDisableRelatedForeignKeys(string connectionString, string ownerName, string tableName, bool enable)
        {
            string enableDisable = (enable==true)?"Enable":"Disable";
            List<BaseDBAccess.CommandParams> parameters = new List<BaseDBAccess.CommandParams>();
            parameters.Add(new BaseDBAccess.CommandParams("<TABLE_NAME>", tableName));
            parameters.Add(new BaseDBAccess.CommandParams("<OWNER_NAME>", ownerName));
            parameters.Add(new BaseDBAccess.CommandParams("<ENABLE_DISABLE>", enableDisable));
            return ExecuteSQLCommandWithParams(BIFramework.AIQConnectionStrings.ORA_EDW_DEV, SQL_WF_ENABLE_DISABLE_CONSTRAINTS, parameters);
        }
        public override int EnableRelatedForeignKeys(string connectionString, string ownerName, string tableName)
        {
            return EnableDisableRelatedForeignKeys(connectionString, ownerName, tableName, true);
        }
        public override int DisableRelatedForeignKeys(string connectionString, string ownerName, string tableName)
        {
            return EnableDisableRelatedForeignKeys(connectionString, ownerName, tableName, false);
        }
        public object GetNextColumnValue(string connectionString, string ownerName, string tableName, string columnName)
        {
            DataSet resultSet = GetQueryDataSet(connectionString, "select max(" + columnName + ")+1 from " + ownerName + "." + tableName, false);
            return resultSet.Tables[0].Rows[0][0];
        }
    }
}
