using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public static class HttpContextExtension
    {
        public static void AddCurrentLanguage(this HttpContext context, DrawIoSharingSupportedLanguage languageName)
        {
            context.Items.Add(HttpRequestLocalizationManager.KeyForLanguageNameAccess, languageName);
        }

        public static DrawIoSharingSupportedLanguage GetCurrentLanguage(this HttpContext context)
        {
            return (DrawIoSharingSupportedLanguage)context.Items[HttpRequestLocalizationManager.KeyForLanguageNameAccess];
        }
    }
}