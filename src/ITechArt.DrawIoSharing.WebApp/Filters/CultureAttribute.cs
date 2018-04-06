using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ITechArt.DrawIoSharing.WebApp.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var langParameter = HttpContext.Current.Request.QueryString.GetValues("lang");
            if (langParameter != null)
            {
                var cookie = HttpContext.Current.Request.Cookies["lang"];
                if (cookie != null)
                    cookie.Value = langParameter[0];
                else
                {
                    cookie = new HttpCookie("lang")
                    {
                        HttpOnly = true,
                        Value = langParameter[0],
                        Expires = DateTime.Now.AddYears(1)
                    };
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            var cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            var cultureName = cultureCookie != null ? cultureCookie.Value : "en";
            var culture = CultureInfo.CreateSpecificCulture(cultureName);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}