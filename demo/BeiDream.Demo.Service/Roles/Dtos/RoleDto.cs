using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Service.Roles.Dtos
{
    [AutoMapFrom(typeof(Role))]
    [AutoMapTo(typeof(Role))]
    public class RoleDto //:IValidate
    {
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

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        public virtual DateTime CreationTime { get; set; }
        public byte[] Version { get; set; }

        /// <summary>
        /// 选中（当前角色是否属于选择的用户）
        /// </summary>
        public bool Checked { get; set; }
    }

    public static class RoleDtoExtension
    {
        //public static RoleDto ToDto(this Role entity)
        //{
        //    return new RoleDto()
        //    {
        //        Id = entity.Id,
        //        Name = entity.Name,
        //        Description = entity.Description,
        //        IsAdmin = entity.IsAdmin,
        //        Enabled = entity.Enabled,
        //        DateCreated = entity.DateCreated.ToChineseDateTimeString(true),
        //        Version = entity.Version
        //    };
        //}

        /// <summary>
        /// 转换为角色数据传输对象
        /// </summary>
        /// <param name="entity">角色实体</param>
        /// <param name="userId">用户编号</param>
        public static RoleDto ToDto(this Role entity, Guid userId)
        {
            RoleDto dto = entity.MapTo<RoleDto>();
            dto.Checked = entity.Users.Select(u => u.Id).Contains(userId);
            return dto;
        }

        //public static Role ToEntity(this RoleDto dto)
        //{
        //    return new Role()
        //    {
        //        Id = dto.Id,
        //        Name = dto.Name,
        //        Description = dto.Description,
        //        IsAdmin = dto.IsAdmin,
        //        Enabled = dto.Enabled,
        //        Version = dto.Version
        //    };
        //}
    }
}