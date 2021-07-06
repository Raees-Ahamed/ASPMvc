using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<SqlRestaurantData>().
                As<IRestaurantData>().
                InstancePerRequest();

            builder.RegisterType<SqlCustomerData>().As<ICustomerData>().InstancePerRequest();

            builder.RegisterType<OdeToFood.Data.Services.Data>().InstancePerRequest();
            Database.SetInitializer<OdeToFood.Data.Services.Data>(null);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}