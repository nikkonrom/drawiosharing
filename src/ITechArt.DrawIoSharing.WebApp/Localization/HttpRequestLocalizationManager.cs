using System;
using System.Globalization;
using System.Threading;
using System.Web;
using ITechArt.Common;
using ITechArt.Localization;

namespace ITechArt.DrawIoSharing.WebApp.Localization
{
    [UsedImplicitly]
    public class HttpRequestLocalizationManager : IHttpRequestLocalizationManager
    {
        public const string QueryStringLanguageParameter = "lang";
        public const string KeyForLanguageNameAccess = "ActualLanguageName";

        private const string DefaultCultureName = "en";
        private const string CookieLanguageParameter = "lang";


        public Language SetUpRequestCulture(HttpContext context)
        {
            var cultureName = SelectRequestCulture(context);
            ApplyRequestCulture(cultureName);

            return LanguageRegistrationManager.GetLanguage(cultureName);
        }


        private static string SelectRequestCulture(HttpContext context)
        {
            var langParameter = context.Request.QueryString.GetValues(QueryStringLanguageParameter)?[0];
            var cultureCookie = context.Request.Cookies[CookieLanguageParameter] ?? new HttpCookie(CookieLanguageParameter)
            {
                HttpOnly = true,
                Value = DefaultCultureName,
                Expires = DateTime.MaxValue
            };
            if (langParameter != null && LanguageRegistrationManager.SupportsLanguage(langParameter))
            {
                cultureCookie.Value = langParameter;
                context.Response.Cookies.Set(cultureCookie);
            }

            return cultureCookie.Value;
        }

        private static void ApplyRequestCulture(string cultureName)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}