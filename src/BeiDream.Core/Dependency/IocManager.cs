using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入管理器实现类
    /// </summary>
    public class IocManager : IIocManager
    {
        /// <summary>
        /// 一个依赖注入管理器的单例,方便使用,当无法使用构造函数注入的时候(例如：IocManager.Instance,)
        /// </summary>
        public static IocManager Instance { get; private set; }
        public IWindsorContainer IocContainer { get; private set; }
        public Guid TracId { get; private set; }
        /// <summary>
        /// 所有的注册依赖注入实现类集合
        /// </summary>
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;
        static IocManager()
        {
            Instance = new IocManager();
        }
        public IocManager()
        {
            TracId = Guid.NewGuid();
            IocContainer = new WindsorContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //创建依赖注入管理器之前，先将自己的实现进行注册
            IocContainer.Register(
                Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this)
                );
        }
        /// <summary>
        /// 检查当前接口是否已注册实例
        /// </summary>
        /// <param name="type">接口类型</param>
        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        /// <summary>
        ///  检查当前接口是否已注册实例
        /// </summary>
        /// <typeparam name="TType">接口</typeparam>
        public bool IsRegistered<TType>()
        {
            return IocContainer.Kernel.HasComponent(typeof(TType));
        }
        /// <summary>
        /// 将依赖注入注册实现类添加到依赖注入实现类集合
        /// </summary>
        /// <param name="registrar">依赖注入注册实现类</param>
        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        /// <summary>
        /// 对依赖注入实现类集合里的实现类全部进行注册
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            var context = new ConventionalRegistrationContext(assembly, this);
            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }
        }
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        /// <summary>
        /// Registers a type as self registration.
        /// </summary>
        /// <typeparam name="TType">Type of the class</typeparam>
        /// <param name="lifeStyle">Lifestyle of the objects of this type</param>
        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
        }
        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }
        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
    where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }

        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }
    }
}