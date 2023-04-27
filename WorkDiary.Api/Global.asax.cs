using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;

namespace ServiceDotNet.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        public class SwaggerController : ApiController
        {
            [HttpGet]
            [Route("")]
            public IHttpActionResult RedirectToSwagger()
            {
                var url = WebConfigurationManager.AppSettings["SwaggerRootUrl"];
                return Redirect(url);
            }
        }
    }
}
