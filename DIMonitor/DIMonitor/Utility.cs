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

        public static string GetConnectionString(ENV env, BU bu, PERIOD period, bool useLocalIS=true, String databaseName="")
        {
            //string BUPart = bu == (int)BU.ILVB ? "ILH" : "ILSB";
            //string periodPart = period == (int)PERIOD.DAG ? "DAG" : "MAAND";
            if (databaseName == "")
                databaseName = "SSISFramework";
            string databasePart = "; Database=" + databaseName;
            string cs = "";

            switch ((int)env)
            {
 
                case (int)ENV.LOCAL:
                    if (useLocalIS == false)
 //                       cs = NNConnectionStrings.SQL_LOCALHOST.Replace("<LocalAdminPassword>", Utility.DecryptString(Properties.Settings.Default.LocalAdminPassword)) + databasePart;
 //                   else
                        cs = NNConnectionStrings.SQL_LOCALHOST_IS + databasePart;
                    //cs = NNConnectionStrings.SQL_LOCALHOST.Replace("<LocalAdminPassword>", "MacyMarle2") + databasePart;
                    break;
                case (int)ENV.DEV:
                    cs = WSSConnectionStrings.SQL_EDW_DEV + databasePart;
                    break;
                case (int)ENV.TEST:
                    cs = WSSConnectionStrings.SQL_EDW_TEST + databasePart;
                    break;
                case (int)ENV.ACC:
                    cs = WSSConnectionStrings.SQL_EDW_ACC + databasePart;
                    break;
                case (int)ENV.PROD:
                    cs = WSSConnectionStrings.SQL_EDW_PROD + databasePart;
                    break;
                default:
                    cs = "";
                    break;
            }
            return cs;
        }

        public static string GetWSSOLTPConnectionString(ENV env, String databaseName = "")
        {
            if (databaseName == "")
                databaseName = "SSISFramework";
            string databasePart = "; Database=" + databaseName;
            string cs = "";

            switch ((int)env)
            {
                case (int)ENV.LOCAL:
                    cs = NNConnectionStrings.SQL_LOCALHOST_IS + databasePart;
                    break;
                case (int)ENV.DEV:
                    if ((databaseName == "IDS") || (databaseName == "EDI"))
                        cs = WSSConnectionStrings.SQL_IDSDWH_TEST + databasePart;
                    else if (databaseName == "ContentCatalog")
                        cs = WSSConnectionStrings.SQL_CC_WT + databasePart;
                    else if (databaseName == "EmployeeReporting")
                        cs = WSSConnectionStrings.SQL_EDW_DEV + databasePart;
                    else
                        cs = WSSConnectionStrings.SQL_WSS_WT + databasePart;
                    break;
                case (int)ENV.TEST:
                    if ((databaseName == "IDS") || (databaseName == "EDI"))
                        cs = WSSConnectionStrings.SQL_IDSDWH_TEST + databasePart;
                    else if (databaseName == "ContentCatalog")
                        cs = WSSConnectionStrings.SQL_CC_WT + databasePart;
                    else if (databaseName == "EmployeeReporting")
                        cs = WSSConnectionStrings.SQL_EDW_TEST + databasePart;
                    else
                        cs = WSSConnectionStrings.SQL_WSS_WT + databasePart;
                    break;
                case (int)ENV.ACC:
                    if ((databaseName == "IDS") || (databaseName == "EDI"))
                        cs = WSSConnectionStrings.SQL_IDSDWH_PROD + databasePart;
                    else if (databaseName == "ContentCatalog")
                        cs = WSSConnectionStrings.SQL_CC_WP + databasePart;
                    else if (databaseName == "EmployeeReporting")
                        cs = WSSConnectionStrings.SQL_EDW_ACC + databasePart;
                    else
                        cs = WSSConnectionStrings.SQL_WSS_WP + databasePart;
                    break;
                case (int)ENV.PROD:
                    if ((databaseName == "IDS") || (databaseName == "EDI"))
                        cs = WSSConnectionStrings.SQL_IDSDWH_PROD + databasePart;
                    else if (databaseName == "ContentCatalog")
                        cs = WSSConnectionStrings.SQL_CC_WP + databasePart;
                    else if (databaseName == "EmployeeReporting")
                        cs = WSSConnectionStrings.SQL_EDW_PROD + databasePart;
                    else
                        cs = WSSConnectionStrings.SQL_WSS_WP + databasePart;
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
            catch (FormatException)
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
        public static DateTime ParseDateStringToDate(string dateString)
        {
            try
            {
                return Convert.ToDateTime(dateString);
            }
            catch
            {
                return Convert.ToDateTime("1900-01-01");
            }
        }

        public static string ParseDateStringToLabel(string dateString)
        {
            try
            {
                return Convert.ToDateTime(dateString).ToString("dd-MM-yyyy");
            }
            catch
            {
                return "Unknown";
            }
        }
    }
}
