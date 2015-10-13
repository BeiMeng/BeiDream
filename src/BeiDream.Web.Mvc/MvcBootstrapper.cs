using System;
using System.Reflection;
using System.Web.Mvc;
using BeiDream.Core.Dependency;
using Castle.MicroKernel.Registration;

namespace BeiDream.Web.Mvc
{
    public class MvcBootstrapper
    {
        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; private set; }
        public MvcConventionalRegistrarConfig Config { get; private set; }
        public Assembly Assembly { get; private set; }
        /// <summary>
        /// Creates a new <see cref="MvcBootstrapper"/> instance.
        /// </summary>
        public MvcBootstrapper(MvcConventionalRegistrarConfig config, Assembly assembly)
            : this(Core.Dependency.IocManager.Instance, config, assembly)
         {
             Config = config;
            Assembly = assembly;
         }

        /// <summary>
        /// Creates a new <see cref="MvcBootstrapper"/> instance.
        /// </summary>
        /// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        /// <param name="config"></param>
        public MvcBootstrapper(IIocManager iocManager, MvcConventionalRegistrarConfig config, Assembly assembly)
        {
            IocManager = iocManager;
            Config = config;
            Assembly = assembly;
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        public virtual void Initialize()
        {

            //将所有的mvc控制器添加到依赖注入容器
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
            if (Config.RegistrarForInterface)
            {
                //将对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册，添加到依赖注入容器
                IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            }
            //对添加到依赖注入容器里的实现集合进行注册
            IocManager.RegisterAssemblyByConvention(Assembly);
        }
    }
}