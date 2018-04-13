using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public interface ICultureManagement
    {
        string SetUpCulture(HttpContext context);
    }
}