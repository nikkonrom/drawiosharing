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
            _dbContext.Dispose();
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
            return await GetByIdAsync(userId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            // ReSharper disable once BuiltInTypeReferenceStyle
             return Task.FromResult(_dbSet.FirstOrDefault(user => String.Equals(user.UserName, userName, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}
