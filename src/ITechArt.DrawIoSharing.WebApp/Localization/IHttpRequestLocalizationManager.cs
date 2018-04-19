using System.Web;
using ITechArt.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public interface IHttpRequestLocalizationManager
    {
        Language SetUpRequestCulture(HttpContext context);
    }
}