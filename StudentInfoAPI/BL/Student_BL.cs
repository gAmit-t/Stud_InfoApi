using Newtonsoft.Json.Linq;
using StudentInfo.Custom;
using StudentInfo.DAL;
using StudentInfo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentInfo.BL
{
    public class Student_BL
    {

        public JObject Authentication(JObject data)
        {
            JObject RtnObject = new JObject();
            Dictionary<string, object> IncPara = new Dictionary<string, object>();
            DataTable dtData = _DataAccess.GetDataTable("otpGeneration", data, null, null, "Connection");
            RtnObject["Data"] = dtData.ToString();
            return RtnObject;
        }

        public JObject ResgiterStudent(JObject data)
        {
            JObject RtnObject = new JObject();
            Dictionary<string, object> IncPara = new Dictionary<string, object>();
            DataTable dtData = _DataAccess.GetDataTable("registerStudent", data, null, null, "Connection");
            RtnObject["Data"] = dtData.ToString();
            return RtnObject;
        }

    }
}