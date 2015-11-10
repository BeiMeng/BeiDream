using System;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Core.Domain.Entities
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
    {
        /// <summary>
        /// 版本号(乐观锁)
        /// </summary>
        [Timestamp]
        public byte[] Version { get; set; }
    }

    public class AggregateRoot : AggregateRoot<Guid>
    {
    }
}