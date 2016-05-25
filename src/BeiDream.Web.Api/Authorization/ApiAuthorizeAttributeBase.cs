using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using BeiDream.Core.Dependency;
using BeiDream.Core.Security.Authorization;
using BeiDream.Utils.Logging;

namespace BeiDream.Web.Api.Authorization
{
    public abstract class ApiAuthorizeAttributeBase : AuthorizeAttribute
    {
        readonly ILogger _logger = LogManager.GetLogger(typeof(ApiAuthorizeAttributeBase));
        public string Permission { get; set; }

        protected ApiAuthorizeAttributeBase(string permission)
        {
            Permission = permission;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!base.IsAuthorized(actionContext))
            {
                throw new Exception("您没有访问权限！");
            }
            try
            {
                IPermissionManager permissionManager = CreatePermissionManager();
                if (permissionManager.HasPermission(Permission))
                {
                    return true;
                }
                else
                {
                    throw new Exception("您没有访问权限！");
                }
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.ToString(), ex);
                return false;
            }
        }
        /// <summary>
        /// 创建权限管理器
        /// </summary>
        protected abstract IPermissionManager CreatePermissionManager();
    }
}