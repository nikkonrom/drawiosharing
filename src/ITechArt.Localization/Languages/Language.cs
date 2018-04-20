namespace ITechArt.Localization
{
    public class Language
    {
        public string CultureName { get; }

        public string NativeName { get; }


        public Language(string cultureName, string nativeName)
        {
            CultureName = cultureName;
            NativeName = nativeName;
        }
    }
}