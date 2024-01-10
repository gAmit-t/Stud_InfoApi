using Newtonsoft.Json.Linq;
using StudentInfo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentInfo.Controllers
{
    public class StudentController : ApiController
    {

        Student_BL bl = new Student_BL();

        //otp generation api // working as expected tested in postman

        [AllowAnonymous]
        [ActionName("Authentication")]
        [HttpPost]
        public JObject Authentication([FromBody] JObject data)
        {
            try
            {
                JObject RtnObject = new JObject();

                RtnObject = bl.Authentication(data);
                return RtnObject;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [AllowAnonymous]
        [ActionName("ResgiterStudent")]
        [HttpPost]
        public JObject ResgiterStudent([FromBody] JObject data)
        {
            try
            {
                JObject RtnObject = new JObject();

                RtnObject = bl.ResgiterStudent(data);
                return RtnObject;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
