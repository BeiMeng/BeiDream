using BeiDream.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Demo.Domain.Model
{
    public class Role : AggregateRoot
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

        public virtual DateTime DateCreated
        {
            get;
            set;
        }

        public virtual DateTime? DateUpdated
        {
            get;
            set;
        }

        public virtual List<User> Users
        {
            get;
            set;
        }
    }
}