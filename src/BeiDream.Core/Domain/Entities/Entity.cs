using System;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Core.Domain.Entities
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        [Required]
        [Key]
        public virtual TKey Id { get; set; }
    }

    [Serializable]
    public abstract class Entity : Entity<Guid>
    {
    }
}