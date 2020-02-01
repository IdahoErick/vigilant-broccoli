using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DIMonitor
{
    public abstract class BaseDBAccess
    {
        public struct CommandParams
        {
            public string ParamName;
            public string ParamValue;
            public CommandParams(string paramName, string paramValue)
            {
                ParamName = paramName;
                ParamValue = paramValue;
            }
        }
        public abstract DataSet GetQueryDataSet(string connectionString, string sql, bool ignoreExceptions);
        public abstract int ExecuteSQLCommand(string connectionString, string commandText);
        // Replace the command parameters and execute a command text.
        public abstract int ExecuteSQLCommandWithParams(string connectionString, string commandText, List<CommandParams> commandParams);
        public abstract int EnableRelatedForeignKeys(string connectionString, string ownerName, string tableName);
        public abstract int DisableRelatedForeignKeys(string connectionString, string ownerName, string tableName);

        public enum DBType
        {
            Oracle = 1,
            SQLServer = 2
        }
    }
}
