using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BeiDream.Core.Dependency;
using BeiDream.Utils.Logging;
using BeiDream.Utils.Reflection;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel;

namespace BeiDream.Demo.Service
{
    public class AopTest
    {
         
    }
    /// <summary>
    /// AOP方法拦截器
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AopAttribute : Attribute
    {
        public bool IsAop { get; private set; }

        public AopAttribute(bool isAop)
        {
            IsAop = isAop;
        }
    }

    /// <summary>
    /// AOP方法拦截实现
    /// </summary>
    public class AopInterceptor : IInterceptor
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(AopInterceptor));
        public void Intercept(IInvocation invocation)
        {
            var aopAttributes =
                ReflectionHelper.GetAttributesOfMemberAndDeclaringType<AopAttribute>(
                    invocation.MethodInvocationTarget
                    );

            if (aopAttributes.Count <= 0)
            {
                invocation.Proceed();
                return;
            }

            CheckAop(aopAttributes);

            invocation.Proceed();
        }

        private void CheckAop(List<AopAttribute> aopAttributes)
        {
            foreach (var aopAttribute in aopAttributes)
            {
                if (aopAttribute.IsAop)
                {
                    Logger.Debug("拦截启动");
                    Console.WriteLine("Success");
                }
            }
        }
    }
    public static class AopRegistrar
    {
        /// <summary>
        /// Initializes the registerer.
        /// </summary>sssss
        /// <param name="iocManager">IOC manager</param>
        public static void Initialize(IIocManager iocManager)
        {
            iocManager.IocContainer.Kernel.ComponentRegistered += ComponentRegistered;
        }

        private static void ComponentRegistered(string key, IHandler handler)
        {
            if (handler.ComponentModel.Implementation.GetMethods(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Any(m => m.IsDefined(typeof(AopAttribute), true)))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(AopInterceptor)));
            }
        }
    }
}