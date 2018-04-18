using System.Web;
using ITechArt.Common;
using ITechArt.DrawIoSharing.WebApp.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Modules
{
    [UsedImplicitly]
    public class LocalizationModule : IHttpModule
    {
        private readonly ICultureSetup _cultureSetup;


        public LocalizationModule(ICultureSetup cultureSetup)
        {
            _cultureSetup = cultureSetup;
        }


        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
            {
                var currentHttpContext = context.Context;
                var languageName = _cultureSetup.SetUpCulture(currentHttpContext);
                currentHttpContext.Items.Add(CultureSetup.KeyForLanguageNameAccess, languageName);
            };
        }

        public void Dispose()
        {

        }
    }
}