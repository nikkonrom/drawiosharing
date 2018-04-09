using System.Web;
using ITechArt.DrawIoSharing.WebApp.Utils;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Localization.Localize;
        }

        public void Dispose()
        {

        }
    }
}