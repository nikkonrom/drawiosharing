using System.Data.Entity;
using System.Web.Mvc;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.Services;
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
            ModelValidatorProviders.Providers.Clear();

            Bind<ILogger>().To<Log4NetLogger>().InSingletonScope();
            Bind<DbContext>().To<DrawIoSharingDbContext>().InRequestScope();
            Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();
            Bind<IUserService<User>>().To<UserService>();
            Bind<IUserStore<User, int>>().To<UserStore>();
        }
    }
}