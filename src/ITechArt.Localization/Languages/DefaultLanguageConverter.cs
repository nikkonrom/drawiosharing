using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class DefaultLanguageConverter : ILanguageConverter
    {
        private readonly ReadOnlyDictionary<Language, LanguageInfo> _languageMatches;


        public DefaultLanguageConverter()
        {
            _languageMatches =
                new ReadOnlyDictionary<Language, LanguageInfo>(new Dictionary<Language, LanguageInfo>
                {
                    { Language.English, new LanguageInfo("en", "English") },
                    { Language.Russian, new LanguageInfo("ru", "Русский (Russian)") }
                });
        }


        public IReadOnlyCollection<LanguageInfo> ConvertLanguagesToLanguagesInfo(IReadOnlyCollection<Language> languages)
        {
            return languages.Select(ConvertAliasToLanguage).ToList();
        }


        private LanguageInfo ConvertAliasToLanguage(Language language)
        {
            return _languageMatches[language];
        }
    }
}