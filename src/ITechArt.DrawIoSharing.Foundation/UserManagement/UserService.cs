using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;


        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task<IList<User>> GetAllAsync()
        {
            return await Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}