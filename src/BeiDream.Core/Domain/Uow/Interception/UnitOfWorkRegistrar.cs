using System.Linq;
using System.Reflection;
using BeiDream.Core.Application.Services;
using BeiDream.Core.Dependency;
using Castle.Core;
using Castle.MicroKernel;

namespace BeiDream.Core.Domain.Uow.Interception
{
    internal static class UnitOfWorkRegistrar
    {
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += ComponentRegistered;
        }

        private static void ComponentRegistered(string key, IHandler handler)
        {
            if (typeof(IApplicationService).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(UnitOfWorkInterceptor)));
            }
        }
    }
}