using System.Collections.Generic;
using System.Linq;
using BeiDream.Utils.Extensions;

namespace BeiDream.Core.Security.Authorization
{
    /// <summary>
    /// 资源权限列表
    /// </summary>
    public class ResourcePermissions
    {
        /// <summary>
        /// 初始化资源权限列表
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        /// <param name="permissions">权限列表</param>
        public ResourcePermissions(string resourceUri, IEnumerable<Permission> permissions)
        {
            ResourceUri = resourceUri;
            Permissions = permissions;
        }

        /// <summary>
        /// 资源标识
        /// </summary>
        public string ResourceUri { get; private set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public IEnumerable<Permission> Permissions { get; private set; }

        /// <summary>
        /// 验证是否具有资源访问权限
        /// </summary>
        /// <param name="roleIds">角色编号列表</param>
        public bool HasPermission(params string[] roleIds)
        {
            if (roleIds == null)
                return false;
            if (Permissions == null)
                return false;
            bool result = false;
            foreach (var permission in Permissions)
            {
                if (roleIds.Any(roleId => permission.HasPermission(roleId) == false))
                    return false;
                if (roleIds.Any(roleId => permission.HasPermission(roleId) == true))
                    result = true;
            }
            return result;
        }
    }
}