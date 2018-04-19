using System.Web;
using ITechArt.Common;
using ITechArt.DrawIoSharing.WebApp.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        private readonly IHttpRequestLocalizationManager _httpRequestLocalizationManager;


        public LocalizationModule(IHttpRequestLocalizationManager httpRequestLocalizationManager)
        {
            _httpRequestLocalizationManager = httpRequestLocalizationManager;
        }


        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var currentLanguage = _httpRequestLocalizationManager.SetUpRequestCulture(currentHttpContext);
                currentHttpContext.AddCurrentLanguage(currentLanguage);
            };
        }

        public void Dispose()
        {

        }
    }
}