using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string entityId);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}