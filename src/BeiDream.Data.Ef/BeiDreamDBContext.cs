using BeiDream.Core.Domain.Entities;
using BeiDream.Data.Ef.Datas;
using BeiDream.Data.Ef.EntityFramework.DynamicFilters;
using BeiDream.Utils.Logging;
using System;
using System.Data.Entity;

namespace BeiDream.Data.Ef
{
    public class BeiDreamDbContext : DbContext
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(BeiDreamDbContext));

        public BeiDreamDbContext(string dbName)
            : base(dbName)
        {
            WriteLog();
        }

        public Guid TraceId { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter<ISoftDelete, bool>(EfFilterNames.SoftDelete, entity => entity.IsDeleted, false);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog()
        {
            Database.Log = log =>
            {
                Logger.Fatal(log);
            };
        }
    }
}