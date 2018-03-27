using System.Web.Mvc;
using ITechArt.Common.Logging;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;


        public HomeController(ILogger logger)
        {
            _logger = logger;
        }


        public ViewResult Index()
        {
            _logger.Debug("App started");

            return View();
        }
    }
}