using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        private readonly DbSet<TEntity> _dbSet;


        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet = dbContext.Set<TEntity>();
        }


        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }
    }
}
