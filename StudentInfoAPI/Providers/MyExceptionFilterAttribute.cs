using StudentInfo.Custom;
using StudentInfo.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace StudentInfo.Providers
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                string requestBody = "";
                string SessionCode = "0";

                using (var stream = new MemoryStream())
                {
                    var context = (HttpContextBase)actionExecutedContext.Request.Properties["MS_HttpContext"];
                    context.Request.InputStream.Seek(0, SeekOrigin.Begin);
                    context.Request.InputStream.CopyTo(stream);
                    requestBody = Encoding.UTF8.GetString(stream.ToArray());
                }

                if (!(actionExecutedContext.ActionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() || actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()))
                {
                    Token t = actionExecutedContext.Request.Properties[SiteConfig.LoginKeyName] as Token;
                    SessionCode = t.SessionCode.ToString();
                }
                StringBuilder sbHeader = new StringBuilder();
                sbHeader.AppendLine(actionExecutedContext.Request.Headers.ToString());
                sbHeader.AppendLine(actionExecutedContext.Request.Content.Headers.ToString());

                //_StaticGeneral.LogException(SessionCode, actionExecutedContext.Exception.Message, actionExecutedContext.Request.RequestUri.ToString(), requestBody, sbHeader.ToString());
            }
            catch (Exception)
            {

            }

        }
    }
}