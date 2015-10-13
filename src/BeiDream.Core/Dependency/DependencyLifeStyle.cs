namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入实例的生命周期枚举
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// 一个对象被传递给所有需要的类。只是在第一次使用时创建，那么应用程序的整生命周期使用的是同一实例
        /// </summary>
        Singleton,

        /// <summary>
        /// 请求生命周期实例
        /// </summary>
        Transient
    }
}