namespace BeiDream.Core.Caches
{
    /// <summary>
    /// 默认缓存键
    /// </summary>
    public class DefaultCacheKey : ICacheKey
    {
        /// <summary>
        /// 获取缓存键
        /// </summary>
        /// <param name="key">缓存键</param>
        public string GetKey(string key)
        {
            return string.Format("CacheKey_{0}", key);
        }

        /// <summary>
        /// 获取缓存过期标记键
        /// </summary>
        /// <param name="key">缓存键</param>
        public string GetSignKey(string key)
        {
            return string.Format("CacheKey_Sign_{0}", key);
        }
    }
}