using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    [UsedImplicitly]
    public class RequisiteUserManager : UserManager<User, int>, IUserManager
    {
        public RequisiteUserManager(IUserStore<User, int> store) : base(store)
        {
            PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequireUppercase = true,
                RequiredLength = 6,
                RequireNonLetterOrDigit = false
            };
        }
    }
}
