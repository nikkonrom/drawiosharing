using System.Web;

namespace ITechArt.Localization.Http
{
    public interface IHttpRequestLocalizationManager
    {
        void SetUpRequestCulture(HttpContext context);
    }
}