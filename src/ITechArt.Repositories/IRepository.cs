using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(object entityId);

        Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}