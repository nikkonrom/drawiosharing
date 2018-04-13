using System.Data.Entity;
using System.Web;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.DrawIoSharing.WebApp.Localization;
using ITechArt.DrawIoSharing.WebApp.Modules;
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
            Bind<IUserService>().To<UserService>().InRequestScope();
            Bind<IUserStore<User, int>>().To<UserStore>().InRequestScope();
            Bind<IUserManager>().To<UserManager>().InRequestScope();
            Bind<IAuthenticationManager>().ToMethod(context => HttpContext.Current.GetOwinContext().Authentication);
            Bind<ICultureManagement>().To<CultureManagement>();
            Bind<IHttpModule>().To<LocalizationModule>();
        }
    }
}