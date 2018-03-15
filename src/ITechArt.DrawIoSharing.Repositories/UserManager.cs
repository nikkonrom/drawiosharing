using ITechArt.Common.Logging;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
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
            IUnitOfWork unitOfWork = new EFUnitOfWork(new DrawIoSharingDbContext());

            var manager = new UserManager(new UserStore(unitOfWork))
            {
                PasswordValidator = new PasswordValidator()
                {
                    RequireDigit = true,
                    RequireUppercase = true,
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false
                }
            };

            return manager;
        }
    }
}
