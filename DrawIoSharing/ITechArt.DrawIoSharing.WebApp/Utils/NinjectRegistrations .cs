using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Ninject.Modules;

namespace ITechArt.DrawIoSharing.WebApp.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<User>>().To<EFRepository<User>>();
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
            Bind<ILogger>().To<Log4NetAdapter>();
        }
    }
}