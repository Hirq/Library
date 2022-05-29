using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Library.Data.Services;
using Library.Data.Services.Interfaces;
using System.Web.Http;
using System.Web.Mvc;

namespace Library.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlBookData>()
                .As<IBookData>()
                .InstancePerRequest();
            builder.RegisterType<SqlRentalData>()
            .As<IRentalData>()
            .InstancePerRequest();
            builder.RegisterType<SqlRestaurantData>()
            .As<IRestaurantData>()
            .InstancePerRequest();
            builder.RegisterType<SqlOpinionData>()
            .As<IOpinionData>()
            .InstancePerRequest();
            builder.RegisterType<LibraryDbContext>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}