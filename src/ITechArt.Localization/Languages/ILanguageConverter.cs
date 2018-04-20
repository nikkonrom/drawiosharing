using System.Collections.Generic;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization
{
    public interface ILanguageConverter
    {
        Language ConvertAliasToLanguage(LanguageAlias language);
        IReadOnlyCollection<Language> ConvertAliasesToLanguages(IReadOnlyCollection<LanguageAlias> languages);
    }
}