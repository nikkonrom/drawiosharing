using System.Collections.Generic;
using System.Linq;
using ITechArt.Common;
using ITechArt.Localization;
using ITechArt.Localization.Languages;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class DrawIoSharingLanguageProvider : ILanguageProvider
    {
        private readonly IReadOnlyCollection<Language> _supportedLanguages;


        public DrawIoSharingLanguageProvider(ILanguageConverter languageConverter)
        {
            var languageAliases = new List<LanguageAlias>
            {
                LanguageAlias.English,
                LanguageAlias.Russian
            };
            _supportedLanguages = languageConverter.ConvertAliasesToLanguages(languageAliases);
        }


        public bool CheckIfLanguageSupported(string cultureName)
        {
            return _supportedLanguages.Any(language => language.CultureName == cultureName);
        }

        public IReadOnlyCollection<Language> GetLanguages()
        {
            return _supportedLanguages;
        }

        public Language GetLanguage(string languageName)
        {
            return _supportedLanguages.Single(language => language.CultureName == languageName);
        }
    }
}