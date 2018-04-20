using System.Collections.Generic;
using System.Web;
using ITechArt.Localization.Languages;

namespace ITechArt.Localization.Http
{
    public interface IHttpRequestLocalizationManager
    {
        Language SetUpRequestCulture(HttpContext context);

        IReadOnlyCollection<Language> GetSupportedLanguages();
    }
}