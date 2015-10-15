using System;
using System.Reflection;
using System.Web.Mvc;
using BeiDream.Core.Dependency;
using Castle.MicroKernel.Registration;

namespace BeiDream.Web.Mvc
{
    public class MvcBootstrapper: Bootstrapper
    {
        public MvcBootstrapper(ConventionalRegistrarConfig config)
            : base(config)
        {
            config.IsWebApp = true;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void Initialize()
        {
            //将所有的mvc控制器添加到依赖注入容器
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());        
            base.Initialize();
        }
    }
}