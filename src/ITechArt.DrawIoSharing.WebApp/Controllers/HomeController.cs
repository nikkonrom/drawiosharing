using System;
using System.Web;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.WebApp.Filters;

namespace ITechArt.DrawIoSharing.WebApp.Controllers
{
    [Authorize, Culture]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;


        public HomeController(ILogger logger)
        {
            _logger = logger;
        }


        public ViewResult Index()
        {
            return View();
        }
    }
}