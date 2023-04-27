using System.Web.Http;
using WebActivatorEx;
using ServiceDotNet.Api;
using Swashbuckle.Application;
using System.Web;

[assembly: System.Web.PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ServiceDotNet.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Work Diary");
                    })
                .EnableSwaggerUi(c =>
                    {   
                        c.DocumentTitle("Work Diary API");
                    });
        }
    }
}
