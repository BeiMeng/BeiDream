using BeiDream.Demo.Infrastructure;
using System.Data.Entity;

namespace BeiDream.Demo.Web
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DatabaseInitializeStrategy());
            new DemoDbContext().Database.Initialize(true);
        }
    }
}