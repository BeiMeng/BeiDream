using System;

namespace BeiDream.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}