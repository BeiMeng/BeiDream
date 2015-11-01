using System;
using System.Data.Entity;
using BeiDream.Data.Ef;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Infrastructure.Mappings;

namespace BeiDream.Demo.Infrastructure
{
    public class DemoDbContext : BeiDreamDbContext, IDbContext
    {
        public DemoDbContext()
            : base("BeiDreamDemo")
        {
            TraceId = Guid.NewGuid();
        }

        //public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        //public DbSet<Memo> Memos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new AccountEntityConfiguration());
            //modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            //modelBuilder.Configurations.Add(new MemoEntityConfiguration());
        }
    }
}