using System;
using System.Threading.Tasks;

namespace ITechArt.DrawIoSharing.Foundation.Services
{
    public interface IUserService<in TUser> : IDisposable where TUser : class
    {
        Task<SignUpOperationResult> CreateUserAsync(TUser user, string password);
    }
}