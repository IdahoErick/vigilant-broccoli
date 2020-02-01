using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIFramework
{
    public class AIQConnectionStrings
    {
        // Oracle
        public const string ORA_INFREP_DEV = "Data Source=dtools1;User ID=toolsadmin;Password=toolsadmin;Unicode=True";
        public const string ORA_INFREP_PROD = "Data Source=toolsservice1;User ID=toolsadmin;Password=toolsadmin;Unicode=True";
        public const string ORA_EDW_PROD = "Data Source=edwservice1;User ID=edwadmin;Password=edwadmin;Unicode=True";
        public const string ORA_ODS_PROD = "Data Source=odsservice1;User ID=odsadmin;Password=odsadmin;Unicode=True";
        public const string ORA_EDW_DEV = "Data Source=dedw;User ID=edwadmin;Password=edwadmin;Unicode=True";
        public const string ORA_ODS_DEV = "Data Source=dods;User ID=odsadmin;Password=odsadmin;Unicode=True";
        // SQL Server
        //public const string SQL_INFAREP86_DEV = "Data Source=spodevdb1;Initial Catalog=spoinfadev;Integrated Security=SSPI;";
        public const string SQL_INFAREP86_DEV = "Data Source=spodevdb1;User Id=InfaDomainUser;Password=Inf0rmat1ca!";
        public const string SQL_INFAREP86_PROD = "Data Source=spoproddb1;Initial Catalog=spoinfaprod;Integrated Security=SSPI;";
        //public const string SQL_INFAREP86_PROD = "Data Source=spoproddb1;Initial Catalog=spoinfaprod;User Id=InfaDomainUser;Password=Inf0rmat1ca!;";

    }
}
