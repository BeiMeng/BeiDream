using BeiDream.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities.Auditing;

namespace BeiDream.Demo.Domain.Model
{
    public class Role : AggregateRoot, IAudited, ISoftDelete
    {
        [Required(ErrorMessage = "角色名不能为空")]
        [StringLength(16, ErrorMessage = "角色名输入过长，不能超过16位")]
        public virtual string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "角色描述不能为空")]
        [StringLength(50, ErrorMessage = "角色描述输入过长，不能超过50位")]
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        public virtual ICollection<User> Users
        {
            get;
            set;
        }
        public virtual ICollection<Permission> Permissions { get; set; }
        [StringLength(50)]
        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        [StringLength(50)]
        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}