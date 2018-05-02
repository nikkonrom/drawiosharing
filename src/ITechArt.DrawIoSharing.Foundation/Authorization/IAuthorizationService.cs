using System.Collections.Generic;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    public interface IAuthorizationService
    {
        void Approve(User user);

        void Disapprove(User user);

        void MakeAdmin(User user);

        void RemoveAdmin(User user);

        void BanUser(User user);

        void UnbanUser(User user);

        Task<IdentityResult> SetInitialRoleAsync(User user);

        Task<IList<DefaultRole>> GetRolesAsync(int userId);
    }
}