using System;
using System.Data.Entity;
using BeiDream.Core.Domain.Uow;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Data.Uow
{
    public class EfUnitOfWork : IUnitOfWork 
    {
        private readonly DbContext _dbContext;
        protected EfUnitOfWork(DbContext dbContext)
        {
            TraceId = Guid.NewGuid().ToString();
            _dbContext = dbContext;
        }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; private set; }

        //public void RegisterNew<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        //{
        //    _dbContext.Set<TAggregateRoot>().Add(entity);
        //}

        //public void RegisterDirty<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //}

        //public void RegisterClean<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        //{
        //    _dbContext.Entry(entity).State = EntityState.Unchanged;
        //}

        //public void RegisterDeleted<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        //{
        //    _dbContext.Set<TAggregateRoot>().Remove(entity);
        //}

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        //public void RegisterNew<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>
        //{
        //    _dbContext.Set<TAggregateRoot>().Add(entity);
        //}

        //public void RegisterDirty<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //}

        //public void RegisterClean<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>
        //{
        //    _dbContext.Entry(entity).State = EntityState.Unchanged;
        //}

        //public void RegisterDeleted<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>
        //{
        //    _dbContext.Set<TAggregateRoot>().Remove(entity);
        //}
    }
}