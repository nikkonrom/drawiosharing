using System.Data.Entity;
using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Ninject.Modules;

namespace ITechArt.DrawIoSharing.WebApp
{
    public class DrawIoSharingNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
            Bind<DbContext>().To<DrawIoSharingDbContext>();
            Bind<ILogger>().To<Log4NetLogger>();
        }
    }
}