using System.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}