using BeiDream.Core.Dependency;
using BeiDream.Core.Validations.Interception;
using Castle.Core;
using Castle.MicroKernel;

namespace BeiDream.Demo.Service
{
    public class ValidationInterceptorRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private static void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            //if (typeof (IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            //{
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(ValidationInterceptor)));
            //}
        } 
    }
}