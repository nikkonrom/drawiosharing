using System.Collections.Generic;
using System.Web;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization.Http
{
    public interface IHttpRequestLocalizationManager
    {
        LanguageInfo SetUpRequestCulture(HttpContext context);

        IReadOnlyCollection<LanguageInfo> GetSupportedLanguages();
    }
}