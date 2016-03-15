using System;
using BeiDream.Utils.Timing;

namespace BeiDream.Core.Events.Bus.EventData
{
    /// <summary>
    /// 实现接口 <see cref="IEventData"/> 并为事件数据提供一个基类.
    /// </summary>
    [Serializable]
    public abstract class EventData : IEventData
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象（可选）
        /// </summary>
        public object EventSource { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected EventData()
        {
            EventTime = Clock.Now;
        }
    }
}