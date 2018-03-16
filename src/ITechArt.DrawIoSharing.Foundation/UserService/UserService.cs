using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Repositories;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace ITechArt.DrawIoSharing.Foundation.UserService
{
    public class UserService : UserManager<User>, IUserService<User>
    {
        private UserService(IUserStore<User> store) : base(store)
        {
            
        }


        public static UserService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            IUnitOfWork unitOfWork = new EFUnitOfWork(new DrawIoSharingDbContext());

            var manager = new UserService(new UserStore(unitOfWork))
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

        public async Task<OperationResult> CreateUserAsync(User user, string password)
        {
            var identityResult = await CreateAsync(user, password);
            var operationReslt = new OperationResult(identityResult.Errors.ToList().AsReadOnly(), identityResult.Succeeded);

            return await Task.FromResult(operationReslt);
        }
    }
}
