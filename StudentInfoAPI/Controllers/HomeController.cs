using Newtonsoft.Json.Linq;
using StudentInfo.Custom;
using StudentInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace StudentInfo.Controllers
{
    public class HomeController : ApiController
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Title = "Home Page";

        //    return View();
        //}

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.ActionName("getData")]
        [System.Web.Http.HttpGet]
        public JObject GetData([FromBody] JObject data)
        {
            try
            {
                JObject RtnObject = new JObject();
                RtnObject["number"] = 9898919198;
                return RtnObject;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
