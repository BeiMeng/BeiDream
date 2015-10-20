using System.Data.Entity;
using BeiDream.Demo.Infrastructure;

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