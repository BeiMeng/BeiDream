using System.Reflection;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入上下文实现类
    /// </summary>
    internal class ConventionalRegistrationContext : IConventionalRegistrationContext
    {
        /// <summary>
        /// Gets the registering Assembly.
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// Reference to the IOC Container to register types.
        /// </summary>
        public IIocManager IocManager { get; private set; }


        /// <summary>
        /// 依赖注入上下文构造函数,
        /// </summary>
        /// <param name="assembly">注册程序集</param>
        /// <param name="iocManager">依赖注入管理器</param>
        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager)
        {
            Assembly = assembly;
            IocManager = iocManager;
        }
    }
}