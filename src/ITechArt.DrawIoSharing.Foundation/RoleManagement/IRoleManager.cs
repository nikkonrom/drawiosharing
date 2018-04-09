using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.RoleManagement
{
    public interface IRoleManager
    {
        IQueryable<Role> Roles { get; }

        Task<IdentityResult> CreateAsync(Role role);

        Task<Role> FindByIdAsync(int roleId);

        Task<IdentityResult> UpdateAsync(Role role);

        Task<IdentityResult> DeleteAsync(Role role);
    }
}