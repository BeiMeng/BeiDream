using System.Reflection;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入注册接口
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 将依赖注入注册实现类添加到依赖注入实现类集合
        /// </summary>
        /// <param name="registrar">依赖注入注册实现类</param>
        void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);
        /// <summary>
        /// 对依赖注入实现类集合里的实现类全部进行注册
        /// </summary>
        /// <param name="assembly"></param>
        void RegisterAssemblyByConvention(Assembly assembly);
    }
}