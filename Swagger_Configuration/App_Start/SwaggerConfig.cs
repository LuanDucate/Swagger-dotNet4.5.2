using Swashbuckle.Application;
using System.Web.Http;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Swagger_Configuration
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "New Swagger API");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
        protected static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\Swagger_Configuration.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}