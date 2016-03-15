using System;

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
        /// <summary>
        /// Gets an object from IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <param name="type">Type of the object to get</param>
        /// <returns>The object instance</returns>
        object Resolve(Type type);
        /// <summary>
        /// Releases a pre-resolved object. See Resolve methods.
        /// </summary>
        /// <param name="obj">Object to be released</param>
        void Release(object obj);
    }
}