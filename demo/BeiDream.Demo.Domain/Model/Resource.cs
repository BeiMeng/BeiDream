using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Entities.Auditing;
using BeiDream.Demo.Domain.Enums;

namespace BeiDream.Demo.Domain.Model
{
    public class Resource : AggregateRoot, IAudited
    {
        /// <summary>
        /// 应用程序编号，为null，则是单应用程序
        /// </summary>
        public Guid? ApplicationId { get; set; }

        public Guid? ParentId { get; set; }

        [Required]
        [StringLength(800)]
        public string Path { get; set; }

        public int Level { get; set; }
        public int? SortId { get; set; }

        [Required]
        [StringLength(200)]
        public string Uri { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public ResourceType Type { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        [StringLength(50)]
        public string CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        [StringLength(50)]
        public string LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }


        #region 充血模型方法体

        /// <summary>
        /// 修正树形数据的物理路径和层级
        /// </summary>
        /// <param name="parent"></param>
        public void FixPathAndLevel(Resource parent)
        {
            if (Equals(parent, null))
            {
                Level = 1;
                Path = Id.ToString() + ",";
                return;
            }
            Level = parent.Level + 1;
            Path = string.Format("{0}{1},", parent.Path, Id);
        } 
        #endregion
    }
}