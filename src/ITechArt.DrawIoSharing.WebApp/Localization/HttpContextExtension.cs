using System.Collections.Generic;
using System.Web;
using ITechArt.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public static class HttpContextExtension
    {
        public static void AddCurrentLanguage(this HttpContext context, Language languageName)
        {
            context.Items.Add(HttpRequestLocalizationManager.KeyForLanguageNameAccess, languageName);
        }

        public static Language GetCurrentLanguage(this HttpContext context)
        {
            return (Language)context.Items[HttpRequestLocalizationManager.KeyForLanguageNameAccess];
        }

        public static void AddSupportedLanguages(this HttpContext context, IReadOnlyCollection<Language> languages)
        {
            context.Items.Add(HttpRequestLocalizationManager.KeyForSupportedLanguagesAccess, languages);
        }

        public static IReadOnlyCollection<Language> GetSupportedLanguages(this HttpContext context)
        {
            return (IReadOnlyCollection<Language>)context.Items[HttpRequestLocalizationManager.KeyForSupportedLanguagesAccess];
        }
    }
}