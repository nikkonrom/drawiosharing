using System.Web.Mvc;
using ITechArt.Common;

namespace ITechArt.Localization.Http
{
    [UsedImplicitly]
    public class HttpRequestLocalizationManagerFactory : IHttpRequestLocalizationManagerFactory
    {
        public IHttpRequestLocalizationManager GetHttpRequestLocalizationManager()
        {
            return DependencyResolver.Current.GetService<IHttpRequestLocalizationManager>();
        }
    }
}