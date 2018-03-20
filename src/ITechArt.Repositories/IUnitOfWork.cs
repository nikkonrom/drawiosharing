using System;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveChangesAsync();
    }
}