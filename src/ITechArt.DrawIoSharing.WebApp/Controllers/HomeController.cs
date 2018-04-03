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

        public ActionResult ChangeCulture(string lang)
        {
            var returnUrl = Request.UrlReferrer.AbsolutePath;
            var cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {

                cookie = new HttpCookie("lang")
                {
                    HttpOnly = false,
                    Value = lang,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);

            return Redirect(returnUrl);
        }
    }
}