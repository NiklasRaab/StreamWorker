using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Data.Model;

namespace Framework.Business.Repository
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity FindByKey(int id);
        IEnumerable<TEntity> FindByKey(IEnumerable<int> ids);
        void Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(int i);
        void Delete(IEnumerable<int> ids);
        void Edit(TEntity entity);
        void SaveAsync();
    }
}