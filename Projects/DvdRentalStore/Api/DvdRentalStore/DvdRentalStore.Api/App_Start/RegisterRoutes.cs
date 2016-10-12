using System.Web.Http;

namespace DvdRentalStore.Api
{
    public class RegisterRoutes
    {
        public static void Execute(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
            configuration.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}