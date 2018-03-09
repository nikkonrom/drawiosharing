using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IDictionary<Type, object> _repositories;
        private bool _disposed;

        private readonly DbContext _dbContext;


        public EFUnitOfWork(DbContext context)
        {
            _dbContext = context;

            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var newRepository = new EFRepository<TEntity>(_dbContext);
            _repositories.Add(typeof(TEntity), newRepository);

            return newRepository;
        }


        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
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
