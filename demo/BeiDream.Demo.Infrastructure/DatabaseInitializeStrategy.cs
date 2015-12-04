using BeiDream.Demo.Domain.Model;
using System;
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
            for (int i = 0; i < 5; i++)
            {
                var role = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "系统管理员" + i,
                    Description = "执行系统管理任务的一组账户" + i,
                    IsAdmin = true,
                    Enabled = true
                };
                context.Roles.Add(role);
            }
            for (int i = 0; i < 5; i++)
            {
                var resource = new Resource
                {
                    Id = Guid.NewGuid(),
                    ApplicationId = null,
                    ParentId = null,
                    Path = "aaaa",
                    Level = 1,
                    SortId = null,
                    Uri = "ffff",
                    Name = "gggggg",
                    Type = ResourceType.Module,
                    Enabled = true                    
                };
                context.Resources.Add(resource);
            }
            for (int i = 0; i < 5; i++)
            {
                var administrator = new User
                {
                    Id = Guid.NewGuid(),
                    DisplayName = "管理员" + i,
                    Email = "admin@easymemo.com",
                    Name = "admin" + i,
                    Enabled = true,
                    Password = "admin" + i
                };
                context.Users.Add(administrator);
            }
            base.Seed(context);
        }
    }
}