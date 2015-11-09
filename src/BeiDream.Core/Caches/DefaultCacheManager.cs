namespace BeiDream.Core.Caches {
    /// <summary>
    /// 默认缓存管理器
    /// </summary>
    public class DefaultCacheManager : CacheManagerBase {
        /// <summary>
        /// 初始化基缓存管理器
        /// </summary>
        /// <param name="config">缓存配置</param>
        public DefaultCacheManager( ICacheConfig config ) : base( config ) {
        }

        /// <summary>
        /// 初始化基缓存管理器
        /// </summary>
        /// <param name="provider">缓存提供程序</param>
        /// <param name="cacheKey">缓存键</param>
        public DefaultCacheManager( ICacheProvider provider, ICacheKey cacheKey )
            : base( provider, cacheKey ) {
        }
    }
}
