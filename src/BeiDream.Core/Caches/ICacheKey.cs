namespace BeiDream.Core.Caches {
    /// <summary>
    /// 缓存键
    /// </summary>
    public interface ICacheKey {
        /// <summary>
        /// 获取加工后的缓存键
        /// </summary>
        /// <param name="key">缓存键</param>
        string GetKey( string key );
        /// <summary>
        /// 获取缓存过期标记键
        /// </summary>
        /// <param name="key">缓存键</param>
        string GetSignKey( string key );
    }
}
