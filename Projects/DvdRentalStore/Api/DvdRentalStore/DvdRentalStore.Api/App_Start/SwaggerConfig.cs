using System.Web.Http;
using Swashbuckle.Application;

namespace DvdRentalStore.Api
{
    public class SwaggerConfig
    {
        public static void Execute(HttpConfiguration configuration)
        {
            configuration.EnableSwagger(Configure).EnableSwaggerUi(ConfigureUi);
        }

        private static void Configure(SwaggerDocsConfig config)
        {
            config.SingleApiVersion("V1", "Komplett.MobileSignUp.Api");
        }

        private static void ConfigureUi(SwaggerUiConfig config)
        {
            config.DocExpansion(DocExpansion.List);
            config.DisableValidator();
        }
    }
}