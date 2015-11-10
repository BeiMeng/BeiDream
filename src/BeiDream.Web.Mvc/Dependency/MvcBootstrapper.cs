using BeiDream.AutoMapper;
using BeiDream.Core.Dependency;
using BeiDream.Core.Reflection;

namespace BeiDream.Web.Mvc.Dependency
{
    public class MvcBootstrapper : Bootstrapper
    {
        public MvcBootstrapper(ConventionalRegistrarConfig config)
            : base(config)
        {
            //默认设置为web项目
            config.IsWebApp = true;
        }

        /// <summary>
        ///
        /// </summary>
        public override void Initialize()
        {
            //将所有的mvc控制器添加到依赖注入容器
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
            //对象关系映射自动注册
            AutoMapperBootstrapper autoMapperBootstrapper = new AutoMapperBootstrapper(WebAssemblyFinder.Instance);
            autoMapperBootstrapper.Initialize();
            base.Initialize();
        }
    }
}