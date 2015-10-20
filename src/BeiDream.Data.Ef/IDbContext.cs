using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeiDream.Core.Dependency;

namespace BeiDream.Data.Ef
{
    public interface IDbContext : ITransientDependency
    {
        DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges(); 
    }
}