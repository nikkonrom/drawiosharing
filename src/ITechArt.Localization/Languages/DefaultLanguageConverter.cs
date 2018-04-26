using System.Collections.Generic;
using ITechArt.Common;

namespace ITechArt.Localization.Languages
{
    [UsedImplicitly]
    public class DefaultLanguageConverter : ILanguageConverter
    {
        private static readonly IReadOnlyDictionary<Language, LanguageInfo> LanguageInfos;


        static DefaultLanguageConverter()
        {
            LanguageInfos = new Dictionary<Language, LanguageInfo>
                {
                    { Language.English, new LanguageInfo("en", "English") },
                    { Language.Russian, new LanguageInfo("ru", "Русский (Russian)") }
                };
        }


        public LanguageInfo ConvertLanguageToLanguageInfo(Language language)
        {
            return LanguageInfos[language];
        }
    }
}