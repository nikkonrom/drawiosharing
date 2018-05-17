using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    [UsedImplicitly]
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserManager _userManager; 


        public AuthorizationService(IUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task ApproveAsync(int userId)
        {
            await _userManager.AddToRoleAsync(userId, DefaultRole.ApprovedUser.ToString());
        }

        public async Task DisapproveAsync(int userId)
        {
            await _userManager.RemoveFromRoleAsync(userId, DefaultRole.ApprovedUser.ToString());
        }

        public async Task MakeAdminAsync(int userId)
        {
            await _userManager.AddToRoleAsync(userId, DefaultRole.Admin.ToString());
        }

        public async Task RemoveAdminAsync(int userId)
        {
            await _userManager.RemoveFromRoleAsync(userId, DefaultRole.Admin.ToString());
        }

        public async Task BanAsync(int userId)
        {
            await _userManager.AddToRoleAsync(userId, DefaultRole.BannedUser.ToString());
        }

        public async Task UnbanAsync(int userId)
        {
            await _userManager.RemoveFromRoleAsync(userId, DefaultRole.BannedUser.ToString());
        }

        public async Task<IdentityResult> SetInitialRoleAsync(int userId)
        {
            return await _userManager.AddToRoleAsync(userId, DefaultRole.DefaultUser.ToString());
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