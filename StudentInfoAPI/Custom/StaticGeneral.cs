using Newtonsoft.Json.Linq;
using StudentInfo.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Net;

namespace StudentInfo.Custom
{
    public enum QueryResultTypes
    {
        Data = 2,
        Count = 1
    }
    public class StaticGeneral
    {
        static object LockOut = 1;
        //static IConverter converter;

        static StaticGeneral()
        {
            //converter = new ThreadSafeConverter(new RemotingToolset<PdfToolset>(new WinAnyCPUEmbeddedDeployment(new TempFolderDeployment())));
        }

        public static string GetDBConnectionString()
        {
            return GetDBConnectionString("Connection");
        }

        public static string GetDBConnectionString(string strWhichConn)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[strWhichConn].ConnectionString.Trim();
            }
            catch
            {
                throw new Exception("Could not find [" + strWhichConn + "] in <connectionStrings> section of your web.config file." + Environment.NewLine + "Please check your web.config file.");
            }
        }

        public static string GetDBConnectionString(string strWhichConn, string strDBName)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[strWhichConn].ConnectionString.Trim();
                return new DbConnectionStringBuilder
                {
                    ConnectionString = connectionString,
                    ["Initial Catalog"] = strDBName.ToString()
                }.ConnectionString.ToString();
            }
            catch
            {
                throw new Exception("Could not find [" + strWhichConn + "] in <connectionStrings> section of your web.config file." + Environment.NewLine + "Please check your web.config file.");
            }
        }

        public static void UploadFileToFTP(string source, string strFolderName)
        {
            try
            {
                string filename = Path.GetFileName(source);
                string strFTPHost = SiteConfig.GetConfigValue("FTPHost");
                string strFTPUserName = SiteConfig.GetConfigValue("FTPUserName");
                string strFTPPassword = SiteConfig.GetConfigValue("FTPPassword");
                string ftpfullpath = strFTPHost + strFolderName + "/" + filename;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(strFTPUserName.Normalize(), strFTPPassword.Normalize(), "malanij.com".Normalize());

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Proxy = new WebProxy();
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UploadFileToWebStyleFTP(string source, string strFolderName)
        {
            try
            {
                string filename = Path.GetFileName(source);
                string strFTPHost = SiteConfig.GetConfigValue("FTPWebStyleHost");
                string strFTPUserName = SiteConfig.GetConfigValue("FTPWebStyleUserName");
                string strFTPPassword = SiteConfig.GetConfigValue("FTPWebStylePassword");
                string ftpfullpath = strFTPHost + strFolderName + "/" + filename;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(strFTPUserName.Normalize(), strFTPPassword.Normalize(), "malanijewelers.com".Normalize());

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Proxy = new WebProxy();
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                FileStream fs = File.OpenRead(source);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                Stream ftpstream = ftp.GetRequestStream();
                ftpstream.Write(buffer, 0, buffer.Length);
                ftpstream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string CheckNull(JToken obj, string ValueIfNull = "null")
        {
            if (obj == null || obj.ToString() == "" || obj.ToString() == "{}")
            {
                return ValueIfNull;
            }
            object o = obj.ToObject<object>();
            DateTime dt = new DateTime();
            string strFinalStr = "";
            if (DateTime.TryParse(o.ToString(), out dt))
            {
                //return "'" + ((DateTime)o).ToString("MM/dd/yyyy hh:mm:ss.fff") + "'";
                return "'" + Convert.ToDateTime(o.ToString()).ToString("MM/dd/yyyy hh:mm:ss.fff") + "'";
            }
            //if (o is DateTime)
            //{
            //    return "'" + ((DateTime)o).ToString("MM/dd/yyyy hh:mm:ss.fff") + "'";
            //}
            if (o is bool)
            {
                return (bool)o ? "1" : "0";
            }

            if (Convert.ToString(o).Contains("'"))
            {
                strFinalStr = Convert.ToString(o).Replace("'", "''");
            }
            else
            {
                strFinalStr = Convert.ToString(o);
            }

            return "'" + Convert.ToString(strFinalStr) + "'";

        }
        
        public static string EncryptedText(string strToEncrypt)
        {
            Encrypto enc = new Encrypto();
            return enc.Encrypt(strToEncrypt, true);
        }

        public static string DecryptedText(string strToDecrypt)
        {
            Encrypto enc = new Encrypto();
            return enc.Decrypt(strToDecrypt, true);
        }
        public static void LogRequests(string DeviceCode, string RequestBody, string RequestHeaders, string Method, string RequestURI)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@DeviceCode", DeviceCode.ToString());
            dictionary.Add("@RequestBody", RequestBody.ToString());
            dictionary.Add("@RequestHeaders", RequestHeaders.ToString());
            dictionary.Add("@Method", Method.ToString());
            dictionary.Add("@RequestURI", RequestURI.ToString());
            _DataAccess.GetDataTable("pRequestLog", dictionary);
        }

        public static void LogException(string SessionCode, string exMessage, string SectionName, string RequestBody, string RequestHeaders)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@DeviceCode", SessionCode.ToString());
            dictionary.Add("@SectionName", SectionName.ToString());
            dictionary.Add("@ErrorMsg", exMessage.ToString());
            dictionary.Add("@RequestBody", RequestBody.ToString());
            dictionary.Add("@RequestHeaders", RequestHeaders.ToString());
            _DataAccess.GetDataTable("pExceptionLog", dictionary);
        }
    }
}