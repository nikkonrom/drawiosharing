using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Repositories
{
    [UsedImplicitly]
    public class UserStore : IUserPasswordStore<User, int>
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public void Dispose()
        {

        }
    }
}
