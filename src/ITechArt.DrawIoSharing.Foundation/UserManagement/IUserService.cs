using System.Collections.Generic;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;

namespace ITechArt.DrawIoSharing.Foundation.UserManagement
{
    public interface IUserService
    {
        Task<IList<User>> GetAllUsersAsync();
    }
}