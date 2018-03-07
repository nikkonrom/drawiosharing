﻿using System.Collections.Generic;

namespace ITechArt.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> GetAll();


        TEntity GetById(int entityId);


        void Create(TEntity entity);


        void Delete(TEntity entity);


        void Update(TEntity entity);
    }
}
