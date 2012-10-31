using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApplication1.Core.Interfaces;
using MvcApplication1.Data;
using Microsoft.Practices.Unity;

namespace MvcApplication1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PersonContext>());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            InitContainer();
            ControllerBuilder.Current.SetControllerFactory(typeof(UnityControllerFactory));
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (Container != null)
                Container.Dispose();
        }

        private static void InitContainer()
        {
            if (_container == null)
                _container = new UnityContainer();

            // Register the relevant types for the container here through classes or configuration
            _container.RegisterType<IPersonRepository, PersonRepository>();
        }

        private static IUnityContainer _container;

        // must be public
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get { return Container; }
        }
    }
}
