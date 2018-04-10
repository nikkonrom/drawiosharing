using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;

namespace ITechArt.DrawIoSharing.WebApp.Utils
{
    public static class Localization
    {
        private const string DefaultCultureName = "en";
        public const string QueryStringLanguageParameter = "lang";
        public const string CookieLanguageParameter = "lang";

        public static readonly Dictionary<string, string> NativeLanguageNames;

        private static string _actualCultureName;


        static Localization()
        {
            _actualCultureName = DefaultCultureName;
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
            var langParameter = HttpContext.Current.Request.QueryString.GetValues(QueryStringLanguageParameter);
            var cultureCookie = HttpContext.Current.Request.Cookies[CookieLanguageParameter] ?? new HttpCookie(CookieLanguageParameter)
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
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}