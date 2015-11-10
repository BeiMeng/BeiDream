using System;

namespace BeiDream.Core.Domain.Entities
{
    /// <summary>
    /// 标识为泛型的实体标志接口(实现此接口的为领域实体，通常为数据库的一个表。直接实现这个接口的，不是聚合根，最佳实践是直接从数据库获取其数据，而应通过聚合根获取)
    /// </summary>
    /// <typeparam name="TKey">泛型的标识(通常为数据库表的主键)</typeparam>
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    /// <summary>
    /// 标识为guid的实体标志接口(实现此接口的为领域实体，通常为数据库的一个表。直接实现这个接口的，不是聚合根，最佳实践是直接从数据库获取其数据，而应通过聚合根获取)
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {
    }
}