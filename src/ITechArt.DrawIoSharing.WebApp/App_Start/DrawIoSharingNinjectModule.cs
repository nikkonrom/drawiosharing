using System.Data.Entity;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;
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
            Bind<IUserService>().To<UserService>();
            Bind<IUserStore<User, int>>().To<UserStore>();
            Bind<IUserManager>().To<UserManager>();
        }
    }
}