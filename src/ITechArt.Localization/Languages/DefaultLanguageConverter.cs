using System.Collections.Generic;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class DefaultLanguageConverter : ILanguageConverter
    {
        private readonly IReadOnlyDictionary<Language, LanguageInfo> _languageMatches;


        public DefaultLanguageConverter()
        {
            _languageMatches = new Dictionary<Language, LanguageInfo>
                {
                    { Language.English, new LanguageInfo("en", "English") },
                    { Language.Russian, new LanguageInfo("ru", "Русский (Russian)") }
                };
        }


        public LanguageInfo ConvertLanguageToLanguageInfo(Language language)
        {
            return _languageMatches[language];
        }
    }
}