using System;

namespace BeiDream.Core.Domain.Entities
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    [Serializable]
    public abstract class Entity : Entity<Guid>
    {
        
    }
}