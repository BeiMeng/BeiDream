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
                //if (handler.ComponentModel.Implementation.GetMethods(
                //    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                //    .Any(m =>! m.IsDefined(typeof (NoUnitOfWorkAttribute), true)))
                //{
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(UnitOfWorkInterceptor)));
                //}
            }
        }
    }
}