namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入解析接口
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <returns>The object instance</returns>
        T Resolve<T>();
    }
}