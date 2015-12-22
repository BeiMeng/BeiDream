using BeiDream.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities.Auditing;

namespace BeiDream.Demo.Domain.Model
{
    public class User : AggregateRoot, IAudited
    {
        public User()
        {
            Roles=new List<Role>();
        }

        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(16, ErrorMessage = "用户名输入过长，不能超过16位")]
        public string Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(8, ErrorMessage = "密码输入过长，不能超过8位")]
        public string Password
        {
            get;
            set;
        }

        [StringLength(20, ErrorMessage = "邮箱输入过长，不能超过20位")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "昵称不能为空")]
        [StringLength(8, ErrorMessage = "昵称输入过长，不能超过8位")]
        public string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        public DateTime? DateLastLogon
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




        #region ValidateDisabled(验证用户被冻结)

        /// <summary>
        /// 验证用户被冻结
        /// </summary>
        public void ValidateDisabled()
        {
            if (Enabled == false)
                throw new Exception("当前用户已被冻结，请联系管理员！");
        }

        #endregion
        #region ValidatePassword(验证密码)

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="password">密码,加密前的明文</param>
        public void ValidatePassword(string password)
        {
            if (Password.ToLower() != password.ToLower())
                throw new Exception("密码错误！");
        }

        #endregion
        #region UpdateLoginSuccess(更新登录成功)

        /// <summary>
        /// 更新登录成功
        /// </summary>
        public void UpdateLoginSuccess()
        {
            DateLastLogon = DateTime.Now;
        }

        #endregion
    }
}