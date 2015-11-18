namespace BeiDream.Core.Domain.Entities.Auditing {
    /// <summary>
    /// 操作审计
    /// </summary>
    public interface IAudited : ICreationAudited, IModificationAudited {
    }
}
