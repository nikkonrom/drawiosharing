using ITechArt.Common;
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

        }
    }
}