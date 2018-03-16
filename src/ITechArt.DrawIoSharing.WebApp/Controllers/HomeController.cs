using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;


        public HomeController(ILogger logger)
        {
            _logger = logger;
        }


        public ViewResult Index()
        {
            _logger.Debug("App runs!");

            return View();
        }
    }
}