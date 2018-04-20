using System;
using System.Collections.Generic;
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

        private const string DefaultCultureName = "en";
        private const string CookieLanguageParameter = "lang";

        private readonly ILanguageProvider _languageProvider;


        public HttpRequestLocalizationManager(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }


        public Language SetUpRequestCulture(HttpContext context)
        {
            var cultureName = SelectRequestCulture(context);
            ApplyRequestCulture(cultureName);

            return _languageProvider.GetLanguage(cultureName);
        }

        public IReadOnlyCollection<Language> GetSupportedLanguages()
        {
            return _languageProvider.GetLanguages();
        }


        private string SelectRequestCulture(HttpContext context)
        {
            var langParameter = context.Request.QueryString.GetValues(QueryStringLanguageParameter)?[0];
            var cultureCookie = context.Request.Cookies[CookieLanguageParameter] ?? new HttpCookie(CookieLanguageParameter)
            {
                HttpOnly = true,
                Value = DefaultCultureName,
                Expires = DateTime.MaxValue
            };
            if (langParameter != null && _languageProvider.CheckIfLanguageSupported(langParameter))
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