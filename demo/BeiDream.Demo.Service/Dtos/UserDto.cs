using System;
using System.ComponentModel.DataAnnotations;

namespace BeiDream.Demo.Service.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
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
        public  string DisplayName
        {
            get;
            set;
        }
        public string DateCreated
        {
            get;
            set;
        }
        [Required(ErrorMessage = "启用不能为空")]
        public bool? Enabled { get; set; }
        public byte[] Version { get; set; }
    }
}