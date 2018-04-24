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
            Enum.TryParse(Settings.Default.DefaultLanguage, out Language language);
            DefaultLanguage = language;
            SupportedLanguages = Settings.Default.SupportedLanguages.Cast<Language>().ToList();
        }
    }
}