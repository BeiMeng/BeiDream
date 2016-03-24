using BeiDream.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using BeiDream.Demo.Domain.Enums;

namespace BeiDream.Demo.Infrastructure
{
    /// <summary>
    /// 数据库初始化策略
    ///1.MigrateDatabaseToLatestVersion：使用Code First数据库迁移策略，将数据库更新到最新版本
    ///2.NullDatabaseInitializer：一个什么都不干的数据库初始化器
    ///3.CreateDatabaseIfNotExists：顾名思义，如果数据库不存在则新建数据库
    ///4.DropCreateDatabaseAlways：无论数据库是否存在，始终重建数据库
    ///5.DropCreateDatabaseIfModelChanges：仅当领域模型发生变化时才重建数据库
    /// </summary>
    public class DatabaseInitializeStrategy
        : DropCreateDatabaseIfModelChanges<DemoDbContext>
    {
        protected override void Seed(DemoDbContext context)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = "超级管理员",
                Description = "超级管理员角色，具有所有权限",
                IsAdmin = true,
                Enabled = true
            };
            var defaultRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "普通管理员",
                Description = "普通管理员角色，初始化不具有任何权限",
                IsAdmin = false,
                Enabled = true,
                IsDeleted=true
            };
            context.Roles.Add(role);
            context.Roles.Add(defaultRole);
            var administrator = new User
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                DisplayName = "超级管理员",
                Email = "331341164@qq.com",
                Enabled = true,
                Password = "admin",
            };
            var defaultUser = new User
            {
                Id = Guid.NewGuid(),
                Name = "defaultUser",
                DisplayName = "普通用户",
                Email = "331341164@qq.com",
                Enabled = true,
                Password = "admin",
                IsDeleted=true
            };
            administrator.Roles.Add(role);
            context.Users.Add(administrator);
            context.Users.Add(defaultUser);

            Guid moduleId = Guid.NewGuid();
            var resourceModule = new Resource
            {
                Id = moduleId,
                Name = "系统模块",
                ApplicationId=null,
                ParentId=null,
                Path = moduleId + ",",
                Level=1,
                SortId=1,
                Uri="xtgl",
                Type=ResourceType.Module,
                Enabled=true
            };
            #region 资源管理菜单初始化
            Guid menuId = Guid.NewGuid();
            var resourceMenu = new Resource
            {
                Id = menuId,
                Name = "资源管理",
                ApplicationId = null,
                ParentId = moduleId,
                Path = moduleId + "," + menuId + ",",
                Level = 2,
                SortId = 1,
                Uri = "/Systems/Resource",
                Type = ResourceType.Menu,
                Enabled = true
            };
            Guid resourceAddId = Guid.NewGuid();
            var resourceAdd = new Resource
            {
                Id = resourceAddId,
                Name = "新增资源",
                ApplicationId = null,
                ParentId = menuId,
                Path = moduleId + "," + menuId + "," + resourceAddId + ",",
                Level = 3,
                SortId = 1,
                Uri = "/Systems/Resource/Add",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid resourceEditId = Guid.NewGuid();
            var resourceEdit = new Resource
            {
                Id = resourceEditId,
                Name = "修改资源",
                ApplicationId = null,
                ParentId = menuId,
                Path = moduleId + "," + menuId + "," + resourceEditId + ",",
                Level = 3,
                SortId = 2,
                Uri = "/Systems/Resource/Edit",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid resourceDelId = Guid.NewGuid();
            var resourceDel = new Resource
            {
                Id = resourceDelId,
                Name = "删除资源",
                ApplicationId = null,
                ParentId = menuId,
                Path = moduleId + "," + menuId + "," + resourceDelId + ",",
                Level = 3,
                SortId = 3,
                Uri = "/Systems/Resource/Delete",
                Type = ResourceType.Operation,
                Enabled = true
            }; 
            #endregion
            #region 角色管理菜单初始化
            Guid rolemenuId = Guid.NewGuid();
            var roleMenu = new Resource
            {
                Id = rolemenuId,
                Name = "角色管理",
                ApplicationId = null,
                ParentId = moduleId,
                Path = moduleId + "," + rolemenuId + ",",
                Level = 2,
                SortId = 2,
                Uri = "/Systems/Role",
                Type = ResourceType.Menu,
                Enabled = true
            };
            Guid roleAddId = Guid.NewGuid();
            var roleAdd = new Resource
            {
                Id = roleAddId,
                Name = "新增角色",
                ApplicationId = null,
                ParentId = rolemenuId,
                Path = moduleId + "," + rolemenuId + "," + roleAddId + ",",
                Level = 3,
                SortId = 1,
                Uri = "/Systems/Role/Add",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid roleEditId = Guid.NewGuid();
            var roleEdit = new Resource
            {
                Id = roleEditId,
                Name = "修改角色",
                ApplicationId = null,
                ParentId = rolemenuId,
                Path = moduleId + "," + rolemenuId + "," + roleEditId + ",",
                Level = 3,
                SortId = 2,
                Uri = "/Systems/Role/Edit",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid roleDelId = Guid.NewGuid();
            var roleDel = new Resource
            {
                Id = roleDelId,
                Name = "删除角色",
                ApplicationId = null,
                ParentId = rolemenuId,
                Path = moduleId + "," + rolemenuId + "," + roleDelId + ",",
                Level = 3,
                SortId = 3,
                Uri = "/Systems/Role/Delete",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid roleSetResourceId = Guid.NewGuid();
            var roleSetResource = new Resource
            {
                Id = roleSetResourceId,
                Name = "设置权限",
                ApplicationId = null,
                ParentId = rolemenuId,
                Path = moduleId + "," + rolemenuId + "," + roleSetResourceId + ",",
                Level = 3,
                SortId = 4,
                Uri = "/Systems/Role/EditResources",
                Type = ResourceType.Operation,
                Enabled = true
            }; 
            #endregion
            #region 用户管理菜单初始化
            Guid usermenuId = Guid.NewGuid();
            var userMenu = new Resource
            {
                Id = usermenuId,
                Name = "用户管理",
                ApplicationId = null,
                ParentId = moduleId,
                Path = moduleId + "," + usermenuId + ",",
                Level = 2,
                SortId = 3,
                Uri = "/Systems/User",
                Type = ResourceType.Menu,
                Enabled = true
            };
            Guid userAddId = Guid.NewGuid();
            var userAdd = new Resource
            {
                Id = userAddId,
                Name = "新增用户",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + userAddId + ",",
                Level = 3,
                SortId = 1,
                Uri = "/Systems/User/Add",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid userEditId = Guid.NewGuid();
            var userEdit = new Resource
            {
                Id = userEditId,
                Name = "修改用户",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + roleEditId + ",",
                Level = 3,
                SortId = 2,
                Uri = "/Systems/User/Edit",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid userDelId = Guid.NewGuid();
            var userDel = new Resource
            {
                Id = userDelId,
                Name = "删除用户",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + userDelId + ",",
                Level = 3,
                SortId = 3,
                Uri = "/Systems/User/Delete",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid userSetRoleId = Guid.NewGuid();
            var userSetRole = new Resource
            {
                Id = userSetRoleId,
                Name = "设置角色",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + userSetRoleId + ",",
                Level = 3,
                SortId = 4,
                Uri = "/Systems/User/EditRoles",
                Type = ResourceType.Operation,
                Enabled = true
            };
            Guid lookSelfCreateUsers = Guid.NewGuid();
            var lookSelfCreateUsersResource = new Resource
            {
                Id = lookSelfCreateUsers,
                Name = "只能查看当前登录用户自己创建的用户数据",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + lookSelfCreateUsers + ",",
                Level = 3,
                SortId = 5,
                Uri = "LookSelfCreateUsers",
                Type = ResourceType.Record,
                Enabled = true
            };
            Guid lookSelfModifyUsers = Guid.NewGuid();
            var lookSelfModifyUsersResource = new Resource
            {
                Id = lookSelfModifyUsers,
                Name = "只能查看当前登录用户自己修改的用户数据",
                ApplicationId = null,
                ParentId = usermenuId,
                Path = moduleId + "," + usermenuId + "," + lookSelfModifyUsers + ",",
                Level = 3,
                SortId = 6,
                Uri = "LookSelfModifyUsers",
                Type = ResourceType.Record,
                Enabled = true
            };
            #endregion
            context.Resources.Add(resourceModule);
            context.Resources.Add(resourceMenu);
            context.Resources.Add(resourceAdd);
            context.Resources.Add(resourceEdit);
            context.Resources.Add(resourceDel);
            context.Resources.Add(roleMenu);
            context.Resources.Add(roleAdd);
            context.Resources.Add(roleEdit);
            context.Resources.Add(roleDel);
            context.Resources.Add(roleSetResource);
            context.Resources.Add(userMenu);
            context.Resources.Add(userAdd);
            context.Resources.Add(userEdit);
            context.Resources.Add(userDel);
            context.Resources.Add(userSetRole);
            context.Resources.Add(lookSelfCreateUsersResource);
            context.Resources.Add(lookSelfModifyUsersResource);
            base.Seed(context);
        }
    }
}