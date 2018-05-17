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

        private const string LanguageCookieName = "lang";

        private readonly ILanguageManager _languageManager;


        public HttpRequestLocalizationManager(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }


        public void SetUpRequestCulture(HttpContext context)
        {
            var languageInfo = SelectRequestCulture(context);
            ApplyRequestCulture(languageInfo);
            context.AddCurrentLanguage(languageInfo);
            context.AddSupportedLanguages(_languageManager.SupportedLanguages);
        }


        private LanguageInfo SelectRequestCulture(HttpContext context)
        {
            var langParameter = context.Request.QueryString.GetValues(QueryStringLanguageParameter)?[0];
            var cultureCookie = context.Request.Cookies[LanguageCookieName];
            if (cultureCookie == null || !_languageManager.CheckIfLanguageSupported(cultureCookie.Value))
            {
                cultureCookie = new HttpCookie(LanguageCookieName)
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

            return _languageManager.GetLanguageByCultureName(cultureCookie.Value);
        }

        private static void ApplyRequestCulture(LanguageInfo languageInfo)
        {
            var culture = CultureInfo.CreateSpecificCulture(languageInfo.CultureName);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}