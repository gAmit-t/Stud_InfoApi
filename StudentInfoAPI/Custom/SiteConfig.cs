using StudentInfo.BL.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentInfo.Custom
{
    public class SiteConfig
    {
        #region "Variable Declaration"
        public static string GooglePlusID = "";
        public static string PInterestID = "";
        public static string FaceBookID = "";
        public static string TwitterID = "";
        public static string YoutubeID = "";
        public static string TollFreeNo = "";
        public static string ContactNo = "";
        public static string FaxNo = "";
        public static string AdminEmailID = "parshuram@mindtechsolutions.com";
        //public static string AdminEmailID = "ruqaiyahasnain167@gmail.com";
        public static string SalesEmailID = "";
        public static string SupportEmailID = "";
        public static string FromEmailDisplayName = "";
        public static string UserName = "testpaymentgateway3@gmail.com";
        public static string Password = "test123456";
        public static string SSL = "1";
        public static string WebSiteTitle = "";
        public static string WebSiteDescription = "";
        public static string CatSubCatCode = "CSCCode"; //"value";
        public static string MobCatSubCatCode = "MobCSCCode"; //"value";
        public static string ProductInfoQueryString = "value";
        public static string StyleCodeQueryString = "value";
        public static string CollectionQueryString = "CollCode";
        public static string OrderIdQueryString = "oid";
        public static string TransactionIdQueryString = "tid";
        public static string DiaCatSubCatCode = "DCCode"; //"value";
        public static string MobDiaCatSubCatCode = "MobDCCode"; //"value";
        public static string CustomerIP = "";
        public static string SelectedCatCode = "";
        public static string SelectedCollCode = "";
        public static string QuotIdQueryString = "qid";
        public static string BlogQueryString = "blogid";
        public static string strValue = "";
        #endregion

        public static void SiteConfigValues()
        {

            DataTable dt = Common_BL.GetGeneralSettings();
            if (dt.Rows.Count == 0) return;
            if (dt.Rows[0]["SiteTitle"] != DBNull.Value) WebSiteTitle = dt.Rows[0]["SiteTitle"].ToString();
            if (dt.Rows[0]["SiteDescription"] != DBNull.Value) SiteConfig.WebSiteDescription = dt.Rows[0]["SiteDescription"].ToString();
            if (dt.Rows[0]["SalesEmail"] != DBNull.Value) SalesEmailID = dt.Rows[0]["SalesEmail"].ToString();
            if (dt.Rows[0]["TollFreeNumber"] != DBNull.Value) TollFreeNo = dt.Rows[0]["TollFreeNumber"].ToString();
            if (dt.Rows[0]["AdminEmail"] != DBNull.Value) AdminEmailID = dt.Rows[0]["AdminEmail"].ToString();
            if (dt.Rows[0]["SupportEmail"] != DBNull.Value) SupportEmailID = dt.Rows[0]["SupportEmail"].ToString();



            if (dt.Rows[0]["GoogleLink"] != DBNull.Value && dt.Rows[0]["GoogleLink"].ToString().Trim().Length > 0)
            {
                GooglePlusID = dt.Rows[0]["GoogleLink"].ToString();
            }
            else
            {
                GooglePlusID = "#";
            }

            if (dt.Rows[0]["PinterestLink"] != DBNull.Value && dt.Rows[0]["PinterestLink"].ToString().Trim().Length > 0)
            {
                PInterestID = dt.Rows[0]["PinterestLink"].ToString();
            }
            else
            {
                PInterestID = "#";
            }

            if (dt.Rows[0]["TwitterLink"] != DBNull.Value && dt.Rows[0]["TwitterLink"].ToString().Trim().Length > 0)
            {
                TwitterID = dt.Rows[0]["TwitterLink"].ToString();
            }
            else
            {
                TwitterID = "#";
            }

            if (dt.Rows[0]["FBLink"] != DBNull.Value && dt.Rows[0]["FBLink"].ToString().Trim().Length > 0)
            {
                FaceBookID = dt.Rows[0]["FBLink"].ToString();
            }
            else
            {
                FaceBookID = "#";
            }

            if (dt.Rows[0]["YouTubeLink"] != DBNull.Value && dt.Rows[0]["YouTubeLink"].ToString().Trim().Length > 0)
            {
                YoutubeID = dt.Rows[0]["YouTubeLink"].ToString();
            }
            else
            {
                YoutubeID = "#";
            }


        }
        public static string LoginKeyName
        {
            get
            {
                return ConfigurationManager.AppSettings["LoginKeyName"].ToString();
            }
        }

        public static string AuthServiceHeaderName
        {
            get
            {
                return ConfigurationManager.AppSettings["AuthServiceHeaderName"].ToString();
            }
        }

        internal static string GetConfigValue(string v)
        {
            throw new NotImplementedException();
        }

        public static string SMTPFromEmail
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPFromEmail"];
            }
        }
        public static string SMTPPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPPassword"];
            }
        }

        public static string SMTPFromEmailName
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPFromEmailName"];
            }
        }
        public static string WebsiteHostedPath
        {
            get
            {

                return ConfigurationManager.AppSettings["WebsiteHostedPath"].ToString();
            }
        }
        public static string GetExcelTemplate
        {
            get
            {
                return ConfigurationManager.AppSettings["ExcelTemplate"].ToString();
            }
        }

        public static string UploadExcelTemplate
        {
            get
            {
                return ConfigurationManager.AppSettings["ExcelUpload"].ToString();
            }
        }

        public static string ReportDownloadPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportDownloadPath"].ToString();
            }
        }
        public static string ProductionBasePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FTPTransferImagesTemp"].ToString();
                //return strValue;
            }
            set
            {
                strValue = value;
            }
        }

        public static string FrontEndAPIUrl
        {
            get
            {

                return ConfigurationManager.AppSettings["FrontEndAPIUrl"].ToString();
            }
        }

        public static string SMTPServer
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPHost"].ToString();
            }
        }

        public static string SMTPPORT
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTPPORT"].ToString();
            }
        }
    }
}