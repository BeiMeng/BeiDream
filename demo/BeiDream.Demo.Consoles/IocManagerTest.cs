using BeiDream.Core.Dependency;

namespace BeiDream.Demo.Service
{
    public interface ITaskMange : ITransientDependency
    {
        string TaskSave(string msg);
    }
    /// <summary>
    /// 属性注入
    /// </summary>
    public class TaskMange : ITaskMange
    {
        public ITaskService TaskService { get; set; }
        [Aop(true)]
        public string TaskSave(string msg)
        {
            return TaskService.SaveTask(msg+"属性注入");
        }
    }
    /// <summary>
    /// 构造函数注入
    /// </summary>
    public class TaskMange2 : ITaskMange
    {
        public ITaskService TaskService;

        public TaskMange2(ITaskService taskService)
        {
            TaskService = taskService;
        }

        public string TaskSave(string msg)
        {
            return TaskService.SaveTask(msg + "构造函数注入");
        }
    }
    public interface ITaskService : ITransientDependency
    {
        string SaveTask(string msg);
    }

    public class TaskService : ITaskService
    {
        public string SaveTask(string msg)
        {
            return msg;
        }
    }
}