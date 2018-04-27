using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Repositories
{
    [UsedImplicitly]
    public class UserStore : IUserPasswordStore<User, int>, IUserRoleStore<User, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleStore _roleStore;
        
        public UserStore(IUnitOfWork unitOfWork, RoleStore roleStore)
        {
            _unitOfWork = unitOfWork;
            _roleStore = roleStore;
        }


        public async Task CreateAsync(User user)
        {
            _unitOfWork.GetRepository<User>().Create(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _unitOfWork.GetRepository<User>().Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _unitOfWork.GetRepository<User>().Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await _unitOfWork.GetRepository<User>().GetByIdAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _unitOfWork.GetRepository<User>().GetSingleOrDefaultAsync(user => user.UserName == userName);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;

            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.Password != null);
        }

        public async Task AddToRoleAsync(User user, string roleName)
        {
            var userRole = await _roleStore.FindByNameAsync(roleName);
            user.Roles.Add(userRole);
        }

        public async Task RemoveFromRoleAsync(User user, string roleName)
        {
            var userRole = await _roleStore.FindByNameAsync(roleName);
            user.Roles.Remove(userRole);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await Task.FromResult((IList<string>)user.Roles.ConvertAll(role => role.Name));
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName)
        {
            var userRole = await _roleStore.FindByNameAsync(roleName);
            return await Task.FromResult(user.Roles.Any(role => role == userRole));
        }
        public void Dispose()
        {

        }
    }
}
