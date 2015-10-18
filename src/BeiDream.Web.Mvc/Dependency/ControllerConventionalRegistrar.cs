using System.Web.Mvc;
using BeiDream.Core.Dependency;
using Castle.MicroKernel.Registration;

namespace BeiDream.Web.Mvc.Dependency
{
    /// <summary>
    /// MVC的控制器全部注入到依赖注入容器
    /// </summary>
    public class ControllerConventionalRegistrar : IConventionalDependencyRegistrar
    {

        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            context.IocManager.IocContainer.Register(
               Classes.FromAssembly(context.Assembly).BasedOn<Controller>().LifestyleTransient()
                );
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(context.IocManager.IocContainer.Kernel));
        }
    }
}