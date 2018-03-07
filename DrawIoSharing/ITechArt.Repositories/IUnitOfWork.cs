using System;

namespace ITechArt.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class;


        void Commit();
    }
}