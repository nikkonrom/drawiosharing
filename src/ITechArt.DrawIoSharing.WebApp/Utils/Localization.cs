using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Utils
{
    public static class Localization
    {
        public static void ChangeCulture()
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
            var cultureCookie = HttpContext.Current.Request.Cookies["lang"];
            var cultureName = cultureCookie != null ? cultureCookie.Value : "en";
            var culture = CultureInfo.CreateSpecificCulture(cultureName);

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}