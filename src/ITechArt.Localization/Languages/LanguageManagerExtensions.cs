using System.Linq;

namespace ITechArt.Localization.Languages
{
    public static class LanguageManagerExtensions
    {
        public static bool CheckIfLanguageSupported(this ILanguageManager languageManager , string cultureName)
        {
            return languageManager.SupportedLanguages.Any(language => language.CultureName == cultureName);
        }

        public static LanguageInfo GetLanguageByCultureName(this ILanguageManager languageManager, string languageName)
        {
            return languageManager.SupportedLanguages.Single(language => language.CultureName == languageName);
        }
    }
}
