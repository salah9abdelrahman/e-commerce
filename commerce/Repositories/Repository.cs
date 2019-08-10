using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using commerce.Core.IRepositories;

namespace commerce.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //we declare it protected to used in the repositories
        protected readonly DbContext dbContext;
        public Repository(DbContext context)
        {
            dbContext = context;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int? id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public TEntity Get(string id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public int Count()
        {
            return dbContext.Set<TEntity>().Count();
        }
    }
}