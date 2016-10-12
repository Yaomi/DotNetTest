using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using DvdRentalStore.Api.Components.Rental.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace DvdRentalStore.Api
{
    public class RegisterContainer
    {
        public static void Execute(HttpConfiguration configuration)
        {
            var container = new Container();

            container.RegisterWebApiControllers(configuration);

            container.RegisterSingleton<IRentalService, RentalService>();

            container.Verify();

            configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}