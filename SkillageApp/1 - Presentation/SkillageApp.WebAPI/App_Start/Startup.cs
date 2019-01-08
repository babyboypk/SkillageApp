using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Owin;
using Owin;
using SkillageApp.App.Implementation;
using SkillageApp.App.Interfaces;
using SkillageApp.Data.EF;
using SkillageApp.Data.EF.Repositories;
using SkillageApp.Data.IRepositories;
using SkillageApp.Infrastructure.Interfaces;

[assembly: OwinStartup(typeof(SkillageApp.WebAPI.App_Start.Startup))]

namespace SkillageApp.WebAPI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            //Register MVC Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            //Register Entity Framwork Unit Of Work
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Register Register Generic Repository
            builder.RegisterGeneric(typeof(EFRepository<,>)).As(typeof(IRepository<,>)).InstancePerRequest();

            //Register Database
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerRequest();

            //Register Service Mapping Interface
            builder.RegisterType<ExchangeService>().As<IExchangeService>().InstancePerRequest();
            builder.RegisterType<StockSymbolService>().As<IStockSymbolService>().InstancePerRequest();
            builder.RegisterType<DailyPricesService>().As<IDailyPricesService>().InstancePerRequest();
            builder.RegisterType<VWDailyPricesService>().As<IVWDailyPricesService>().InstancePerRequest();

            //Register Repository Mapping Interface
            builder.RegisterType<ExchangeRepository>().As<IExchangeRepository>().InstancePerRequest();
            builder.RegisterType<StockSymbolRepository>().As<IStockSymbolRepository>().InstancePerRequest();
            builder.RegisterType<DailyPricesRepository>().As<IDailyPricesRepository>().InstancePerRequest();
            builder.RegisterType<VWDailyPricesRepository>().As<IVWDailyPricesRepository>().InstancePerRequest();

            //Register Automapper
            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();

                var config = new MapperConfiguration(x =>
                {
                    // Load in all our AutoMapper profiles that have been registered
                    foreach (var profile in profiles)
                    {
                        x.AddProfile(profile);
                    }
                });

                return config;
            }).SingleInstance() // We only need one instance
                .AutoActivate() // Create it on ContainerBuilder.Build()
                .AsSelf(); // Bind it to its own type

            // HACK: IComponentContext needs to be resolved again as 'tempContext' is only temporary. See http://stackoverflow.com/a/5386634/718053 
            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                // Create our mapper using our configuration above
                return config.CreateMapper();
            }).As<IMapper>(); // Bind it to the IMapper interface

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Set the WebApi DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}
