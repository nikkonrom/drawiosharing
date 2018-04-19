using System.Collections.Generic;
using System.Linq;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public static class LanguageRegistrationManager
    {
        public static readonly IReadOnlyCollection<DrawIoSharingSupportedLanguage> SupportedLanguages;


        static LanguageRegistrationManager()
        {
            SupportedLanguages = new List<DrawIoSharingSupportedLanguage>
            {
                new DrawIoSharingSupportedLanguage("en", "English"),
                new DrawIoSharingSupportedLanguage("ru", "Русский (Russian)")
            };
        }


        public static bool SupportsLanguage(string cultureName)
        {
            return SupportedLanguages.SingleOrDefault(language => language.CultureName == cultureName) != null;
        }

        public static DrawIoSharingSupportedLanguage GetLanguage(string cultureName)
        {
            return SupportedLanguages.Single(language => language.CultureName == cultureName);
        }
    }
}