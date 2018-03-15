using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.Repositories
{
    class RoleStore : EFRepository<Role>, IRoleStore<Role>
    {
        public RoleStore(DbContext dbContext) : base(dbContext)
        {

        }


        public async Task CreateAsync(Role role)
        {
            Create(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            Update(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            Delete(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> FindByIdAsync(string roleId)
        {
            return await GetByIdAsync(roleId);
        }

        public Task<Role> FindByNameAsync(string roleName)
        {
            return Task.FromResult(_dbSet.FirstOrDefault(role => String.Equals(role.Name, roleName, StringComparison.CurrentCultureIgnoreCase)));
        }

        public void Dispose()
        {

        }
    }
}
