namespace BeiDream.Core.Security.Authorization
{
    /// <summary>
    /// 权限管理器
    /// </summary>
    public interface IPermissionManager
    {
        /// <summary>
        /// 检查当前用户是否具有该资源的权限
        /// </summary>
        /// <param name="resourceUri">资源标识，一般为网页地址,范例：/a/b/c</param>
        bool HasPermission(string resourceUri);
    }
}