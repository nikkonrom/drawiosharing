﻿using System.Web.Mvc;
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

            var registrations = new DrawIoSharingNinjectModule();
            var kernel = new StandardKernel(registrations);
            var dependencyResolver = new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(dependencyResolver);
        }
    }
}
