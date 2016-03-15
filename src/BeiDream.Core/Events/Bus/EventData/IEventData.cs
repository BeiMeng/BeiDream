using System;

namespace BeiDream.Core.Events.Bus.EventData
{
    /// <summary>
    /// 为所有的事件数据类定义的接口
    /// </summary>
    public interface IEventData
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象（可选）
        /// </summary>
        object EventSource { get; set; }
    }
}