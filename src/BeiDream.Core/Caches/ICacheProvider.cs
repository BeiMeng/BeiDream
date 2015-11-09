
namespace BeiDream.Core.Caches {
    /// <summary>
    /// 缓存提供程序
    /// </summary>
    public interface ICacheProvider {
        /// <summary>
        /// 添加缓存对象,缓存时间单位：秒
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        void Add( string key, object target, int time );
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        void Update( string key, object target, int time );
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        T Get<T>( string key );
        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove( string key );
        /// <summary>
        /// 清空所有缓存
        /// </summary>
        void Clear();
    }
}
