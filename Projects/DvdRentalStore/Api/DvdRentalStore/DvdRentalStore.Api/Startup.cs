using System.Web.Http;
using Owin;

namespace DvdRentalStore.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration();
            RegisterContainer.Execute(configuration);
            SwaggerConfig.Execute(configuration);
            RegisterRoutes.Execute(configuration);
            RegisterConventions.Execute(configuration);
            appBuilder.UseWebApi(configuration);
        }
    }
}