using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    public class AuthorizationService : UserManager, IAuthorizationService
    {
        public AuthorizationService(IUserStore<User, int> store) : base(store)
        {
        }

        public void ApproveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DisapproveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void MakeUserAdmin(User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUserAdmin(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}