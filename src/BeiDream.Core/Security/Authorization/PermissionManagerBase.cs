using BeiDream.Utils.Extensions;

namespace BeiDream.Core.Security.Authorization
{
    public abstract class PermissionManagerBase:IPermissionManager
    {
        /// <summary>
        /// 初始化权限管理器
        /// </summary>
        /// <param name="permissionSupportService">权限支持服务</param>
        /// <param name="ignore">是否忽视角色检查</param>
        protected PermissionManagerBase(IPermissionSupportService permissionSupportService, bool ignore)
        {
            permissionSupportService.CheckNotNull("permissionSupportService");
            _permissionSupportService = permissionSupportService;
            _ignore = ignore;
        }
        /// <summary>
        /// 应用程序上下文
        /// </summary>
        private IApplicationSession _applicationSession;
        /// <summary>
        /// 权限支持服务
        /// </summary>
        private readonly IPermissionSupportService _permissionSupportService;
        /// <summary>
        /// 是否忽视角色检查
        /// </summary>
        private readonly bool _ignore;

        /// <summary>
        /// 检查当前用户是否具有该资源的权限
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        public bool HasPermission(string resourceUri)
        {
            Init();
            resourceUri = GetResourceUri(resourceUri);
            if (string.IsNullOrWhiteSpace(resourceUri))
                return false;
            //验证是否已登录
            if (!_applicationSession.IsAuthenticated)
                return false;
            if (!ValidateApplication())
                return false;
            if (!ValidateTenant())
                return false;
            if (_ignore)
                return true;
            if (ValidateIsAdmin())
                return true;
            if (!ValidateRoles(resourceUri))
                return false;
            return true;
        }
         //<summary>
         //验证用户角色是否被授权访问该资源
         //</summary>
        private bool ValidateRoles(string resourceUri)
        {
            var permissions = _permissionSupportService.GetPermissionsByResource(resourceUri);
            if (permissions == null)
                return false;
            var result = permissions.HasPermission(_applicationSession.RoleIds);
            return result;
        }
        /// <summary>
        /// 验证用户是否属于当前应用程序
        /// </summary>
        private bool ValidateApplication()
        {
            var result = _permissionSupportService.IsInApplication(GetName());
            return result;
        }

        /// <summary>
        /// 获取用户编号
        /// </summary>
        private string GetName()
        {
            return _applicationSession.Name;
        }

        /// <summary>
        /// 验证用户是否属于当前租户
        /// </summary>
        private bool ValidateTenant()
        {
            var result = _permissionSupportService.IsInTenant(GetName());
            return result;
        }
        /// <summary>
        /// 验证是否超级管理员
        /// </summary>
        private bool ValidateIsAdmin()
        {
            return _applicationSession.IsAdmin;
        }
        /// <summary>
        /// 初始化组件
        /// </summary>
        private void Init()
        {
            _applicationSession = GetApplicationContext();
        }

        /// <summary>
        /// 获取应用程序上下文
        /// </summary>
        protected virtual IApplicationSession GetApplicationContext()
        {
            return _applicationSession ?? (_applicationSession = ApplicationSession.Current);
        }
        /// <summary>
        /// 获取资源标识，如果传入的资源标识为空值，由子类重现该方法提供默认值，WEB环境可重写该方法提供当前请求的Url
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        protected virtual string GetResourceUri(string resourceUri)
        {
            return resourceUri;
        }
    }
}