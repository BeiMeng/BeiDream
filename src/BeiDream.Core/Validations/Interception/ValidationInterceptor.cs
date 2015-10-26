using Castle.DynamicProxy;

namespace BeiDream.Core.Validations.Interception
{
    public class ValidationInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            new MethodInvocationValidator(
                invocation.Method,
                invocation.Arguments
                ).Validate();

            invocation.Proceed();
        }
    }
}