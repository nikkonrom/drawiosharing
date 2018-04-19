using System.Collections.Generic;
using System.Linq;
using ITechArt.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public static class LanguageRegistrationManager
    {
        public static readonly IReadOnlyCollection<Language> SupportedLanguages;


        static LanguageRegistrationManager()
        {
            SupportedLanguages = new List<Language>
            {
                new Language("en", "English"),
                new Language("ru", "Русский (Russian)")
            };
        }


        public static bool SupportsLanguage(string cultureName)
        {
            return SupportedLanguages.SingleOrDefault(language => language.CultureName == cultureName) != null;
        }

        public static Language GetLanguage(string cultureName)
        {
            return SupportedLanguages.Single(language => language.CultureName == cultureName);
        }
    }
}