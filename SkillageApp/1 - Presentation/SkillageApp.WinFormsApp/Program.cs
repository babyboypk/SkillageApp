using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Autofac;
using AutoMapper;
using SkillageApp.App.AutoMapper;
using SkillageApp.App.Implementation;
using SkillageApp.App.Interfaces;
using SkillageApp.Data.EF;
using SkillageApp.Data.EF.Repositories;
using SkillageApp.Data.IRepositories;
using SkillageApp.Infrastructure.Interfaces;

namespace SkillageApp.WinFormsApp
{
    static class Program
    {
        //private static IContainer _container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoMapperConfig.RegisterMappings();
            IContainer container = ConfigAutofac();

            var mainFrm = container.Resolve<MainForm>();
            Application.Run(mainFrm);

            // Add handler to handle the exception raised by main threads
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Add handler to handle the exception raised by additional threads
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            // Stop the application and all the threads in suspended state.
             Environment.Exit(-1);
        }


        private static IContainer ConfigAutofac()
        {
            var builder = new ContainerBuilder();

            //Register All Form in Application
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AssignableTo<Form>().AsSelf();

            //Register EFUnitOfWork
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            //Register Repository
            builder.RegisterGeneric(typeof(EFRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();

            //Register Database
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();


            //Register Service
            builder.RegisterType<ExchangeService>().As<IExchangeService>().InstancePerLifetimeScope();
            builder.RegisterType<StockSymbolService>().As<IStockSymbolService>().InstancePerLifetimeScope();
            builder.RegisterType<DailyPricesService>().As<IDailyPricesService>().InstancePerLifetimeScope();

            //Register Repository
            builder.RegisterType<ExchangeRepository>().As<IExchangeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StockSymbolRepository>().As<IStockSymbolRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DailyPricesRepository>().As<IDailyPricesRepository>().InstancePerLifetimeScope();

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

            return builder.Build();
        }

        static void Application_ThreadException (object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // All exceptions thrown by the main thread are handled over this method
            WriteLog(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method
            WriteLog(e.ExceptionObject as Exception);
        }

        static void WriteLog(Exception ex)
        {
            var eventLog = new EventLog();
            if (!(EventLog.SourceExists("SkillageApp")))
            {
                EventLog.CreateEventSource("SkillageApp", "Log");
            }
            eventLog.Source = "SkillageApp";

            eventLog.WriteEntry(ex.Message, EventLogEntryType.Error);
        }
    }
}