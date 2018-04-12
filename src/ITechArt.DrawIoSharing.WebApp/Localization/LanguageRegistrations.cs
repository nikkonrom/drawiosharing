using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public static class LanguageRegistrations
    {
        public static readonly IReadOnlyDictionary<string, string> SupportedLanguages;


        static LanguageRegistrations()
        {
            SupportedLanguages = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
            {
                {"en", "English" },
                {"ru", "Русский (Russian)" }
            });
        }
    }
}