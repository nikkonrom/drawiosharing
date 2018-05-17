using System.Web;
using ITechArt.Common;
using ITechArt.Localization.Http;

namespace ITechArt.Localization.Modules
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        private readonly IHttpRequestLocalizationManagerFactory _httpRequestLocalizationManagerFactory;


        public LocalizationModule(IHttpRequestLocalizationManagerFactory httpLocalizationManagerFactory)
        {
            _httpRequestLocalizationManagerFactory = httpLocalizationManagerFactory;
        }


        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var httpRequestLocalizationManager = _httpRequestLocalizationManagerFactory.GetHttpRequestLocalizationManager();
                httpRequestLocalizationManager.SetUpRequestCulture(currentHttpContext);
            };
        }

        public void Dispose()
        {

        }
    }
}