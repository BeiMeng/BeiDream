using System;

namespace BeiDream.Core.Domain.Entities
{
    /// <summary>
    /// 标识为泛型的聚合根标志接口(实现此接口的类说明为聚合根实体,通常为数据库的一个表，直接从数据库获取数据)
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        byte[] Version { get; set; }
    }

    /// <summary>
    /// 标识为Guid的聚合根标志接口(实现此接口的类说明为聚合根实体,通常为数据库的一个表，直接从数据库获取数据)
    /// </summary>
    public interface IAggregateRoot : IEntity<Guid>
    {
        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        byte[] Version { get; set; }
    }
}