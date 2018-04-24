using System;
using System.Globalization;
using System.Threading;
using System.Web;
using ITechArt.Common;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization.Http
{
    [UsedImplicitly]
    public class HttpRequestLocalizationManager : IHttpRequestLocalizationManager
    {
        public const string QueryStringLanguageParameter = "lang";
        public const string KeyForLanguageNameAccess = "ActualLanguageName";
        public const string KeyForSupportedLanguagesAccess = "SupportedLanguages";

        private const string CookieLanguageParameter = "lang";

        private readonly ILanguageManager _languageManager;


        public HttpRequestLocalizationManager(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }


        public void SetUpRequestCulture(HttpContext context)
        {
            var cultureName = SelectRequestCulture(context);
            ApplyRequestCulture(cultureName);
            context.AddCurrentLanguage(_languageManager.GetLanguageByCultureName(cultureName));
            context.AddSupportedLanguages(_languageManager.SupportedLanguages);
        }


        private string SelectRequestCulture(HttpContext context)
        {
            var langParameter = context.Request.QueryString.GetValues(QueryStringLanguageParameter)?[0];
            var cultureCookie = context.Request.Cookies[CookieLanguageParameter];
            if (cultureCookie == null || !_languageManager.CheckIfLanguageSupported(cultureCookie.Value))
            {
                cultureCookie = new HttpCookie(CookieLanguageParameter)
                {
                    HttpOnly = true,
                    Value = _languageManager.DefaultLanguage.CultureName,
                    Expires = DateTime.MaxValue
                };
            }
            if (langParameter != null && _languageManager.CheckIfLanguageSupported(langParameter))
            {
                cultureCookie.Value = langParameter;
                context.Response.Cookies.Set(cultureCookie);
            }

            return cultureCookie.Value;
        }

        private void ApplyRequestCulture(string cultureName)
        {
            var culture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}