using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageConverter
    {
        Language ConvertAliasToLanguage(LanguageAlias language);
        IReadOnlyCollection<Language> ConvertAliasesToLanguages(IReadOnlyCollection<LanguageAlias> languages);
    }
}