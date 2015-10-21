using BeiDream.Core.Domain.Entities;

namespace BeiDream.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元接口(主要进行事务管理)
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}