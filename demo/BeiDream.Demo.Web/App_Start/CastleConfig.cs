using BeiDream.Core.Dependency;
using BeiDream.Demo.Service;
using BeiDream.Web.Mvc.Dependency;

namespace BeiDream.Demo.Web
{
    /// <summary>
    /// 依赖注入(IOC)容器初始化
    /// </summary>
    public static class CastleConfig
    {
        public static void Initialize()
        {

            MvcBootstrapper mvcBootstrapper = new MvcBootstrapper(new ConventionalRegistrarConfig());
            //AOP必须先初始化
            AopRegistrar.Initialize(mvcBootstrapper.IocManager);
            //依赖注入初始化
            mvcBootstrapper.Initialize();
        }

    }
}