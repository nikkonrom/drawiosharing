using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ITechArt.Common;
using ITechArt.Localization;
using ITechArt.Localization.Languages;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class DrawIoSharingLanguageConverter : ILanguageConverter
    {
        private readonly ReadOnlyDictionary<LanguageAlias, Language> _languageMatches;


        public DrawIoSharingLanguageConverter()
        {
            _languageMatches =
                new ReadOnlyDictionary<LanguageAlias, Language>(new Dictionary<LanguageAlias, Language>
                {
                    { LanguageAlias.English, new Language("en", "English") },
                    { LanguageAlias.Russian, new Language("ru", "Русский (Russian)") }
                });
        }


        public Language ConvertAliasToLanguage(LanguageAlias language)
        {
            return _languageMatches[language];
        }

        public IReadOnlyCollection<Language> ConvertAliasesToLanguages(IReadOnlyCollection<LanguageAlias> languages)
        {
            return languages.Select(ConvertAliasToLanguage).ToList();
        }
    }
}