using System.Threading.Tasks;

namespace ITechArt.DrawIoSharing.Foundation
{
    public interface IUserService<in TUser> where TUser : class
    {
        Task<OperationResult> CreateUserAsync(TUser user, string password);
    }
}