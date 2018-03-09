using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ITechArt.Repositories;

namespace ITechArt.DrawIoSharing.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _dataContext;
        private readonly DbSet<TEntity> _dbSet;


        public EFRepository(DbContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TEntity>();
        }


        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }


        public async Task<TEntity> GetByIdAsync(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }
    }
}
