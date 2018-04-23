using System.Web.Mvc;
using ITechArt.Common;

namespace ITechArt.Localization.Http
{
    [UsedImplicitly]
    public class NinjectPerRequestHttpLocalizationManager : IPerRequestHttpLocalizationManager
    {
        public IHttpRequestLocalizationManager GetPerRequestHttpLocalizationManager()
        {
            return DependencyResolver.Current.GetService<IHttpRequestLocalizationManager>();
        }
    }
}