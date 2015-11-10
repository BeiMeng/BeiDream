using System;

namespace BeiDream.Core.Caches
{
    /// <summary>
    /// 缓存管理器
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        T Get<T>(string key, Func<T> addHandler, int time = 0);

        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：分</param>
        T GetByMinutes<T>(string key, Func<T> addHandler, int time = 0);

        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：小时</param>
        T GetByHours<T>(string key, Func<T> addHandler, int time = 0);

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        void Update(string key, object target, int time);

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);
    }
}