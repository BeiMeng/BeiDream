using System;
using System.Collections.Generic;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Enums;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.Extensions;
using BeiDream.Web.Mvc.EasyUi;
using BeiDream.Web.Mvc.EasyUi.Tree;

namespace BeiDream.Demo.Web.Areas.Systems.Models.Resource
{
    [AutoMapFrom(typeof(ResourceDto))]
    public class VmResourceTreeGrid : EeasyUiTreeNode
    {
        /// <summary>
        /// 资源类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 资源标示
        /// </summary>
        public string Uri { get; set; }

        public bool Enabled { get; set; }
        public string CreationTime { get; set; }
        /// <summary>
        /// 选中（当前资源是否属于选择的角色）
        /// </summary>
        public bool Checked { get; set; }

    }

    public static class VmResourceTreeGridExtension
    {
        public static VmResourceTreeGrid ToTreeGridVm(this ResourceDto dto)
        {
            VmResourceTreeGrid vmRoleGrid = dto.MapTo<VmResourceTreeGrid>();
            vmRoleGrid.Type = dto.Type.ToString();
            vmRoleGrid.CreationTime = dto.CreationTime.ToChineseDateTimeString();
            return vmRoleGrid;
        }
    }
}