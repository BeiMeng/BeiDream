using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeiDream.Core.Dependency;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BeiDream.Demo.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolesBootstrapper consolesBootstrapper = new ConsolesBootstrapper();
            AopRegistrar.Initialize(consolesBootstrapper.IocManager);
            consolesBootstrapper.Initialize();
            ITaskMange taskMange = IocManager.Instance.Resolve<ITaskMange>();
            Console.WriteLine(taskMange.TaskSave("AA"));
            Console.ReadKey();
        }
    }
}
