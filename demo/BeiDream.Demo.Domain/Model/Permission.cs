using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Entities.Auditing;

namespace BeiDream.Demo.Domain.Model
{
    public class Permission : AggregateRoot, IAudited
    {

        public Guid? ResourceId { get; set; }

        public Guid? RoleId { get; set; }
        /// <summary>
        /// 是否拒绝
        /// </summary>
        public bool IsDeny { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }
        public virtual Resource Resources { get; set; }
        public virtual Role Roles { get; set; }
        [StringLength(50)]
        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        [StringLength(50)]
        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}