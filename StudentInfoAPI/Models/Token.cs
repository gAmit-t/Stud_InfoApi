using StudentInfo.Custom;
using StudentInfo.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace StudentInfo.Models
{
    public class Token
    {
        #region "Variable,Properties,Constructor"
        string Separator = "$#%";
        string strErr = "";

        public string UserCode
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string IsSuperAdmin
        {
            get;
            set;
        }
        public string SessionCode
        {
            get;
            set;
        }

        public DateTime SessionExpiryDate
        {
            get;
            set;
        }

        public Token()
        {

        }

        public Token(string SerializeString)
        {
            SerializeString = StaticGeneral.DecryptedText(SerializeString);
            string[] str = SerializeString.Split(new string[] { Separator }, StringSplitOptions.None);

            UserCode = str[0];
            UserName = str[1];
            IsSuperAdmin = str[2];
            SessionCode = str[3];
        }
        #endregion

        #region "Helpers"
        public string GetTokenSerialized()
        {
            return StaticGeneral.EncryptedText(UserCode + Separator + UserName + Separator + IsSuperAdmin + Separator + SessionCode + Separator + SessionExpiryDate);
        }

        public string GetError()
        {
            return strErr;
        }
        #endregion

        public bool IsValid()
        {
            try
            {
                Dictionary<string, object> Para = new Dictionary<string, object>();
                //Para.Add("UserCode", UserCode);
                //Para.Add("SessionID", SessionCode);

                DataTable dt = _DataAccess.GetDataTable("adp_ValidToken", Para);
                if (dt.Rows.Count == 1 && Convert.ToBoolean(dt.Rows[0]["Status"]))
                {
                    return true;
                }
                else
                {
                    strErr = "Invalid Token...";
                    return false;
                }
            }
            catch (Exception)
            {
                strErr = "Invalid Token...";
                return false;
            }
        }
    }
}