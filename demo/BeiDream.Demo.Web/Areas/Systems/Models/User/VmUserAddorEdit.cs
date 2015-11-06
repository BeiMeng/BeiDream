using System;
using System.ComponentModel.DataAnnotations;
using BeiDream.Demo.Service.Dtos;

namespace BeiDream.Demo.Web.Areas.Systems.Models.User
{
    public class VmUserAddorEdit
    {
        public VmUserAddorEdit()
        {
        }
        public VmUserAddorEdit(Guid id)
        {
            Id = id;
        }

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
        public string DisplayName
        {
            get;
            set;
        }
        [Required(ErrorMessage = "启用不能为空")]
        public bool? Enabled { get; set; }
        public byte[] Version { get; set; }
    }

    public static class VmUserAddorEditExtension
    {
        public static UserDto ToDto(this VmUserAddorEdit vm)
        {
            return new UserDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Password = vm.Password,
                DisplayName = vm.DisplayName,
                Email = vm.Email,
                Enabled = vm.Enabled,
                Version = vm.Version
            };
        }
        public static VmUserAddorEdit ToFormVm(this UserDto dto)
        {
            return new VmUserAddorEdit(dto.Id)
            {
                Id = dto.Id,
                Name = dto.Name,
                Password = dto.Password,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                Version = dto.Version
            };
        }
    }
}