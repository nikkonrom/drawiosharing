using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public interface IUserService
    {
        Task<OperationResult<SignUpError>> SignUpAsync(User user, string password);

        Task<OperationResult<SignInError>> SignInAsync(string userName, string password);

        Task SignOutAsync();
    }
}