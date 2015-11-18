using System.Collections.Generic;
using BeiDream.Core.Security.Authorization;

namespace BeiDream.Demo.Service.Security.Authorization
{
    public class PermissionSupportService : IPermissionSupportService
    {
        /// <summary>
        /// 检测该用户是否属于当前应用程序
        /// </summary>
        /// <param name="userId">用户编号</param>
        public bool IsInApplication(string userId)
        {
            return true;
        }
        /// <summary>
        /// 检测该用户是否属于当前租户
        /// </summary>
        /// <param name="userId">用户编号</param>
        public bool IsInTenant(string userId)
        {
            return true;
        }
        /// <summary>
        /// 获取资源的权限列表
        /// </summary>
        /// <param name="resourceUri">资源标识</param>
        public ResourcePermissions GetPermissionsByResource(string resourceUri)
        {
            return new ResourcePermissions(resourceUri, GetMockPermissions(resourceUri));
        }
        /// <summary>
        /// 获取模拟权限列表,实际项目是从数据库权限表里，根据资源id获取此资源的所有的角色集合(权限列表)
        /// </summary>
        /// <param name="resourceUri">当前请求资源</param>
        /// <returns></returns>
        private List<Permission> GetMockPermissions(string resourceUri)
        {
            List<Permission> permissions=new List<Permission>();
            //todo 先从缓存里获取，缓存没有就从数据库获取，在存入缓存中
            if (resourceUri == "/Home/Test")
            {
                permissions.Add(new Permission("R1",false));
                permissions.Add(new Permission("R2", false));
            }
            if (resourceUri == "/Home/Test2")
            {
                permissions.Add(new Permission("R3", false));
                permissions.Add(new Permission("R4", false));
            }
            return permissions;
        }
    }
}