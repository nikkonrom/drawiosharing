using System.Collections.Generic;

namespace ITechArt.Localization.Languages
{
    public interface ILanguageProvider
    {
        IReadOnlyCollection<Language> GetLanguages();
    }
}