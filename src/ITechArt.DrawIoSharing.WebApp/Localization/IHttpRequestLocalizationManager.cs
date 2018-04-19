using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public interface IHttpRequestLocalizationManager
    {
        DrawIoSharingSupportedLanguage SetUpRequestCulture(HttpContext context);
    }
}