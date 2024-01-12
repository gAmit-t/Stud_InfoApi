using Newtonsoft.Json.Linq;
using StudentInfo.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentInfo.BL
{
    public class Authenticate_BL
    {
        public JObject GetOtp(JObject data)
        {
            JObject RtnObject = new JObject();
            Dictionary<string, object> IncPara = new Dictionary<string, object>();
            string MobileNo = data["MobileNo"].ToString();
            string fcmToken = data["fcmToken"].ToString();

            IncPara.Add("@MobileNo", MobileNo);
            IncPara.Add("@fcmToken", fcmToken);

            DataTable dtData = _DataAccess.GetDataTable("pGetOTP", null, IncPara, null);
            RtnObject["Data"] = dtData.ToString();
            return RtnObject;
        }
    }
}