using System;

namespace BeiDream.Core.Domain.Entities.Auditing {
    /// <summary>
    /// 修改操作审计
    /// </summary>
    public interface IModificationAudited {
        /// <summary>
        /// 修改人Id
        /// </summary>
        string LastModifierUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}
