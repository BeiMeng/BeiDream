using BeiDream.Core.Dependency;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BeiDream.Data.Ef
{
    public interface IDbContext : IPerWebRequestDependency
    {
        Guid TraceId { get; set; }
        /// <summary>
        /// 关闭数据过滤器方法
        /// </summary>
        /// <param name="filterNames">一个或多个过滤器名称</param>
        /// <returns></returns>
        IDisposable DisableFilters(params string[] filterNames);

        DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}