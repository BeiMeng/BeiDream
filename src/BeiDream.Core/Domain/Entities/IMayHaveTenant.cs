namespace BeiDream.Core.Domain.Entities
{
    /// <summary>
    /// 实现此接口的实体具有可选的租户编号（能够通过当前登录用户的租户编号进行不同的租户数据筛选隔离）
    /// </summary>
    public interface IMayHaveTenant
    {
        /// <summary>
        /// 实体的租户编号
        /// </summary>
        int? TenantId { get; set; }
    }
}