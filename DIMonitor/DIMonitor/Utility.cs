using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMonitor
{
    public class Utility
    {
        public enum ENV
        {
            LOCAL = 0,
            DEV = 1,
            TEST = 2,
            ACC = 3,
            PROD = 4
        };

        public enum PERIOD
        {
            DAG = 0,
            MAAND = 1
        };

        public enum BU
        {
            ILVB = 0,
            ILVV = 1
        };

        public static string GetConnectionString(ENV env, BU bu, PERIOD period, bool useLocalIS=true)
        {
            string BUPart = bu == (int)BU.ILVB ? "ILH" : "ILSB";
            string periodPart = period == (int)PERIOD.DAG ? "DAG" : "MAAND";
            string databasePart = "; Database=" + BUPart + "_LOGGING_" + periodPart;
            string cs = "";

            switch ((int)env)
            {
                case (int)ENV.LOCAL:
                    if (useLocalIS == false)
                        cs = NNConnectionStrings.SQL_LOCALHOST.Replace("<LocalAdminPassword>", Utility.DecryptString(Properties.Settings.Default.LocalAdminPassword)) + databasePart;
                    else
                        cs = NNConnectionStrings.SQL_LOCALHOST_IS + databasePart;
                        
                    //cs = NNConnectionStrings.SQL_LOCALHOST.Replace("<LocalAdminPassword>", "MacyMarle2") + databasePart;
                    break;
                case (int)ENV.DEV:
                    cs = (BUPart == "ILH" ? NNConnectionStrings.SQL_ILH_DEV_IS : NNConnectionStrings.SQL_ILSB_DEV_IS) + databasePart;
                    break;
                case (int)ENV.TEST:
                    cs = (BUPart == "ILH" ? NNConnectionStrings.SQL_ILH_TEST_IS : NNConnectionStrings.SQL_ILSB_TEST_IS) + databasePart;
                    break;
                case (int)ENV.ACC:
                    cs = (BUPart == "ILH" ? NNConnectionStrings.SQL_ILH_ACC_IS : NNConnectionStrings.SQL_ILSB_ACC_IS) + databasePart;
                    break;
                case (int)ENV.PROD:
                    cs = (BUPart == "ILH" ? NNConnectionStrings.SQL_ILH_PROD_IS : NNConnectionStrings.SQL_ILSB_PROD_IS) + databasePart;
                    break;
                default:
                    cs = "";
                    break;
            }
            return cs;
        }
        public static string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public static string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }  
    }
}
