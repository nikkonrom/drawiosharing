namespace ITechArt.Localization.Languages
{
    public interface ILanguageConverter
    {
        LanguageInfo ConvertLanguageToLanguageInfo(Language language);
    }
}