using System;
using System.Globalization;
using System.Threading;
using System.Web;
using ITechArt.Common;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class CultureManagement
    {
        public const string QueryStringLanguageParameter = "lang";
        public const string KeyForLanguageNameAccess = "ActualLanguageName";

        private const string DefaultCultureName = "en";
        private const string CookieLanguageParameter = "lang";

        private string _actualCultureName;


        public CultureManagement()
        {
            _actualCultureName = DefaultCultureName;
        }


        public string SetUpCulture(HttpContext context)
        {
            var langParameter = context.Request.QueryString.GetValues(QueryStringLanguageParameter)?[0];
            var cultureCookie = context.Request.Cookies[CookieLanguageParameter] ?? new HttpCookie(CookieLanguageParameter)
            {
                HttpOnly = true,
                Value = DefaultCultureName,
                Expires = DateTime.MaxValue
            };
            if (langParameter != null && LanguageRegistrations.SupportedLanguages.ContainsKey(langParameter))
            {
                _actualCultureName = cultureCookie.Value = langParameter;
                context.Response.Cookies.Set(cultureCookie);
            }
            var culture = CultureInfo.CreateSpecificCulture(cultureCookie.Value);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            return LanguageRegistrations.SupportedLanguages[_actualCultureName];
        }
    }
}