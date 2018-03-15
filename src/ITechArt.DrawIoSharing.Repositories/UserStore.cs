using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class UserStore : IQueryableUserStore<User>, IUserStore<User>, IUserPasswordStore<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _repository;


        public IQueryable<User> Users => _repository.GetAllAsync().Result.AsQueryable();


        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<User>();
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task CreateAsync(User user)
        {
            _repository.Create(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _repository.Update(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _repository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return await _repository.GetByIdAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            var result = (await _repository.GetAllAsync()).FirstOrDefault(user => String.Equals(user.UserName.ToUpper(), userName.ToUpper()));

            return await Task.FromResult(result);
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
