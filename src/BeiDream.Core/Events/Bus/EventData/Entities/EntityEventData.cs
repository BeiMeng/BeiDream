using System;
using BeiDream.Core.Domain.Entities;

namespace BeiDream.Core.Events.Bus.EventData.Entities
{
    /// <summary>
    /// 给一个事件传递数据，这个事件与<see cref="IEntity"/>相关
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    [Serializable]
    public class EntityEventData<TEntity> : EventData, IEventDataWithInheritableGenericArgument
    {
        /// <summary>
        ///与事件关联的实体
        /// </summary>
        public TEntity Entity { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entity">与事件关联的实体</param>
        public EntityEventData(TEntity entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// 获取创建这个类实例的参数
        /// </summary>
        /// <returns></returns>
        public virtual object[] GetConstructorArgs()
        {
            return new object[] { Entity };
        }
    }
}