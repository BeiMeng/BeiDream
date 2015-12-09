using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Enums;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Service.Dtos
{
    [AutoMapFrom(typeof(Resource))]
    [AutoMapTo(typeof(Resource))]
    public class ResourceDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public int? SortId { get; set; }
        public int Level { get; set; }
        [Required]
        [StringLength(200)]
        public string Uri { get; set; }
        public ResourceType Type { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreationTime { get; set; }
        public byte[] Version { get; set; }
        /// <summary>
        /// 选中（当前资源是否属于选择的角色）
        /// </summary>
        public bool Checked { get; set; }
    }

    public static class ResourceDtoExtension
    {
        /// <summary>
        /// 转换为资源数据传输对象
        /// </summary>
        /// <param name="entity">资源实体</param>
        /// <param name="roleId">角色编号</param>
        public static ResourceDto ToDto(this Resource entity, Guid roleId)
        {
            ResourceDto dto = entity.MapTo<ResourceDto>();
            dto.Checked = entity.Permissions.Any(p => p.RoleId == roleId);
            return dto;
        }
    }
}