using System;
using System.Collections.Generic;
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
            Enum.TryParse(Settings.Default.DefaultLanguage, out Language defaultLanguage);
            DefaultLanguage = defaultLanguage;
            var supportedLanguages = new List<Language>();
            foreach (var supportedLanguageString in Settings.Default.SupportedLanguages)
            {
                if (Enum.TryParse(supportedLanguageString, out Language supportedLanguage))
                     supportedLanguages.Add(supportedLanguage);
            }
            SupportedLanguages = supportedLanguages;
        }
    }
}