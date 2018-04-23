namespace ITechArt.Localization.Http
{
    public interface IPerRequestHttpLocalizationManager
    {
        IHttpRequestLocalizationManager GetPerRequestHttpLocalizationManager();
    }
}