namespace ITechArt.Localization.Languages
{
    public class LanguageInfo
    {
        public string CultureName { get; }

        public string NativeName { get; }


        public LanguageInfo(string cultureName, string nativeName)
        {
            CultureName = cultureName;
            NativeName = nativeName;
        }
    }
}