using System;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class Startup
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext((IdentityFactoryOptions<UserStore> factoryOptions, IOwinContext context) =>
                new UserService(new UserStore(new EfUnitOfWork(context.Get<DrawIoSharingDbContext>()))));
            appBuilder.CreatePerOwinContext<UserService>(UserService.Create);

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")});
        }
    }
}