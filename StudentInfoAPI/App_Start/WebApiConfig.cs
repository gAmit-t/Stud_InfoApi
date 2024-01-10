using StudentInfo.Providers;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentInfo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapHttpAttributeRoutes();
            config.Filters.Add(new ApiAuthenticationFilter(true));
            config.Filters.Add(new MyExceptionFilterAttribute());
        }
    }
}
