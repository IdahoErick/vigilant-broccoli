using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DIMonitor
{
    public class SQLDBAccess : BaseDBAccess
    {
        public DataSet GetQueryDataSet(string connectionString, string sql, bool ignoreExceptions, List<CommandParams> commandParams)
        {
            // Replace the parameters in the command text
            foreach (CommandParams parameters in commandParams)
            {
                sql = sql.Replace(parameters.ParamName, parameters.ParamValue);
            }
            // Execute the command
            return GetQueryDataSet(connectionString, sql, ignoreExceptions);
        }
        public override DataSet GetQueryDataSet(string connectionString, string sql, bool ignoreExceptions)
        {
            DataSet ds = new DataSet();
            try
            {
                string queryString = sql;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, connection);
                    da.Fill(ds);
                }
                //return ds;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand ac = new SqlCommand(commandText, connection);
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
        private int EnableDisableRelatedForeignKeys(string connectionString, string ownerName, string tableName, bool enable)
        {
            throw new NotImplementedException();
            //string enableDisable = (enable == true) ? "Enable" : "Disable";
            //List<BaseDBAccess.CommandParams> parameters = new List<BaseDBAccess.CommandParams>();
            //parameters.Add(new BaseDBAccess.CommandParams("<TABLE_NAME>", tableName));
            //parameters.Add(new BaseDBAccess.CommandParams("<OWNER_NAME>", ownerName));
            //parameters.Add(new BaseDBAccess.CommandParams("<ENABLE_DISABLE>", enableDisable));
            //return ExecuteSQLCommandWithParams(BIFramework.AIQConnectionStrings.ORA_EDW_DEV, SQL_WF_ENABLE_DISABLE_CONSTRAINTS, parameters);
        }

    }
}
