using BeiDream.Core.Domain.Entities;

namespace BeiDream.Core.Domain.Uow
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public interface IUnitOfWork
    {
        //void RegisterNew<TAggregateRoot,TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>;
        //void RegisterDirty<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>;
        //void RegisterClean<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>;
        //void RegisterDeleted<TAggregateRoot, TKey>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot<TKey>;
        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}