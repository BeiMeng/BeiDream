using System.Reflection;

namespace BeiDream.Core.Dependency
{
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

        public ConventionalRegistrarConfig()
        {
            IsWebApp = false;
            Assembly = null;
            RegistrarForInterface = true;
        }
        public ConventionalRegistrarConfig(bool registrarForInterface)
        {
            IsWebApp = false;
            Assembly = null;
            RegistrarForInterface = registrarForInterface;
        }
        public ConventionalRegistrarConfig(Assembly assembly)
        {
            IsWebApp = false;
            Assembly = assembly;
            RegistrarForInterface = true;
        }
        public ConventionalRegistrarConfig(bool isWebApp,Assembly assembly)
        {
            IsWebApp = isWebApp;
            Assembly = assembly;
            RegistrarForInterface = true;
        }
        public ConventionalRegistrarConfig(bool isWebApp, bool registrarForInterface)
        {
            IsWebApp = isWebApp;
            Assembly = null;
            RegistrarForInterface = registrarForInterface;
        }
        public ConventionalRegistrarConfig(Assembly assembly, bool registrarForInterface)
        {
            IsWebApp = false;
            Assembly = assembly;
            RegistrarForInterface = registrarForInterface;
        }
        public ConventionalRegistrarConfig(bool isWebApp, Assembly assembly, bool registrarForInterface)
        {
            IsWebApp = isWebApp;
            Assembly = assembly;
            RegistrarForInterface = registrarForInterface;
        }
    }
}