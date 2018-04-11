using System.Web;
using ITechArt.Common;
using ITechArt.DrawIoSharing.WebApp;
using ITechArt.DrawIoSharing.WebApp.Modules;

[assembly: PreApplicationStartMethod(typeof(ModuleRegistrations), "RegisterModules")]
namespace ITechArt.DrawIoSharing.WebApp
{
    public class ModuleRegistrations
    {
        [UsedImplicitly]
        public static void RegisterModules()
        {
            HttpApplication.RegisterModule(typeof(LocalizationModule));
        }
    }
}