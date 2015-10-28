using System;
using System.Collections.Generic;
using System.Data.Entity;
using BeiDream.Demo.Domain.Model;

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
            //var adminPermission = new Permission
            //{
            //    Privilege = Privilege.SystemAdministration,
            //    Value = PermissionValue.Allow
            //};

            //var administrators = new Role
            //{
            //    Name = "系统管理员",
            //    Description = "执行系统管理任务的一组账户",
            //    Permissions = new List<Permission> {adminPermission}
            //};

            var administrator = new User
            {
                Id=Guid.NewGuid(),
                DateCreated = DateTime.UtcNow,
                DisplayName = "管理员",
                Email = "admin@easymemo.com",
                Name = "admin",
                Password = "admin"
            };

            context.Users.Add(administrator);

            base.Seed(context);
        }
    }
}
