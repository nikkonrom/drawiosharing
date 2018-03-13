﻿using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.Repositories.Migrations;
using Ninject;
using Ninject.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrawIoSharingDbContext, Configuration>());

            var registrations = new DrawIoSharingNinjectModule();
            var kernel = new StandardKernel(registrations);
            var dependencyResolver = new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(dependencyResolver);
        }
    }
}
