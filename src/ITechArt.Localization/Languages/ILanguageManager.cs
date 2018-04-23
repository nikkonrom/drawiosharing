using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageManager
    {
        IReadOnlyCollection<LanguageInfo> GetLanguages();

        LanguageInfo GetLanguage(string cultureName);

        bool CheckIfLanguageSupported(string cultureName);
    }
}