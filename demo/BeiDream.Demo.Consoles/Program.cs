using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeiDream.Core.Dependency;

namespace BeiDream.Demo.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolesBootstrapper consolesBootstrapper = new ConsolesBootstrapper();
            consolesBootstrapper.Initialize();
            ITaskMange taskMange = IocManager.Instance.Resolve<ITaskMange>();
            Console.WriteLine(taskMange.TaskSave("AA"));
            Console.ReadKey();

        }
    }
}
