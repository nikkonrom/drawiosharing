using System;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation
{
    public class UserService : IUserService<User>, IDisposable
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
        }


        public async Task<OperationResult> CreateUserAsync(User user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);
            var operationResult = new OperationResult(identityResult.Errors.ToList(), identityResult.Succeeded);
            
            return await Task.FromResult(operationResult);
        }

        public void Dispose()
        {
            _userManager?.Dispose();
        }
    }
}
