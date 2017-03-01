using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Framework.Data.Data;
using Framework.Data.Model;

namespace Framework.Business.Repository
{
    public class Repository<TEntity, TDataContext> : IRepository<TEntity>
        where TEntity : BaseEntity where TDataContext : IBaseDataContext<TDataContext>
    {
        public Repository(TDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public TDataContext DataContext { get; set; }

        public void Add(TEntity entity)
        {
            DataContext.Set<TEntity>().Add(entity);
        }

        public void Add(IEnumerable<TEntity> entity)
        {
            DataContext.Set<TEntity>().AddRange(entity);
        }

        public IQueryable<TEntity> All()
        {
            return DataContext.Set<TEntity>();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            DataContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Delete(int i)
        {
            Delete(FindByKey(i));
        }

        public void Delete(IEnumerable<int> ids)
        {
            Delete(FindByKey(ids));
        }

        public void Delete(TEntity entity)
        {
            DataContext.Set<TEntity>().Remove(entity);
        }

        public void Edit(TEntity entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            var query = DataContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public IEnumerable<TEntity> FindByKey(IEnumerable<int> ids)
        {
            return ids.Select(FindByKey);
        }

        public TEntity FindByKey(int id)
        {
            return DataContext.Set<TEntity>().Find(id);
        }

        public async void SaveAsync()
        {
            await DataContext.SaveChangesAsync();
        }
    }
}