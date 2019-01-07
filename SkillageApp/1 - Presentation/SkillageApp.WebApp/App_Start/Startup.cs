using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Microsoft.Owin;
using Owin;
using SkillageApp.App.AutoMapper;
using SkillageApp.App.Implementation;
using SkillageApp.App.Interfaces;
using SkillageApp.Data.EF;
using SkillageApp.Data.EF.Repositories;
using SkillageApp.Data.IRepositories;
using SkillageApp.Infrastructure.Interfaces;

[assembly: OwinStartup(typeof(SkillageApp.WebApp.App_Start.Startup))]

namespace SkillageApp.WebApp.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //register dependency injection
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            //Register Controller MVC
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //Registe Entity Framwork Unit Of Work
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Registe Register Generic Repository
            builder.RegisterGeneric(typeof(EFRepository<,>)).As(typeof(IRepository<,>)).InstancePerRequest();

            //Register Database
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerRequest();


            //Register Service Mapping Interface
            builder.RegisterType<ExchangeService>().As<IExchangeService>().InstancePerRequest();
            builder.RegisterType<StockSymbolService>().As<IStockSymbolService>().InstancePerRequest();
            builder.RegisterType<DailyPricesService>().As<IDailyPricesService>().InstancePerRequest();
            builder.RegisterType<VWDailyPricesService>().As<IVWDailyPricesService>().InstancePerRequest();

            //Register Repository Maping Interfacae
            builder.RegisterType<ExchangeRepository>().As<IExchangeRepository>().InstancePerRequest();
            builder.RegisterType<StockSymbolRepository>().As<IStockSymbolRepository>().InstancePerRequest();
            builder.RegisterType<DailyPricesRepository>().As<IDailyPricesRepository>().InstancePerRequest();
            builder.RegisterType<VWDailyPricesRepository>().As<IVWDailyPricesRepository>().InstancePerRequest();

            //Register Automaper
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
        }
    }
}
