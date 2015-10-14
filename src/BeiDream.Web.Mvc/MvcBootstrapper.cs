using System;
using System.Reflection;
using System.Web.Mvc;
using BeiDream.Core.Dependency;
using Castle.MicroKernel.Registration;

namespace BeiDream.Web.Mvc
{
    public class MvcBootstrapper: Bootstrapper
    {

        public  MvcConventionalRegistrarConfig Config { get; private set; }

        public MvcBootstrapper( MvcConventionalRegistrarConfig config,Assembly assembly=null)
            : base(assembly)
        {
            Config = config;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            //将所有的mvc控制器添加到依赖注入容器
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
           
            if (Config.RegistrarForInterface)
                //对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册(默认为true)
                IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            base.Initialize();
        }
    }
}