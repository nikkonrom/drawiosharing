using System.Security.Claims;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public interface IUserService
    {
        Task<SignUpResult> SignUpAsync(User user, string password);

        Task<User> FindAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);
    }
}