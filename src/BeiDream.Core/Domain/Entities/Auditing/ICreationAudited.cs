using System;

namespace BeiDream.Core.Domain.Entities.Auditing {
    /// <summary>
    /// 创建操作审计
    /// </summary>
    public interface ICreationAudited {
        /// <summary>
        /// 创建人ID
        /// </summary>
        string CreatorUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
