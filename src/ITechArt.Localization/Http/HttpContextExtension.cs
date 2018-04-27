using System.Collections.Generic;
using System.Web;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization.Http
{
    public static class HttpContextExtension
    {
        private const string KeyForLanguageNameAccess = "ActualLanguageName";
        private const string KeyForSupportedLanguagesAccess = "SupportedLanguages";

        public static void AddCurrentLanguage(this HttpContext context, LanguageInfo languageInfoName)
        {
            context.Items.Add(KeyForLanguageNameAccess, languageInfoName);
        }

        public static LanguageInfo GetCurrentLanguage(this HttpContext context)
        {
            return (LanguageInfo)context.Items[KeyForLanguageNameAccess];
        }

        public static void AddSupportedLanguages(this HttpContext context, IReadOnlyCollection<LanguageInfo> languages)
        {
            context.Items.Add(KeyForSupportedLanguagesAccess, languages);
        }

        public static IReadOnlyCollection<LanguageInfo> GetSupportedLanguages(this HttpContext context)
        {
            return (IReadOnlyCollection<LanguageInfo>)context.Items[KeyForSupportedLanguagesAccess];
        }
    }
}