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
    }
}