using BusinessLayer.InventarLogic;
using BusinessLayer.UserLogic;
using Dal.Context;
using Dal.Repositories;
using Dal.Repositories.InventarRepository;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;

namespace LittleHelperApi
{
    /// <summary>
    /// Configuration file for dependency injection
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container = new UnityContainer();

            // TODO Per RequestLifeTimerManager einfügen, da sonst Context Probleme entstehen
            container.RegisterType<ILittleHelperContext, LittleHelperContext>();

            // Repositories
            container.RegisterType<IInventarRepository, InventarRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            // Services
            container.RegisterType<IInventarLogic, InventarLogic>();
            container.RegisterType<IUserLogic, UserLogic>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);     
                  
        }
    }
}