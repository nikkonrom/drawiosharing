using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule registrations = new DrawIoSharingNinjectModule();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
