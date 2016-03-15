using System;
using BeiDream.Core.Dependency;

namespace BeiDream.Core.Events.Bus.Handlers
{
    /// <summary>
    /// 此事件处理器是一个能使用<see cref="IEventHandler{TEventData}"/>实现一个Action的适配器
    /// </summary>
    /// <typeparam name="TEventData">事件类型</typeparam>
    internal class ActionEventHandler<TEventData> :
        IEventHandler<TEventData>,
        ITransientDependency
    {
        /// <summary>
        /// 使用事件的Action
        /// </summary>
        public Action<TEventData> Action { get; private set; }

        /// <summary>
        /// 创建一个新的 <see cref="ActionEventHandler{TEventData}"/>实例.
        /// </summary>
        /// <param name="handler">Action to handle the event</param>
        public ActionEventHandler(Action<TEventData> handler)
        {
            Action = handler;
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(TEventData eventData)
        {
            Action(eventData);
        }
    }
}