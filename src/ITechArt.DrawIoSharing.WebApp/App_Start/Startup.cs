using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ITechArt.DrawIoSharing.WebApp.Startup))]
namespace ITechArt.DrawIoSharing.WebApp
{
    public class Startup
    {
        [UsedImplicitly]
        public void Configuration(IAppBuilder appBuilder)
        {
            //appBuilder.CreatePerOwinContext(() => new );

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}