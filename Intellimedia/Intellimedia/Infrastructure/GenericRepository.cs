using Intellimedia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intellimedia.Infrastructure
{
    public abstract class GenericRepository<TEntity> where TEntity : class
    {
        public virtual void Add(TEntity entity, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
        public virtual void AddRange(IEnumerable<TEntity> entities, ApplicationDbContext context)
        {
            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }
        public virtual void Update(TEntity entity, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public virtual void Remove(int id, TEntity entity, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            var toDelete = dbSet.Find(id);
            dbSet.Attach(toDelete);
            dbSet.Remove(toDelete);
            context.SaveChanges();
        }
        public virtual void Remove(Expression<Func<TEntity, bool>> where, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            IEnumerable<TEntity> objects = dbSet.Where<TEntity>(where).AsEnumerable();
            foreach (TEntity obj in objects)
                dbSet.Remove(obj);
            context.SaveChanges();
        }

        #region GetById

        public virtual TEntity GetById(long id, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Find(id);
        }

        public virtual TEntity GetById(string id, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Find(id);
        }

        #endregion

        public virtual IEnumerable<TEntity> GetAll(ApplicationDbContext context, int skip, int limit = 10)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.ToList().Skip(skip).Take(limit);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Where(where);
        }
        public virtual IEnumerable<TEntity> GetManyInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Where(where).Include(include).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return await dbSet.Where(where).Include(include).ToListAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> where, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public TEntity GetOrderByDesc(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> order, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Where(where).OrderByDescending(order).FirstOrDefault<TEntity>();
        }

        public TEntity GetInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Include(include).FirstOrDefault(where);
        }

        public TEntity GetInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> includeOne, Expression<Func<TEntity, object>> includeTwo, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Include(includeOne).Include(includeTwo).FirstOrDefault(where);
        }

        public async Task<TEntity> GetIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return await dbSet.Include(include).FirstOrDefaultAsync(where);
        }

        public async Task<TEntity> GetIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include1, Expression<Func<TEntity, object>> include2, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return await dbSet.Include(include1).Include(include2).FirstOrDefaultAsync(where);
        }
        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return await dbSet.Where(where).ToListAsync();
        }
        public virtual int Count(ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return dbSet.Count();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            dbSet.RemoveRange(entities);
            context.SaveChanges();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, ApplicationDbContext context)
        {
            var dbSet = context.Set<TEntity>();
            return await dbSet.FirstOrDefaultAsync(where);
        }
    }
}