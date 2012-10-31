using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Microsoft.Practices.Unity;

namespace MvcApplication1
{
    public class UnityControllerFactory : IControllerFactory
    {
        public IController CreateController
            (RequestContext requestContext, string controllerName)
        {
            var containerAccessor = requestContext.HttpContext.ApplicationInstance as IContainerAccessor;

            var currentAssembly = Assembly.GetExecutingAssembly();
            var controllerTypes = (from t in currentAssembly.GetTypes()
                                   where t.Name.Contains(controllerName + "Controller")
                                   select t).ToList();

            IController controller = null;
            if (containerAccessor != null)
                if (controllerTypes.Any())
                    controller = containerAccessor.Container.Resolve(controllerTypes.First()) as IController;

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            controller = null;
        }
    }
}