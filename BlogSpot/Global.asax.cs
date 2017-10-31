using BlogSpot.Utils;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogSpot
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IDependencyInjector injector = new DependencyInjector();
            var container = injector.GetDependencyContainer;

            IDependencyResolver resolver = DependencyResolver.Current;
            DependencyResolver.SetResolver(new UnityDependencyResolver(container, resolver));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
