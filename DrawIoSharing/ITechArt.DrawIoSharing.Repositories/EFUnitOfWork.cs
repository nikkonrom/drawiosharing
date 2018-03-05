using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private Dictionary<Type, object> _repositories;

        private EFServiceContext _dataContext;

        private bool _disposed;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;

            IRepository<TEntity> repository = new EFRepository<TEntity>(_dataContext);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        protected  virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
