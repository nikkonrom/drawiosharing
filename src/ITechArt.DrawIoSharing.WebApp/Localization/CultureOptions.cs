using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class CultureOptions
    {
        public const string QueryStringLanguageParameter = "lang";
        public static readonly Dictionary<string, string> NativeLanguageNames;

        private const string DefaultCultureName = "en";
        private const string CookieLanguageParameter = "lang";

        private string _actualCultureName;


        static CultureOptions()
        {
            NativeLanguageNames = new Dictionary<string, string>
            {
                {"en", "English" },
                {"ru", "Русский (Russian)" }
            };
        }

        public CultureOptions()
        {
            _actualCultureName = DefaultCultureName;
        }


        public string GetLocalizedNameOfActualLanguage()
        {
            return NativeLanguageNames[_actualCultureName];
        }

        public void SetUpCulture()
        {
            var isNeedToSetCookie = false;
            var langParameter = HttpContext.Current.Request.QueryString.GetValues(QueryStringLanguageParameter);
            var cultureCookie = HttpContext.Current.Request.Cookies[CookieLanguageParameter];
            if (cultureCookie == null)
            {
                cultureCookie = new HttpCookie(CookieLanguageParameter)
                {
                    HttpOnly = true,
                    Value = DefaultCultureName,
                    Expires = DateTime.Now.AddYears(1)
                };
                isNeedToSetCookie = true;
            }
            if (langParameter != null && NativeLanguageNames.ContainsKey(langParameter[0]))
            {
                _actualCultureName = cultureCookie.Value = langParameter[0];
                isNeedToSetCookie = true;
            }
            if (isNeedToSetCookie)
            {
                HttpContext.Current.Response.Cookies.Set(cultureCookie);
            }
            var culture = CultureInfo.CreateSpecificCulture(cultureCookie.Value);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}