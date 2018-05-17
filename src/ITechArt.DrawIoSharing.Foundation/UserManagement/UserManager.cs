using System.Collections.Generic;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    [UsedImplicitly]
    public class UserManager : UserManager<User, int>, IUserManager
    {
        public UserManager(IUserStore<User, int> store)
            : base(store)
        {
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequireUppercase = true,
                RequiredLength = 6,
                RequireNonLetterOrDigit = false
            };
        }
    }
}
