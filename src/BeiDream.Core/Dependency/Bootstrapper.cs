using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Core.Validations.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Compilation;
using BeiDream.Core.Dependency.Installers;
using BeiDream.Core.Events.Bus.EventBus;

namespace BeiDream.Core.Dependency
{
    public class Bootstrapper
    {
        /// <summary>
        /// 需要跳过的程序集列表
        /// </summary>
        private const string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        public IIocManager IocManager { get; private set; }
        public ConventionalRegistrarConfig ConventionalRegistrarConfig { get; private set; }

        public Bootstrapper(ConventionalRegistrarConfig conventionalRegistrarConfig)
        {
            IocManager = Dependency.IocManager.Instance;
            ConventionalRegistrarConfig = conventionalRegistrarConfig;
        }

        /// <summary>
        /// 过滤系统程序集
        /// </summary>
        private static Assembly[] FilterSystemAssembly(IEnumerable<Assembly> assemblies)
        {
            return assemblies
                .Where(assembly => !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled))
                .ToArray();
        }

        public virtual void Initialize()
        {
            IocManager.IocContainer.Install(new OwnCoreInstaller());
            //领域事件的注册必须在其他的注册之前，这样才能够扫描所有的注册的类,并找到实现的IEventHandler的事件进行注册
            IocManager.IocContainer.Install(new EventBusInstaller(IocManager));
            UnitOfWorkRegistrar.Initialize(IocManager);
            ValidationInterceptorRegistrar.Initialize(IocManager);
            if (ConventionalRegistrarConfig.RegistrarForInterface)
                IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            if (ConventionalRegistrarConfig.Assembly == null)
            {
                var assemblies = ConventionalRegistrarConfig.IsWebApp ? BuildManager.GetReferencedAssemblies().Cast<Assembly>() : AppDomain.CurrentDomain.GetAssemblies();
                assemblies = FilterSystemAssembly(assemblies);
                foreach (var assemblie in assemblies)
                {
                    IocManager.RegisterAssemblyByConvention(assemblie);
                }
            }
            else
            {
                IocManager.RegisterAssemblyByConvention(ConventionalRegistrarConfig.Assembly);
            }
        }
    }
}