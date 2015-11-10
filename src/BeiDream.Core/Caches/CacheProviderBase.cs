namespace BeiDream.Core.Caches
{
    /// <summary>
    /// 基缓存提供程序
    /// </summary>
    public abstract class CacheProviderBase : ICacheProvider
    {
        #region Add(添加缓存对象)

        /// <summary>
        /// 添加缓存对象,缓存时间单位：秒
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        public void Add(string key, object target, int time)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            if (target == null)
                return;
            AddCache(FilterKey(key), target, time);
        }

        /// <summary>
        /// 过滤键
        /// </summary>
        private string FilterKey(string key)
        {
            return key.Trim().ToLower();
        }

        /// <summary>
        /// 添加缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位:秒</param>
        protected abstract void AddCache(string key, object target, int time);

        #endregion Add(添加缓存对象)

        #region Update(更新缓存)

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        public void Update(string key, object target, int time)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            UpdateCache(FilterKey(key), target, time);
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="target">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        protected abstract void UpdateCache(string key, object target, int time);

        #endregion Update(更新缓存)

        #region Get(获取缓存对象)

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return default(T);
            return GetCache<T>(FilterKey(key));
        }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        protected abstract T GetCache<T>(string key);

        #endregion Get(获取缓存对象)

        #region Remove(移除缓存对象)

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            RemoveCache(FilterKey(key));
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        protected abstract void RemoveCache(string key);

        #endregion Remove(移除缓存对象)

        #region Clear(清空所有缓存)

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public abstract void Clear();

        #endregion Clear(清空所有缓存)
    }
}