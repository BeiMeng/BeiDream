using Castle.DynamicProxy;

namespace BeiDream.Demo.Service
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