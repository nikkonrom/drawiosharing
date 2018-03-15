using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using ITechArt.Common;
using ITechArt.Common.Logging;

namespace ITechArt.Repositories
{
    [UsedImplicitly]
    public sealed class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        private readonly IDictionary<Type, object> _repositories;
        private bool _isDisposed;
        private ILogger logger = new Log4NetLogger();

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

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    logger.Error($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        logger.Error($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _isDisposed = true;
        }
    }
}
