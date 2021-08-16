using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;
using refactor_this;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace refactor_this
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c => c.SingleApiVersion("v1", "Product API"))
              .EnableSwaggerUi();
        }
    }
}
