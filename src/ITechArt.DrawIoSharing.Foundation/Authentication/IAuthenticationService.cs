using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.DrawIoSharing.Foundation.UserManagement;

namespace ITechArt.DrawIoSharing.Foundation.Authentication
{
    public interface IAuthenticationService
    {
        Task<OperationResult<SignUpError>> SignUpAsync(User user, string password);

        Task<OperationResult<SignInError>> SignInAsync(string userName, string password);

        Task SignOutAsync();
    }
}