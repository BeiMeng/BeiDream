using System.Reflection;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 依赖注入配置文件
    /// </summary>
    public class ConventionalRegistrarConfig
    {
        /// <summary>
        /// 需注册的程序集，不传入，默认注册当前项目所在目录的所有程序集
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// 是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册(默认为true)
        /// </summary>
        public bool RegistrarForInterface { get; protected set; }

        /// <summary>
        /// 是否为Web项目(默认为false)
        /// </summary>
        public bool IsWebApp { get; set; }

        /// <summary>
        /// 默认为非web项目.默认为注册项目所在目录所有程序集,默认对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册
        /// </summary>
        public ConventionalRegistrarConfig()
        {
            IsWebApp = false;
            Assembly = null;
            RegistrarForInterface = true;
        }

        /// <summary>
        /// 默认为非web项目.默认为注册项目所在目录所有程序集
        /// </summary>
        /// <param name="registrarForInterface">是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册</param>
        public ConventionalRegistrarConfig(bool registrarForInterface)
        {
            IsWebApp = false;
            Assembly = null;
            RegistrarForInterface = registrarForInterface;
        }

        /// <summary>
        /// 默认为非web项目,默认对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册
        /// </summary>
        /// <param name="assembly">是否传入注册程序集,为null则注册所有程序集，不为null则只注册传入的程序集</param>
        public ConventionalRegistrarConfig(Assembly assembly)
        {
            IsWebApp = false;
            Assembly = assembly;
            RegistrarForInterface = true;
        }

        /// <summary>
        /// 默认对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册
        /// </summary>
        /// <param name="isWebApp">是否为web项目</param>
        /// <param name="assembly">是否传入注册程序集,为null则注册所有程序集，不为null则只注册传入的程序集</param>
        public ConventionalRegistrarConfig(bool isWebApp, Assembly assembly)
        {
            IsWebApp = isWebApp;
            Assembly = assembly;
            RegistrarForInterface = true;
        }

        /// <summary>
        /// 默认为注册项目所在目录所有程序集
        /// </summary>
        /// <param name="isWebApp">是否为web项目</param>
        /// <param name="registrarForInterface">是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册</param>
        public ConventionalRegistrarConfig(bool isWebApp, bool registrarForInterface)
        {
            IsWebApp = isWebApp;
            Assembly = null;
            RegistrarForInterface = registrarForInterface;
        }

        /// <summary>
        /// 默认为非web项目
        /// </summary>
        /// <param name="assembly">是否传入注册程序集,为null则注册所有程序集，不为null则只注册传入的程序集</param>
        /// <param name="registrarForInterface">是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册</param>
        public ConventionalRegistrarConfig(Assembly assembly, bool registrarForInterface)
        {
            IsWebApp = false;
            Assembly = assembly;
            RegistrarForInterface = registrarForInterface;
        }

        /// <summary>
        /// 依赖注入配置
        /// </summary>
        /// <param name="isWebApp">是否为web项目</param>
        /// <param name="assembly">是否传入注册程序集,为null则注册所有程序集，不为null则只注册传入的程序集</param>
        /// <param name="registrarForInterface">是否对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册</param>
        public ConventionalRegistrarConfig(bool isWebApp, Assembly assembly, bool registrarForInterface)
        {
            IsWebApp = isWebApp;
            Assembly = assembly;
            RegistrarForInterface = registrarForInterface;
        }
    }
}