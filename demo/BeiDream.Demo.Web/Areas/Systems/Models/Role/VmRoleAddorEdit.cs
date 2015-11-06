using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Demo.Service.Dtos;

namespace BeiDream.Demo.Web.Areas.Systems.Models.Role
{
    public class VmRoleAddorEdit
    {
        public VmRoleAddorEdit()
        {
        }

        public VmRoleAddorEdit(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "角色名不能为空")]
        [StringLength(16, ErrorMessage = "角色名输入过长，不能超过16位")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "角色描述不能为空")]
        [StringLength(50, ErrorMessage = "角色描述输入过长，不能超过50位")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        public bool Enabled { get; set; }

        public byte[] Version { get; set; }
    }

    public static class VmRoleAddorEditExtension
    {
        public static RoleDto ToDto( this VmRoleAddorEdit vm)
        {
            return new RoleDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                IsAdmin = vm.IsAdmin,
                Enabled = vm.Enabled,
                Version = vm.Version
            };
        }
        public static VmRoleAddorEdit ToFormVm(this RoleDto dto)
        {
            return new VmRoleAddorEdit(dto.Id)
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsAdmin = dto.IsAdmin,
                Enabled = dto.Enabled,
                Version = dto.Version
            };
        }
    }
}