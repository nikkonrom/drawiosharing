using System.Collections.Generic;
using System.Linq;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class LanguageManager : ILanguageManager
    {
        private readonly IReadOnlyCollection<LanguageInfo> _supportedLanguages;


        public LanguageManager(ILanguageProvider languageProvider, ILanguageConverter languageConverter)
        {
            var languages = languageProvider.GetLanguages();
            _supportedLanguages = languageConverter.ConvertLanguagesToLanguagesInfo(languages);
        }


        public bool CheckIfLanguageSupported(string cultureName)
        {
            return _supportedLanguages.Any(language => language.CultureName == cultureName);
        }

        public IReadOnlyCollection<LanguageInfo> GetLanguages()
        {
            return _supportedLanguages;
        }

        public LanguageInfo GetLanguage(string languageName)
        {
            return _supportedLanguages.Single(language => language.CultureName == languageName);
        }
    }
}