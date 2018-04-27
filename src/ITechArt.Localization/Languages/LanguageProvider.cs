using System;
using System.Collections.Generic;
using System.Linq;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class LanguageProvider : ILanguageProvider
    {
        public IReadOnlyCollection<Language> SupportedLanguages { get; }

        public Language DefaultLanguage { get; }


        public LanguageProvider()
        {
            DefaultLanguage = ParseLanguage(Settings.Default.DefaultLanguage);
            SupportedLanguages = Settings.Default.SupportedLanguages.Split(',').Select(ParseLanguage).ToList();
        }


        private static Language ParseLanguage(string languageString)
        {
            return (Language)Enum.Parse(typeof(Language), languageString);
        }
    }
}