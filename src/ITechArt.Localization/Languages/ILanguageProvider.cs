using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageProvider
    {
        IReadOnlyCollection<Language> GetLanguages();

        Language GetLanguage(string cultureName);

        bool CheckIfLanguageSupported(string cultureName);        
    }
}