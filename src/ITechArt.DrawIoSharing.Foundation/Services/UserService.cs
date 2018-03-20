using System.Linq;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Services
{
    [UsedImplicitly]
    public class UserService : IUserService<User>
    {
        private readonly UserManager<User, int> _userManager;


        public UserService(IUserStore<User, int> store)
        {
            _userManager = new UserManager<User, int>(store)
            {
                PasswordValidator = new PasswordValidator()
                {
                    RequireDigit = true,
                    RequireUppercase = true,
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false
                }
            };

            _userManager.UserValidator = new UserValidator<User, int>(_userManager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
        }


        public async Task<SignUpOperationResult> CreateUserAsync(User user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);
            var operationResult = new SignUpOperationResult(identityResult.Errors.ToList(), identityResult.Succeeded);

            return await Task.FromResult(operationResult);
        }

        public void Dispose()
        {

        }
    }
}
