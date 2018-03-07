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

        private bool _disposed;

        private Dictionary<Type, object> _repositories;
        private EFServiceContext _dataContext;


        public EFUnitOfWork()
        {
            _dataContext = new EFServiceContext();
            _repositories = new Dictionary<Type, object>();
        }


        public IRepositoryAsync<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepositoryAsync<TEntity>;

            IRepositoryAsync<TEntity> repository = new EFRepository<TEntity>(_dataContext);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        
        public void Commit()
        {
            _dataContext.SaveChanges();
        }


        protected  virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
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
