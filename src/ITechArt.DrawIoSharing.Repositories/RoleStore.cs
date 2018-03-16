using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ITechArt.DrawIoSharing.DomainModel;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.Repositories
{
    class RoleStore : IQueryableRoleStore<Role>, IRoleStore<Role>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Role> _repository;


        public IQueryable<Role> Roles => _repository.GetAllAsync().Result.AsQueryable();


        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Role>();
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task CreateAsync(Role role)
        {
            _repository.Create(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Role role)
        {
            _repository.Update(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role role)
        {
            _repository.Delete(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Role> FindByIdAsync(string roleId)
        {
            return await _repository.GetByIdAsync(roleId);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            var result = (await _repository.GetAllAsync()).FirstOrDefault(role => String.Equals(role.Name.ToUpper(), roleName.ToUpper()));

            return await Task.FromResult(result);
        }
    }
}
