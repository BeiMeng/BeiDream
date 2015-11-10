using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Repositories;
using System;
using System.Data.Entity;
using System.Linq;

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