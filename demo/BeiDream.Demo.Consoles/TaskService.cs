using System;

namespace BeiDream.Demo.Consoles
{
    public class TaskService : ITaskService
    {
        public void SaveTask()
        {
            Console.WriteLine("Task is Save");
        }
    }
}