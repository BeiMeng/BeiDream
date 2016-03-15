namespace BeiDream.Core.Events.Bus.Handlers
{
    /// <summary>
    /// 定义一个处理<see cref="TEventData"/>类型事件类的接口
    /// </summary>
    /// <typeparam name="TEventData">要处理的事件类型</typeparam>
    public interface IEventHandler<in TEventData> : IEventHandler
    {
        /// <summary>
        /// 通过实现此方法，完成事件处理器处理事件
        /// </summary>
        /// <param name="eventData">事件数据</param>
        void HandleEvent(TEventData eventData);
    }
}