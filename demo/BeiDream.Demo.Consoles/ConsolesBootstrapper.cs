using System.Reflection;
using BeiDream.Core.Dependency;

namespace BeiDream.Demo.Consoles
{
    public class ConsolesBootstrapper : Bootstrapper
    {
        public ConsolesBootstrapper()
            : base(Assembly.GetExecutingAssembly())
        {
        }

        public override void Initialize()
        {
            IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());
            //IocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            //IocManager.Register<ITaskMange, TaskMange2>(DependencyLifeStyle.Transient);
            base.Initialize();
        }
    }
}