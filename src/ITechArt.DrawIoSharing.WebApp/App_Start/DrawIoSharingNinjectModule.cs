using System.Data.Entity;
using System.Web;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.Authentication;
using ITechArt.DrawIoSharing.Foundation.Authorization;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Localization.Http;
using ITechArt.Localization.Languages;
using ITechArt.Localization.Modules;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class DrawIoSharingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Log4NetLogger>().InSingletonScope();
            Bind<DbContext>().To<DrawIoSharingDbContext>().InRequestScope();
            Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();
            Bind<IAuthenticationService>().To<AuthenticationService>().InRequestScope();
            Bind<IUserStore<User, int>>().To<UserStore>().InRequestScope();
            Bind<IUserManager>().To<UserManager>().InRequestScope();
            Bind<IAuthenticationManager>().ToMethod(context => HttpContext.Current.GetOwinContext().Authentication);
            Bind<ILanguageConverter>().To<DefaultLanguageConverter>().InSingletonScope();
            Bind<ILanguageProvider>().To<LanguageProvider>().InSingletonScope();
            Bind<ILanguageManager>().To<LanguageManager>().InSingletonScope();
            Bind<IHttpRequestLocalizationManager>().To<HttpRequestLocalizationManager>().InRequestScope();
            Bind<IHttpRequestLocalizationManagerFactory>().To<HttpRequestLocalizationManagerFactory>().InSingletonScope();
            Bind<IHttpModule>().To<LocalizationModule>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<IAuthorizationService>().To<AuthorizationService>().InRequestScope();
        }
    }
}