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
            string mobileNo = data["MobileNo"].ToString();

            IncPara.Add("@MobileNo", mobileNo);

            DataTable dtData = _DataAccess.GetDataTable("pGetOTP", null, IncPara, null);
            RtnObject["Data"] = dtData.ToString();
            return RtnObject;
        }
    }
}