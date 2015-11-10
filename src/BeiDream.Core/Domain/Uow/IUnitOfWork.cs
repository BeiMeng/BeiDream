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
    }
}