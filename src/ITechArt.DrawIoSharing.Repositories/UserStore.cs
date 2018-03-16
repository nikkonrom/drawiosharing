using System;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class UserStore : IUserStore<User, int>, IUserPasswordStore<User, int>
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
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
            // ReSharper disable once SpecifyStringComparison
            return await _unitOfWork.GetRepository<User>().GetByExpression(user => user.UserName.ToUpper() == userName.ToUpper());
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.Password = passwordHash;

            //Standard realization
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.Password != null);
        }
    }
}
