using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageProvider
    {
        IReadOnlyCollection<Language> SupportedLanguages { get; }

        Language DefaultLanguage { get; }
    }
}