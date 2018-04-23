using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageConverter
    {
        IReadOnlyCollection<LanguageInfo> ConvertLanguagesToLanguagesInfo(IReadOnlyCollection<Language> languages);
    }
}