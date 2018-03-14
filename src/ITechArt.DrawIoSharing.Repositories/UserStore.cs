using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Repositories
{
    class UserStore : EFRepository<User>, IUserStore<User>
    {
        public UserStore(DbContext dbContext) : base(dbContext)
        {
        }

        public void Dispose()
        {
            
        }

        public async Task CreateAsync(User user)
        {
            Create(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            Delete(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            var result = await GetByIdAsync(userId);
            await _dbContext.SaveChangesAsync();

            return result;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            throw  new NotImplementedException();
            //var result =
        }
    }
}
