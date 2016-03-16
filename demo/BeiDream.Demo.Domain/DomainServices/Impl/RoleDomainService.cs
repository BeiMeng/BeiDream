using System;
using System.Collections.Generic;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Repositories;

namespace BeiDream.Demo.Domain.DomainServices.Impl
{
    public class RoleDomainService : IRoleDomainService
    {
        private readonly IPermissionRepository _permissionRepository;

        /// <summary>
        ///角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }

        public RoleDomainService(IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
            RoleRepository = roleRepository;
        }

        public void SetPermissions(Guid roleId, List<Guid> resourceIds)
        {

            //一对多，一对一，以及多对多具有数据的表（如Permission表）的子对象删除操作,设置外键可为null,子对象删除只清除其关系，子对象数据依然存在，必须自己清除
            var role = RoleRepository.Find(roleId);
            if (role == null)
                throw new Exception("设置角色不存在");
            //先把角色的资源权限信息全删除,只能清除关系，数据无法清除
            //role.Permissions.Clear();
            _permissionRepository.Delete(p => p.RoleId == roleId);

            foreach (var resourceId in resourceIds)
            {
                Permission permission = new Permission
                {
                    Id = Guid.NewGuid(),
                    ResourceId = resourceId,
                    RoleId = roleId,
                    IsDeny = false,
                    Enabled = true
                };
                role.Permissions.Add(permission);
            }
        }
    }
}