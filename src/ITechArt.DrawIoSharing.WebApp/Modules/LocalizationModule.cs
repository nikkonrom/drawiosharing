using System.Web;
using ITechArt.DrawIoSharing.WebApp.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    public class LocalizationModule : IHttpModule
    {
        private readonly ICultureManagement _cultureManagement;


        public LocalizationModule(ICultureManagement cultureManagement)
        {
            _cultureManagement = cultureManagement;
        }


        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var languageName = _cultureManagement.SetUpCulture(currentHttpContext);
                currentHttpContext.Items.Add(CultureManagement.KeyForLanguageNameAccess, languageName);
            };
        }

        public void Dispose()
        {

        }
    }
}