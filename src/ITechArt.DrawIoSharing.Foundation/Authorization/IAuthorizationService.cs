using System.Collections.Generic;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.Foundation.RoleManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.Authorization
{
    public interface IAuthorizationService
    {
        Task ApproveAsync(int userId);

        Task DisapproveAsync(int userId);

        Task MakeAdminAsync(int userId);

        Task RemoveAdminAsync(int userId);

        Task BanAsync(int userId);

        Task UnbanAsync(int userId);

        Task<IdentityResult> SetInitialRoleAsync(int userId);

        Task<IList<DefaultRole>> GetRolesAsync(int userId);
    }
}