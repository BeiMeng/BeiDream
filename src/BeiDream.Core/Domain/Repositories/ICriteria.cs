using System;
using System.Linq.Expressions;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Core.Domain.Repositories {
    /// <summary>
    /// 查询条件
    /// </summary>
    public interface ICriteria {
        /// <summary>
        /// 获取谓词
        /// </summary>
        string GetPredicate();
        /// <summary>
        /// 获取值列表
        /// </summary>
        object[] GetValues();
    }

    /// <summary>
    /// 查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICriteria<TEntity> where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// 获取谓词
        /// </summary>
        Expression<Func<TEntity, bool>> GetPredicate();
    }
}
