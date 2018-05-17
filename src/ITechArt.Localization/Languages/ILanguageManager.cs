using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageManager
    {
        IReadOnlyCollection<LanguageInfo> SupportedLanguages { get; }

        LanguageInfo DefaultLanguage { get; }
    }
}