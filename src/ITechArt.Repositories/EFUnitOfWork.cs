using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private readonly IDictionary<Type, object> _repositories;
        private bool _disposed;


        public EFUnitOfWork(DbContext context)
        {
            _dbContext = context;

            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                return (IRepository<TEntity>)repository;
            }

            var newRepository = new EFRepository<TEntity>(_dbContext);
            _repositories.Add(typeof(TEntity), newRepository);

            return newRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
