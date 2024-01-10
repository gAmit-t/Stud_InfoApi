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
    public class AuthenticateController : ApiController
    {
        Authenticate_BL authbl = new Authenticate_BL();

        [AllowAnonymous]
        [ActionName("GetOtp")]
        [HttpPost]
        public JObject GetOtp([FromBody] JObject data)
        {
            try
            {
                JObject RtnObject = new JObject();

                RtnObject = authbl.GetOtp(data);
                return RtnObject;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}