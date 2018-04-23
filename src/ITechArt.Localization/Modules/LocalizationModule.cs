using System.Web;
using ITechArt.Common;
using ITechArt.Localization.Http;

namespace ITechArt.Localization.Modules
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        private readonly IPerRequestHttpLocalizationManager _perRequestHttpLocalizationManager;


        public LocalizationModule(IPerRequestHttpLocalizationManager perRequestHttpLocalizationManager)
        {
            _perRequestHttpLocalizationManager = perRequestHttpLocalizationManager;
        }


        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var httpRequestLocalizationManager = _perRequestHttpLocalizationManager.GetPerRequestHttpLocalizationManager();
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