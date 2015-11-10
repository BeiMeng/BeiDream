using BeiDream.Utils.Extensions;
using System;
using System.Threading.Tasks;

namespace BeiDream.Core.Caches
{
    /// <summary>
    /// 基缓存管理器
    /// </summary>
    public abstract class CacheManagerBase : ICacheManager
    {
        /// <summary>
        /// 初始化基缓存管理器
        /// </summary>
        /// <param name="config">缓存配置</param>
        protected CacheManagerBase(ICacheConfig config)
            : this(config.GetProvider(), config.GetKey())
        {
        }

        /// <summary>
        /// 初始化基缓存管理器
        /// </summary>
        /// <param name="provider">缓存提供程序</param>
        /// <param name="cacheKey">缓存键</param>
        protected CacheManagerBase(ICacheProvider provider, ICacheKey cacheKey)
        {
            provider.CheckNotNull("provider");
            cacheKey.CheckNotNull("cacheKey");
            CacheProvider = provider;
            CacheKey = cacheKey;
        }

        /// <summary>
        /// 缓存提供程序
        /// </summary>
        public ICacheProvider CacheProvider { get; private set; }

        /// <summary>
        /// 缓存键
        /// </summary>
        public ICacheKey CacheKey { get; private set; }

        /// <summary>
        /// 缓存过期标记
        /// </summary>
        public const string CacheSign = "a";

        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        public T Get<T>(string key, Func<T> addHandler, int time = 0)
        {
            var lockKey = GetKey(key);
            var signKey = GetSignKey(key);
            var result = CacheProvider.Get<T>(lockKey);
            var sign = CacheProvider.Get<string>(signKey);
            if (!string.IsNullOrWhiteSpace(sign))
                return result;
            lock (signKey)
            {
                sign = CacheProvider.Get<string>(signKey);
                if (!string.IsNullOrWhiteSpace(sign))
                    return result;
                CacheProvider.Add(signKey, CacheSign, GetCacheTime(time));
                return UpdateCache(addHandler, lockKey, time, result);
            }
        }

        /// <summary>
        /// 获取缓存键
        /// </summary>
        private string GetKey(string key)
        {
            return CacheKey.GetKey(key);
        }

        /// <summary>
        /// 获取缓存过期标记
        /// </summary>
        private string GetSignKey(string key)
        {
            return string.Intern(CacheKey.GetSignKey(key));
        }

        /// <summary>
        /// 获取缓存时间
        /// </summary>
        private int GetCacheTime(int time)
        {
            return time;
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        private T UpdateCache<T>(Func<T> addHandler, string lockKey, int time, T result)
        {
            if (Equals(result, null))
            {
                result = addHandler();
                CacheProvider.Add(lockKey, result, GetCacheTime(time) * 2);
                return result;
            }
            Task.Factory.StartNew(() => CacheProvider.Update(lockKey, addHandler(), GetCacheTime(time) * 2));
            return result;
        }

        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：分</param>
        public T GetByMinutes<T>(string key, Func<T> addHandler, int time = 0)
        {
            return Get(key, addHandler, time * 60);
        }

        /// <summary>
        /// 获取缓存对象，当缓存对象不存在，则执行方法并添加到缓存中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <param name="addHandler">添加缓存方法，当缓存对象不存在时，执行该方法获得缓存对象</param>
        /// <param name="time">缓存过期时间，单位：小时</param>
        public T GetByHours<T>(string key, Func<T> addHandler, int time = 0)
        {
            return Get(key, addHandler, time * 3600);
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        public void Update(string key, object target, int time)
        {
            CacheProvider.Update(GetSignKey(key), CacheSign, GetCacheTime(time));
            CacheProvider.Update(GetKey(key), target, GetCacheTime(time) * 2);
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            CacheProvider.Remove(GetSignKey(key));
            CacheProvider.Remove(GetKey(key));
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public void Clear()
        {
            CacheProvider.Clear();
        }
    }
}