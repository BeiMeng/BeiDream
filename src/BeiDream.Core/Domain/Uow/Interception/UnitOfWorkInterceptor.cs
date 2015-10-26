using Castle.DynamicProxy;

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
            invocation.Proceed();
            _unitOfWork.Commit();
        }
    }
}