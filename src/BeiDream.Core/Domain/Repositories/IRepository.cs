using System;
using System.Linq;
using System.Linq.Expressions;
using BeiDream.Core.Domain.Entities;
namespace BeiDream.Core.Domain.Repositories
{
    public interface IRepository<TAggregateRoot,in TKey> where TAggregateRoot : class,IAggregateRoot<TKey>
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);

        void Delete(TAggregateRoot entity);

        TAggregateRoot Get(TKey id);

        IQueryable<TResult> Find<TResult>(Expression<Func<TAggregateRoot, bool>> whereExpr, Expression<Func<TAggregateRoot, TResult>> selectExpr);
    }
    public interface IRepository<TAggregateRoot> where TAggregateRoot : class,IAggregateRoot
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);

        void Delete(TAggregateRoot entity);

        TAggregateRoot Get(Guid id);

        IQueryable<TResult> Find<TResult>(Expression<Func<TAggregateRoot, bool>> whereExpr, Expression<Func<TAggregateRoot, TResult>> selectExpr);
    }
}