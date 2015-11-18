namespace BeiDream.Core.Security.Authorization
{
    public interface IPermissionSupportService
    {
        /// <summary>
        /// 检测该用户是否属于当前应用程序,单应用程序直接返回true
        /// </summary>
        /// <param name="userId">用户编号</param>
        bool IsInApplication(string userId);
        /// <summary>
        /// 检测该用户是否属于当前租户,单租户，直接返回true
        /// </summary>
        /// <param name="userId">用户编号</param>
        bool IsInTenant(string userId);
        /// <summary>
        /// 获取资源的权限列表
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        ResourcePermissions GetPermissionsByResource(string resourceUri);
    }
}