using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password);
    }
}