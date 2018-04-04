using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            var cultureName = cultureCookie != null ? cultureCookie.Value : "en";

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}