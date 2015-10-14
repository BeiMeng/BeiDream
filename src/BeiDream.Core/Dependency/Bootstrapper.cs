using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Compilation;

namespace BeiDream.Core.Dependency
{
    public class Bootstrapper
    {
        /// <summary>
        /// 需要跳过的程序集列表
        /// </summary>
        private const string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";
        public IIocManager IocManager { get; private set; }
        public Assembly Assembly { get; private set; }
        public Bootstrapper(Assembly assembly=null)
        {
            IocManager = Dependency.IocManager.Instance;
            Assembly = assembly;

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
            if (Assembly == null)
            {
                var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
                assemblies = FilterSystemAssembly(assemblies);
                foreach (var assemblie in assemblies)
                {
                    IocManager.RegisterAssemblyByConvention(assemblie);
                }
                return;
            }
            IocManager.RegisterAssemblyByConvention(Assembly);

        }
    }
}