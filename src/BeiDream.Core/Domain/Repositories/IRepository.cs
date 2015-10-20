using System;
using System.Linq;
using System.Linq.Expressions;
using BeiDream.Core.Domain.Entities;
namespace BeiDream.Core.Domain.Repositories
{
    public interface IRepository<TAggregateRoot,TKey> where TAggregateRoot : class,IAggregateRoot<TKey>
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);

        void Delete(TAggregateRoot entity);

        IQueryable<TResult> Find<TResult>(Expression<Func<TAggregateRoot, bool>> whereExpr, Expression<Func<TAggregateRoot, TResult>> selectExpr);
    }
    public interface IRepository<TAggregateRoot>: IRepository<TAggregateRoot,Guid> where TAggregateRoot : class,IAggregateRoot<Guid>
    {

    }
}