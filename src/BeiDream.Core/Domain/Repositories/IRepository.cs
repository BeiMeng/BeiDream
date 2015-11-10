using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Entities;
using System;
using System.Linq;

namespace BeiDream.Core.Domain.Repositories
{
    public interface IRepository<TAggregateRoot, in TKey> : ITransientDependency where TAggregateRoot : class,IAggregateRoot<TKey>
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);

        void Delete(TAggregateRoot entity);

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        TAggregateRoot Find(TKey id);

        IQueryable<TAggregateRoot> GetAll();
    }

    public interface IRepository<TAggregateRoot> : IRepository<TAggregateRoot, Guid> where TAggregateRoot : class,IAggregateRoot<Guid>
    {
    }
}