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
                return false;
            }
            try
            {
                IPermissionManager permissionManager = CreatePermissionManager();
                return permissionManager.HasPermission(Permission);
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