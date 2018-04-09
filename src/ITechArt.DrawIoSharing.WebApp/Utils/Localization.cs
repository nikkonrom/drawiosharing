using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Utils
{
    public static class Localization
    {
        private static readonly Dictionary<string, string> NativeLanguageNames;
        private static readonly string DefaultCultureName;

        private static string _actualCultureName;


        static Localization()
        {
            _actualCultureName = DefaultCultureName = "en";
            NativeLanguageNames = new Dictionary<string, string>
            {
                {"en", "English" },
                {"ru", "Русский (Russian)" }
            };
        }


        public static string GetLocalizedNameOfActualLanguage()
        {
            return NativeLanguageNames[_actualCultureName];
        }

        public static void Localize(object sender, EventArgs args)
        {
            var langParameter = HttpContext.Current.Request.QueryString.GetValues("lang");
            var cultureCookie = HttpContext.Current.Request.Cookies["lang"] ?? new HttpCookie("lang")
            {
                HttpOnly = true,
                Value = DefaultCultureName,
                Expires = DateTime.Now.AddYears(1)
            };
            if (langParameter != null && NativeLanguageNames.ContainsKey(langParameter[0]))
            {
                _actualCultureName = cultureCookie.Value = langParameter[0];
            }
            HttpContext.Current.Response.Cookies.Set(cultureCookie);
            var culture = CultureInfo.CreateSpecificCulture(cultureCookie.Value);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}