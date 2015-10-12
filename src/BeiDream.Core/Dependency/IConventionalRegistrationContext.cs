using System.Reflection;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入实现类的上下文接口
    /// </summary>
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        ///上下文的程序集(调用者传入)
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// 上下文的依赖注入管理器(调用者传入)
        /// </summary>
        IIocManager IocManager { get; }
    }
}