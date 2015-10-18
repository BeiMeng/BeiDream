using BeiDream.Core.Dependency;
using Castle.Core;
using Castle.MicroKernel;

namespace BeiDream.Core.Validations.Interception
{
    public class ValidationInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
             handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ValidationInterceptor)));
        } 
    }
}