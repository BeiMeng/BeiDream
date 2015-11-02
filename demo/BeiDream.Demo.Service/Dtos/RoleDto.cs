using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Validations;

namespace BeiDream.Demo.Service.Dtos
{
    public class RoleDto//:IValidate
    {
        public Guid Id { get; set; }
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
        public virtual string DateCreated
        {
            get;
            set;
        }
        public byte[] Version { get; set; }

        /// <summary>
        /// 选中（当前角色是否属于选择的用户）
        /// </summary>
        public bool Checked { get; set; }
    }
}