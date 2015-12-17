using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BeiDream.Data.Ef.Repositories
{
    public abstract class Repository<TAggregateRoot> : Repository<TAggregateRoot, Guid>
        where TAggregateRoot : class, IAggregateRoot<Guid>
    {
        protected Repository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }

    public abstract class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey> where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        protected IDbContext DbContext { get; private set; }

        protected Repository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private DbSet<TAggregateRoot> Set
        {
            get { return DbContext.Set<TAggregateRoot>(); }
        }

        public void Add(TAggregateRoot entity)
        {
            Set.Add(entity);
        }

        public void Update(TAggregateRoot entity)
        {
            AttachIfNot(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TAggregateRoot entity)
        {
            Set.Remove(entity);
        }
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Delete(IEnumerable<TAggregateRoot> entities)
        {
            if (entities == null)
                return;
            var list = entities.ToList();
            if (!list.Any())
                return;
            Set.RemoveRange(list);
        }
        public void Delete(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            var entities = Set.Where(predicate);
            Delete(entities);
        }

        public TAggregateRoot Find(TKey id)
        {
            return Set.Find(id);
        }

        public IQueryable<TAggregateRoot> GetAll()
        {
            return Set;
        }

        protected virtual void AttachIfNot(TAggregateRoot entity)
        {
            if (!Set.Local.Contains(entity))
            {
                Set.Attach(entity);
            }
        }
    }
}