using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BeiDream.Core.Dependency;
using BeiDream.Core.Security.Authorization;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Utils.Extensions;

namespace BeiDream.Demo.Infrastructure.Security.Authorization
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
            return new ResourcePermissions(resourceUri, GetPermissions(resourceUri));
        }
        /// <summary>
        /// 从数据库权限表里，根据资源id获取此资源的所有的角色集合(权限列表)
        /// </summary>
        /// <param name="resourceUri">当前请求资源</param>
        /// <returns></returns>
        private List<Permission> GetPermissions(string resourceUri)
        {
            //todo 先从缓存里获取，缓存没有就从数据库获取，在存入缓存中
            var resourceRepository = IocManager.Instance.Resolve<IResourceRepository>();
            var resource = resourceRepository.GetAll().Include(p => p.Permissions).SingleOrDefault(p=>p.Uri==resourceUri);
            if(resource==null)
                //throw new Exception("请求的资源未添加到数据库，请联系管理员！");
                return new List<Permission>();
            var listPermissions = resource.Permissions.Where(p => p.Enabled);
            return listPermissions.Select(item => new Permission(item.RoleId.ToString(), item.IsDeny)).ToList();

            //if (resourceUri == "/Systems/User" || resourceUri == "/Systems/User/Query")
            //{
            //    permissions.Add(new Permission("R1",false));
            //    permissions.Add(new Permission("R2", false));
            //}
            //if (resourceUri == "/Systems/Role" || resourceUri == "/Systems/Role/Query")
            //{
            //    permissions.Add(new Permission("R3", false));
            //    permissions.Add(new Permission("R4", false));
            //}
        }
    }
}