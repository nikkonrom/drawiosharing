using System.Collections.Generic;
using System.Linq;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class LanguageManager : ILanguageManager
    {
        public IReadOnlyCollection<LanguageInfo> SupportedLanguages { get; }

        public LanguageInfo DefaultLanguage { get; }


        public LanguageManager(ILanguageProvider languageProvider, ILanguageConverter languageConverter)
        {
            var languages = languageProvider.SupportedLanguages;
            SupportedLanguages = languages.Select(languageConverter.ConvertLanguageToLanguageInfo).ToList();
            DefaultLanguage = languageConverter.ConvertLanguageToLanguageInfo(languageProvider.DefaultLanguage);
        }


        public bool CheckIfLanguageSupported(string cultureName)
        {
            return SupportedLanguages.Any(language => language.CultureName == cultureName);
        }
        
        public LanguageInfo GetLanguageByCultureName(string languageName)
        {
            return SupportedLanguages.Single(language => language.CultureName == languageName);
        }
    }
}