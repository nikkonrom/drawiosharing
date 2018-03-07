using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity: class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();


        Task<TEntity> GetByIdAsync(int entityId);
    }
}