using Castle.DynamicProxy;

namespace BeiDream.Core.Validations.Interception
{
    public class ValidationInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            int t = 5;
            invocation.Proceed();
        }
    }
}