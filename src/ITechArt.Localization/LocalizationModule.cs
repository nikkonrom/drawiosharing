using System.Web;
using ITechArt.Common;

namespace ITechArt.Localization
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var currentLanguage = httpRequestLocalizationManager.SetUpRequestCulture(currentHttpContext);
                currentHttpContext.AddCurrentLanguage(currentLanguage);
                currentHttpContext.AddSupportedLanguages(httpRequestLocalizationManager.GetSupportedLanguages());
            };
        }

        public void Dispose()
        {

        }
    }
}