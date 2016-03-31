using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BeiDream.Core.Domain.Repositories
{
    public interface IRepository<TAggregateRoot, in TKey> : ITransientDependency where TAggregateRoot : class,IAggregateRoot<TKey>
    {
        void Add(TAggregateRoot entity);

        void Update(TAggregateRoot entity);
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="ignoreSoftDelete">忽略软删除功能(默认不忽略,如果设置为true,即使继承了ISoftDelete接口一样物理删除)</param>
        void Delete(TAggregateRoot entity, bool ignoreSoftDelete=false);

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="ignoreSoftDelete">忽略软删除功能(默认不忽略,如果设置为true,即使继承了ISoftDelete接口一样物理删除)</param>
        void Delete(IEnumerable<TAggregateRoot> entities, bool ignoreSoftDelete = false);
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="predicate">删掉条件</param>
        /// <param name="ignoreSoftDelete">忽略软删除功能(默认不忽略,如果设置为true,即使继承了ISoftDelete接口一样物理删除)</param>
        void Delete(Expression<Func<TAggregateRoot, bool>> predicate, bool ignoreSoftDelete = false);
        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">实体标识</param>
        TAggregateRoot Find(TKey id);
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<TAggregateRoot> GetAll();

        IQueryable<TAggregateRoot> GetAllAsNoTracking();

        /// <summary>
        /// 获取过滤数据权限的所有数据
        /// </summary>
        /// <returns></returns>
        IQueryable<TAggregateRoot> GetAllFilterDataPermissions();
    }

    public interface IRepository<TAggregateRoot> : IRepository<TAggregateRoot, Guid> where TAggregateRoot : class,IAggregateRoot<Guid>
    {
    }
}