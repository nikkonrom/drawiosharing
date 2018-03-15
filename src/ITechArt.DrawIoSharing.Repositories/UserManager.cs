using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class UserManager : UserManager<User>
    {
        private UserManager(IUserStore<User> store) : base(store)
        {

        }


        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var dbContext = context.Get<DrawIoSharingDbContext>();
            var manager = new UserManager(new UserStore(dbContext));
            manager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequireUppercase = true,
                RequiredLength = 6,
                RequireNonLetterOrDigit = false
            };


            return manager;
        }
    }
}
