using System.Collections.Generic;

namespace ITechArt.Localization
{
    public interface ILanguageProvider
    {
        IReadOnlyCollection<Language> GetLanguages();
    }
}