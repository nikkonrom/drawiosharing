using System.Collections.Generic;
using System.Web;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization.Http
{
    public static class HttpContextExtension
    {
        public static void AddCurrentLanguage(this HttpContext context, LanguageInfo languageInfoName)
        {
            context.Items.Add(HttpRequestLocalizationManager.KeyForLanguageNameAccess, languageInfoName);
        }

        public static LanguageInfo GetCurrentLanguage(this HttpContext context)
        {
            return (LanguageInfo)context.Items[HttpRequestLocalizationManager.KeyForLanguageNameAccess];
        }

        public static void AddSupportedLanguages(this HttpContext context, IReadOnlyCollection<LanguageInfo> languages)
        {
            context.Items.Add(HttpRequestLocalizationManager.KeyForSupportedLanguagesAccess, languages);
        }

        public static IReadOnlyCollection<LanguageInfo> GetSupportedLanguages(this HttpContext context)
        {
            return (IReadOnlyCollection<LanguageInfo>)context.Items[HttpRequestLocalizationManager.KeyForSupportedLanguagesAccess];
        }
    }
}