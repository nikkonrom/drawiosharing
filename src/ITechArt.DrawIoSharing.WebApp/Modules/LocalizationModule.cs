using System.Web;
using ITechArt.Common;
using ITechArt.DrawIoSharing.WebApp.Localization;
using ITechArt.Localization.Http;
using Ninject;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                IKernel kernel = new StandardKernel(new DrawIoSharingNinjectModule());
                var httpRequestLocalizationManager = kernel.Get<IHttpRequestLocalizationManager>();
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