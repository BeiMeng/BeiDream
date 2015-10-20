using System;
using System.Linq;
using System.Linq.Expressions;
using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Entities;
namespace BeiDream.Core.Domain.Repositories
{
    public interface IRepository<TAggregateRoot,TKey>: ITransientDependency where TAggregateRoot : class,IAggregateRoot<TKey> 
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);

        void Delete(TAggregateRoot entity);

        IQueryable<TAggregateRoot> GetAll();
    }
    public interface IRepository<TAggregateRoot>: IRepository<TAggregateRoot,Guid> where TAggregateRoot : class,IAggregateRoot<Guid>
    {

    }
}