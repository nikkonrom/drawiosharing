using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserManager _userManager; 


        public AuthorizationService(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public void Approve(User user)
        {
            throw new System.NotImplementedException();
        }

        public void Disapprove(User user)
        {
            throw new System.NotImplementedException();
        }

        public void MakeAdmin(User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAdmin(User user)
        {
            throw new System.NotImplementedException();
        }

        public void BanUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UnbanUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> SetInitialRoleAsync(User user)
        {
            return await _userManager.AddToRoleAsync(user.Id, DefaultRole.DefaultUser.ToString());
        }

        public async Task<IList<DefaultRole>> GetRolesAsync(int userId)
        {
            return (await _userManager.GetRolesAsync(userId)).Select(ConvertRoleStringToEnum).ToList();
        }


        private static DefaultRole ConvertRoleStringToEnum(string roleString)
        {
            return (DefaultRole) Enum.Parse(typeof(DefaultRole), roleString);
        }
    }
}