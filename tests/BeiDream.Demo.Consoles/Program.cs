using System;
using BeiDream.Core.Dependency;

namespace BeiDream.Consoles.Tests
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