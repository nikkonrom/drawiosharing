using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int entityId);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}
