using System.Reflection;
using BeiDream.Core.Dependency;

namespace BeiDream.Demo.Consoles
{
    public class ConsolesBootstrapper : Bootstrapper
    {
        public ConsolesBootstrapper()
            : base(new ConventionalRegistrarConfig(true))
        {
        }

        public override void Initialize()
        {

            //IocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            //IocManager.Register<ITaskMange, TaskMange2>(DependencyLifeStyle.Transient);
            base.Initialize();
        }
    }
}