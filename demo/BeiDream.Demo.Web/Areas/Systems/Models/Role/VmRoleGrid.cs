using System;
using BeiDream.AutoMapper;
using BeiDream.Demo.Service.Roles.Dtos;
using BeiDream.Utils.Extensions;

namespace BeiDream.Demo.Web.Areas.Systems.Models.Role
{
    [AutoMapFrom(typeof(RoleDto))]
    public class VmRoleGrid
    {
        public Guid Id { get; set; }

        public virtual string Name
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

        public virtual string CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// 选中（当前角色是否属于选择的用户）
        /// </summary>
        public bool Checked { get; set; }
    }

    public static class VmRoleGridExtension
    {
        public static VmRoleGrid ToGridVm(this RoleDto dto)
        {
            //return new VmRoleGrid
            //{
            //    Id = dto.Id,    
            //    Name = dto.Name,
            //    IsAdmin = dto.IsAdmin,
            //    Enabled = dto.Enabled,
            //    DateCreated = dto.DateCreated.ToChineseDateTimeString(),
            //    Checked = dto.Checked
            //};
            VmRoleGrid vmRoleGrid = dto.MapTo<VmRoleGrid>();
            vmRoleGrid.CreationTime = dto.CreationTime.ToChineseDateTimeString();
            return vmRoleGrid;
        }
    }
}