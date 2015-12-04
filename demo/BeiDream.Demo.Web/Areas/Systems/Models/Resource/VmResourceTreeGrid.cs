using System;
using System.Collections.Generic;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Enums;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Web.Mvc.EasyUi;

namespace BeiDream.Demo.Web.Areas.Systems.Models.Resource
{
    [AutoMapFrom(typeof(ResourceDto))]
    public class VmResourceTreeGrid : EeasyUiTreeNode
    {
        public string Name { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 资源标示
        /// </summary>
        public string Uri { get; set; }

        public bool Enabled { get; set; }
        public DateTime CreationTime { get; set; }

    }
}