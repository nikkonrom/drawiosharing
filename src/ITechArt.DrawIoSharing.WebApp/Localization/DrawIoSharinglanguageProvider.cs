using System;
using System.Collections.Generic;
using ITechArt.Common;
using ITechArt.Localization.Languages;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class DrawIoSharingLanguageProvider : ILanguageProvider
    {
        private const string KeyForWebConfigSupportedLanguagesAccess = "SupportedLanguages";


        public IReadOnlyCollection<Language> GetLanguages()
        {
            var languages = new List<Language>();
            var webConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            var supportedLanguagesConfigurationElement = webConfig.AppSettings.Settings[KeyForWebConfigSupportedLanguagesAccess];
            if (supportedLanguagesConfigurationElement != null)
            {
                var supportedLanguages = supportedLanguagesConfigurationElement.Value.Split(',');
                foreach (var supportedLanguage in supportedLanguages)
                {
                    if (Enum.TryParse(supportedLanguage, out Language language))
                        languages.Add(language);
                }
            }

            return languages;
        }
    }
}