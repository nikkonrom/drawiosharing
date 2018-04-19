namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public class DrawIoSharingSupportedLanguage
    {
        public string CultureName { get; }

        public string NativeName { get; }


        public DrawIoSharingSupportedLanguage(string cultureName, string nativeName)
        {
            CultureName = cultureName;
            NativeName = nativeName;
        }
    }
}