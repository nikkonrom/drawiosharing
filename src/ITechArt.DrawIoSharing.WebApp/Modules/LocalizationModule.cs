using System.Web;
using ITechArt.DrawIoSharing.WebApp.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var cultureManagement = new CultureManagement();
                var languageName = cultureManagement.SetUpCulture(currentHttpContext);
                currentHttpContext.Items.Add(CultureManagement.KeyForLanguageNameAccess, languageName);
            };
        }

        public void Dispose()
        {

        }
    }
}