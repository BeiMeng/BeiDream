using BeiDream.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities.Auditing;

namespace BeiDream.Demo.Domain.Model
{
    public class User : AggregateRoot, IAudited
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(16, ErrorMessage = "用户名输入过长，不能超过16位")]
        public virtual string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(8, ErrorMessage = "密码输入过长，不能超过8位")]
        public virtual string Password
        {
            get;
            set;
        }

        [StringLength(20, ErrorMessage = "邮箱输入过长，不能超过20位")]
        public virtual string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(8, ErrorMessage = "昵称输入过长，不能超过8位")]
        public virtual string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        public virtual DateTime? DateLastLogon
        {
            get;
            set;
        }
        public virtual ICollection<Role> Roles
        {
            get;
            set;
        }
        [StringLength(50)]
        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        [StringLength(50)]
        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}