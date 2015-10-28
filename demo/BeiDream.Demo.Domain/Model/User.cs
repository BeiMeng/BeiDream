using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Demo.Domain.Model
{
    public class User : AggregateRoot, ISoftDelete
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

        public virtual DateTime DateCreated
        {
            get;
            set;
        }

        public virtual DateTime? DateLastLogon
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}