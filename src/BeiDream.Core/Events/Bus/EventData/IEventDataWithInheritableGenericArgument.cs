namespace BeiDream.Core.Events.Bus.EventData
{
    /// <summary>
    /// 事件数据类必须实现此接口， 事件数据类有一个单独的泛型参数，这个参数被会继承使用
    /// 例如;
    /// 假设Student继承自Person.当触发一个EntityCreatedEventData{Student}事件，
    /// 如果EntityCreatedEventData实现了此接口，EntityCreatedEventData{Person}事件也会被触发
    /// </summary>
    public interface IEventDataWithInheritableGenericArgument
    {
        /// <summary>
        /// 获取创建这个类实例的参数，因为这个类的一个新的实例被创建
        /// </summary>
        /// <returns>Constructor arguments</returns>
        object[] GetConstructorArgs();
    }
}