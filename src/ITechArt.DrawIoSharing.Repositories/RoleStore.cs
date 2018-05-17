using System.Threading.Tasks;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;
using Microsoft.AspNet.Identity;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class RoleStore : IRoleStore<Role, int>
    {
        private readonly IUnitOfWork _unitOfWork;


        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task CreateAsync(Role role)
        {
            _unitOfWork.GetRepository<Role>().Create(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _unitOfWork.GetRepository<Role>().Update(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            _unitOfWork.GetRepository<Role>().Delete(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            return await _unitOfWork.GetRepository<Role>().GetByIdAsync(roleId);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await _unitOfWork.GetRepository<Role>().GetSingleOrDefaultAsync(role => role.Name == roleName);
        }
        public void Dispose()
        {

        }
    }
}