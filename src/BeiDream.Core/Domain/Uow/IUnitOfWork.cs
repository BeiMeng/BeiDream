using System;
using BeiDream.Core.Dependency;

namespace BeiDream.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元接口(主要进行事务管理)
    /// </summary>
    public interface IUnitOfWork : ITransientDependency
    {
        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
        /// <summary>
        /// 关闭数据过滤器方法
        /// </summary>
        /// <param name="filterNames">一个或多个过滤器名称</param>
        /// <returns></returns>
        IDisposable DisableFilters(params string[] filterNames);
    }
}