using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Repositories;
using BeiDream.Core.Domain.Uow;

namespace BeiDream.Data.Repositories
{
    public abstract class Repository<TAggregateRoot> : Repository<TAggregateRoot,Guid>
        where TAggregateRoot : class, IAggregateRoot<Guid>
    {
        protected Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    public abstract class Repository<TAggregateRoot,  TKey> : IRepository<TAggregateRoot,TKey> where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        private readonly DbContext _dbContext;
        protected Repository(DbContext dbContext)
        {
            _dbContext = _dbContext;
        }
        private DbSet<TAggregateRoot> Set
        {
            get { return _dbContext.Set<TAggregateRoot>(); }
        }
        public void Add(TAggregateRoot entity)
        {
            Set.Add(entity);
        }

        public void Update(TAggregateRoot entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TAggregateRoot entity)
        {
            UnitOfWork.RegisterDeleted<TAggregateRoot, TKey>(entity);
        }

        public TAggregateRoot Get(TKey id)
        {
            return UnitOfWork.Entities<TAggregateRoot, TKey>().FirstOrDefault(t => t. == id);
        }

        public IQueryable<TResult> Find<TResult>(Expression<Func<TAggregateRoot, bool>> whereExpr, Expression<Func<TAggregateRoot, TResult>> selectExpr)
        {
            throw new NotImplementedException();
        }
    }
}