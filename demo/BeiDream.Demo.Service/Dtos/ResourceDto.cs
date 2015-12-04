using System;
using System.ComponentModel.DataAnnotations;
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
    }
}