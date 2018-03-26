using ITechArt.Common;
using Microsoft.Owin;
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