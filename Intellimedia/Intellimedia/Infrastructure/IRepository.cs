using Intellimedia.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intellimedia.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity, ApplicationDbContext context);
        void AddRange(IEnumerable<TEntity> entities, ApplicationDbContext context);
        void Update(TEntity entity, ApplicationDbContext context);
        void Remove(int id, TEntity entity, ApplicationDbContext context);
        void Remove(Expression<Func<TEntity, bool>> where, ApplicationDbContext context);
        TEntity GetById(long id, ApplicationDbContext context);
        TEntity GetById(string id, ApplicationDbContext context);
        TEntity GetInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context);
        TEntity GetInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> includeOne, Expression<Func<TEntity, object>> includeTwo, ApplicationDbContext context);
        TEntity Get(Expression<Func<TEntity, bool>> where, ApplicationDbContext context);
        TEntity GetOrderByDesc(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> order, ApplicationDbContext context);
        IEnumerable<TEntity> GetAll(ApplicationDbContext context, int skip, int limit = 10);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where, ApplicationDbContext context);
        int Count(ApplicationDbContext context);
        void RemoveRange(IEnumerable<TEntity> entities, ApplicationDbContext context);
        IEnumerable<TEntity> GetManyInclude(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context);

        //Async Methods
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where, ApplicationDbContext context);
        Task<TEntity> GetIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context);
        Task<TEntity> GetIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include1, Expression<Func<TEntity, object>> include2, ApplicationDbContext context);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, ApplicationDbContext context);
        Task<IEnumerable<TEntity>> GetManyIncludeAsync(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> include, ApplicationDbContext context);
    }
}