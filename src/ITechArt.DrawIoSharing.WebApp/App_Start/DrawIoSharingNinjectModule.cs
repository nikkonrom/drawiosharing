using System.Data.Entity;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class DrawIoSharingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().InRequestScope();
            Bind<DbContext>().To<DrawIoSharingDbContext>().InRequestScope();
            Bind<ILogger>().To<Log4NetLogger>().InSingletonScope();
        }
    }
}