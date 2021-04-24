using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IGenericRepository<TEntity>  where TEntity: class
    {   
        Task<IEnumerable<TEntity>> GetAll();
        ValueTask<TEntity> GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update (TEntity entity);


    }
}