using System;
using BeiDream.Core.Security.Authorization;
using BeiDream.Demo.Infrastructure.Security.Authorization;
using BeiDream.Web.Mvc.Filter;

namespace BeiDream.Demo.Web.Security.Authorization
{
    /// <summary>
    /// 基于角色授权验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RoleAuthorizeAttribute : AuthorizeAttributeBase
    {
        /// <summary>
        /// 初始化角色授权
        /// </summary>
        /// <param name="ignore">忽视角色检查，但仍然验证登录，如果需要完全忽视权限，应使用[AllowAnonymous]特性</param>
        public RoleAuthorizeAttribute(bool ignore = false)
        {
            Ignore = ignore;
        }
        /// <summary>
        /// 创建权限管理器
        /// </summary>
        /// <returns>权限管理器</returns>
        protected override IPermissionManager CreatePermissionManager()
        {
            return new WebPermissionManager(new PermissionSupportService(), Ignore);
        }
    }
}