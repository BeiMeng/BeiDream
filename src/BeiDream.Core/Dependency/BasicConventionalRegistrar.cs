using Castle.DynamicProxy;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;

namespace BeiDream.Core.Dependency
{
    /// <summary>
    /// 基础的依赖注入实现类(对实现了ITransientDependency,ISingletonDependency,IInterceptor这三个接口的实例进行自动注册)
    /// </summary>
    public class BasicConventionalRegistrar : IConventionalDependencyRegistrar
    {

        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            //Transient
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ITransientDependency>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );
            //Singleton
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<ISingletonDependency>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleSingleton()
                );

            //Windsor Interceptors
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IInterceptor>()
                    .WithService.Self()
                    .LifestyleTransient()
                );
        }
    }
}