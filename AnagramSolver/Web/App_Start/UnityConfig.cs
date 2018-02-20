using AnagramSolver.EFCF.Core.Context;
using AnagramSolver.Repositories;
using AnagramSolver.Service;
using DBReader;
using Implementation;
using Interfaces;
using Interfaces.Services;
using System;
using System.Data.Entity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Web.Controllers;
using Web.Services;

namespace Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            //var path = Constants.Path;
            //var minCount = Constants.MinCount;
            //var maxResult = Constants.MaxResult;
            //var connectionString = Constants.ConnectionString;
            container
                .RegisterType<IWordRepository, EFRepository>(
                    new ContainerControlledLifetimeManager(), new InjectionConstructor())
                .RegisterType<IAnagramSolver<string>, AnagramGenerator>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IHomeControllerService, HomeControllerService>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IUserLogsRepository, UserLogsRepositoryEF>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IUserLogService, UserLogService>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<ICachedWordsRepository, CachedWordsRepositoryEF>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<ICachedAnagramsRepository, CachedAnagramsRepositoryEF>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<ICachedAnagramsService, CachedAnagramsService>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IWordsRepository, WordsRepositoryEF>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IWordsService, WordsService>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<DbContext, AnagramsContext>(new ContainerControlledLifetimeManager());
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}