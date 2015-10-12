using System;
using Castle.Windsor;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入管理器接口
    /// </summary>
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// Castle的依赖注入容器
        /// </summary>
        IWindsorContainer IocContainer { get; }
    }
}