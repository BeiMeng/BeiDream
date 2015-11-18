using BeiDream.Data.Ef;
using BeiDream.Demo.Domain.Model;
using System;
using System.Data.Entity;

namespace BeiDream.Demo.Infrastructure
{
    public class DemoDbContext : DbContextBase, IDbContext
    {
        public DemoDbContext()
            : base("BeiDreamDemo")
        {
            TraceId = Guid.NewGuid();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new AccountEntityConfiguration());
            //modelBuilder.Configurations.Add(new RoleEntityConfiguration());
            //modelBuilder.Configurations.Add(new MemoEntityConfiguration());
        }
    }
}