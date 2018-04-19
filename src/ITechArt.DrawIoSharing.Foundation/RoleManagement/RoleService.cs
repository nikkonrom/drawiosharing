using ITechArt.DrawIoSharing.Foundation.UserManagement;

namespace ITechArt.DrawIoSharing.Foundation.RoleManagement
{
    public class RoleService : IRoleService
    {
        private readonly IUserManager _userManager;


        public RoleService(IUserManager userManager)
        {
            _userManager = userManager;
        }
    }
}