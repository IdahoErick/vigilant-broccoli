using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIMonitor
{
    public class NNConnectionStrings
    {
        // SQL Server
        public const string SQL_LOCALHOST = "Data Source=localhost;User Id=LocalAdmin;Password=<LocalAdminPassword>";
        public const string SQL_LOCALHOST_IS = "Data Source=localhost;Integrated Security = SSPI";
        // ILH
        public const string SQL_ILH_DEV_IS = "Data Source=SRDZZSQL0028, 48000;Integrated Security = SSPI";
        public const string SQL_ILH_TEST_IS = "Data Source=SRTZZSQL0053, 48000;Integrated Security = SSPI";
        public const string SQL_ILH_ACC_IS = "Data Source=SRAZZSQL0049, 48000;Integrated Security = SSPI";
        public const string SQL_ILH_PROD_IS = "Data Source=SRPZZSQL0050, 48000;Integrated Security = SSPI";
        // ILSB
        public const string SQL_ILSB_DEV_IS = "Data Source=SRDZZSQL0029, 48000;Integrated Security = SSPI";
        public const string SQL_ILSB_TEST_IS = "Data Source=SRTZZSQL0051, 48000;Integrated Security = SSPI";
        public const string SQL_ILSB_ACC_IS = "Data Source=SRAZZSQL0051, 48000;Integrated Security = SSPI";
        public const string SQL_ILSB_PROD_IS = "Data Source=SRPZZSQL0052, 48000;Integrated Security = SSPI";

        public const string SQL_INFAREP86_DEV = "Data Source=spodevdb1;User Id=InfaDomainUser;Password=Inf0rmat1ca!";
        public const string SQL_INFAREP86_PROD = "Data Source=spoproddb1;Initial Catalog=spoinfaprod;Integrated Security=SSPI;";
    }
}
