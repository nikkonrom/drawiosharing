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
            DefaultLanguage = (Language) Enum.Parse(typeof(Language), Settings.Default.DefaultLanguage); ;
            var supportedLanguages = new List<Language>();
            foreach (var supportedLanguageString in Settings.Default.SupportedLanguages.Split(','))
            {
                supportedLanguages.Add((Language) Enum.Parse(typeof(Language), supportedLanguageString));
            }
            SupportedLanguages = supportedLanguages;
        }
    }
}