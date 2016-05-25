using BeiDream.Core.Security.Authorization;

namespace BeiDream.Web.Api.Authorization
{
    public class WebApiPermissionManager : PermissionManagerBase
    {
        public string Permission { get; set; }

        /// <summary>
        /// 初始化Web权限管理器
        /// </summary>
        /// <param name="permissionSupportService">权限支持服务</param>
        /// <param name="permission"></param>
        /// <param name="ignore">是否忽视权限</param>
        public WebApiPermissionManager(IPermissionSupportService permissionSupportService,string permission, bool ignore)
            : base(permissionSupportService, ignore)
        {
            Permission = permission;
        }
        /// <summary>
        /// 获取资源标识
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        protected override string GetResourceUri(string resourceUri)
        {
            return Permission;
        }
    }
}