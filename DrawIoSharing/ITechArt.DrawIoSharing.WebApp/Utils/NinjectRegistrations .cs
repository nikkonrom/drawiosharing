using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITechArt.DrawIoSharing.Foundation;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Ninject.Modules;

namespace ITechArt.DrawIoSharing.WebApp.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<User>>().To<EFRepository<User>>();
        }
    }
}