using Castle.DynamicProxy;
using System.Reflection;

namespace BeiDream.Core.Domain.Uow.Interception
{
    internal class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkInterceptor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Intercept(IInvocation invocation)
        {
            //MethodInfo method = invocation.Method;
            invocation.Proceed();
            //if (Attribute.IsDefined(method, typeof (NoUnitOfWorkAttribute)))
            //{
            //    return;
            //}
            //if (invocation.Method.IsDefined(typeof(NoUnitOfWorkAttribute), true))
            //{
            //    return;
            //}
            var unitOfWorkAttr = GetUnitOfWorkAttributeOrNull(invocation.MethodInvocationTarget);
            if (unitOfWorkAttr != null)
            {
                return;
            }
            _unitOfWork.Commit();
        }

        internal static NoUnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(NoUnitOfWorkAttribute), false);
            if (attrs.Length > 0)
            {
                return (NoUnitOfWorkAttribute)attrs[0];
            }
            return null;
        }
    }
}