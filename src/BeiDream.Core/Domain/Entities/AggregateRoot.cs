using System;

namespace BeiDream.Core.Domain.Entities
{
    public class AggregateRoot<TKey> : IAggregateRoot<TKey>
    {
        public virtual TKey Id { get; set; }

        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        public byte[] Version { get; set; }
    }
    public class AggregateRoot : AggregateRoot<Guid>
    {

    }
}