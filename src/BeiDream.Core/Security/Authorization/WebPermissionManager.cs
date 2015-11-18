using System.Web;

namespace BeiDream.Core.Security.Authorization
{
    /// <summary>
    /// Web权限管理器
    /// </summary>
    public class WebPermissionManager : PermissionManagerBase
    {
        /// <summary>
        /// 初始化Web权限管理器
        /// </summary>
        /// <param name="permissionSupportService">权限支持服务</param>
        /// <param name="ignore">是否忽视权限</param>
        public WebPermissionManager(IPermissionSupportService permissionSupportService, bool ignore)
            : base(permissionSupportService, ignore)
        {
        }

        /// <summary>
        /// 获取资源标识
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        protected override string GetResourceUri(string resourceUri)
        {
            if (!string.IsNullOrWhiteSpace(resourceUri))
                return resourceUri;
            return HttpContext.Current.Request.Path;
        }
    }
}