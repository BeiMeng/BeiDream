namespace BeiDream.Core.Caches
{
    /// <summary>
    /// 缓存配置
    /// </summary>
    public interface ICacheConfig
    {
        /// <summary>
        /// 获取缓存提供程序
        /// </summary>
        ICacheProvider GetProvider();

        /// <summary>
        /// 获取缓存键服务
        /// </summary>
        ICacheKey GetKey();
    }
}