using BeiDream.Core.Dependency;
using BeiDream.Demo.Service;
using System;

namespace BeiDream.Demo.Consoles
{
    internal class Program
    {
        private static void Main(string[] args)
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