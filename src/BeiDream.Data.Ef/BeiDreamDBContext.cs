using System;
using System.Data.Entity;
using BeiDream.Core.Domain.Entities;
using BeiDream.Data.Ef.Datas;
using BeiDream.Data.Ef.EntityFramework.DynamicFilters;

namespace BeiDream.Data.Ef
{
    public class BeiDreamDbContext : DbContext, IDbContext
    {
        public BeiDreamDbContext(string dbName)
            : base(dbName)
        {
        }
        public Guid TraceId { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter<ISoftDelete, bool>(EfFilterNames.SoftDelete, entity => entity.IsDeleted, false);
        }
    }
}