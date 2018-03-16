using ITechArt.Common;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.DrawIoSharing.Foundation.UserService;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ITechArt.DrawIoSharing.WebApp
{
    [UsedImplicitly]
    // ReSharper disable once IdentifierTypo
    public class OwinConfig
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.CreatePerOwinContext(DrawIoSharingDbContext.Create);
            appBuilder.CreatePerOwinContext<UserService>(UserService.Create);

            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")});
        }
    }
}