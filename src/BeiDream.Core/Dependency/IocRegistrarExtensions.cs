namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入注册功能的扩展
    /// </summary>
    public static class IocRegistrarExtensions
    {
        #region RegisterIfNot

        /// <summary>
        /// 首先判断是否已注册，已注册直接返回，没注册，再进行注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iocRegistrar"></param>
        /// <param name="lifeStyle"></param>
        public static void RegisterIfNot<T>(this IIocRegistrar iocRegistrar, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class
        {
            if (iocRegistrar.IsRegistered<T>())
            {
                return;
            }

            iocRegistrar.Register<T>(lifeStyle);
        }

        /// <summary>
        /// 首先判断是否已注册，已注册直接返回，没注册，再进行注册
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="iocRegistrar"></param>
        /// <param name="lifeStyle"></param>
        public static void RegisterIfNot<TType, TImpl>(this IIocRegistrar iocRegistrar, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            if (iocRegistrar.IsRegistered<TType>())
            {
                return;
            }

            iocRegistrar.Register<TType, TImpl>(lifeStyle);
        }

        #endregion RegisterIfNot
    }
}