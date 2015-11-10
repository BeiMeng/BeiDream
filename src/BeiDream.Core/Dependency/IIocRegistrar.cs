using System;
using System.Reflection;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入注册接口
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 检查当前接口是否已注册实例
        /// </summary>
        /// <param name="type">接口类型</param>
        bool IsRegistered(Type type);

        /// <summary>
        ///  检查当前接口是否已注册实例
        /// </summary>
        /// <typeparam name="TType">接口</typeparam>
        bool IsRegistered<TType>();

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

        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        /// <summary>
        /// Registers a type with it's implementation.
        /// </summary>
        /// <typeparam name="TType">Registering type</typeparam>
        /// <typeparam name="TImpl">The type that implements <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;
    }
}