using System.Collections.Generic;
using System.Linq;
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
            var disableFiltersAttr = GetDisableFiltersAttributeOrNull(invocation.MethodInvocationTarget);
            if (disableFiltersAttr != null)
            {
                List<string> filterNames= disableFiltersAttr.FilterNames.Select(filterName => filterName.ToString()).ToList();
                _unitOfWork.DisableFilters(filterNames.ToArray());
            }
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
            var unitOfWorkAttr = GetNoUnitOfWorkAttributeOrNull(invocation.MethodInvocationTarget);
            if (unitOfWorkAttr != null)
            {
                return;
            }
            _unitOfWork.Commit();
        }

        internal static NoUnitOfWorkAttribute GetNoUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(NoUnitOfWorkAttribute), false);
            if (attrs.Length > 0)
            {
                return (NoUnitOfWorkAttribute)attrs[0];
            }
            return null;
        }
        internal static DisableFiltersAttribute GetDisableFiltersAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(DisableFiltersAttribute), false);
            if (attrs.Length > 0)
            {
                return (DisableFiltersAttribute)attrs[0];
            }
            return null;
        }
    }
}