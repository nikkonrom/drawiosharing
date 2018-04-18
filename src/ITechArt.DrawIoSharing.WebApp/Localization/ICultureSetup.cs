using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    public interface ICultureSetup
    {
        string SetUpCulture(HttpContext context);
    }
}