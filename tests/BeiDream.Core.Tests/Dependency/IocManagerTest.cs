using BeiDream.Core.Dependency;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeiDream.Core.Tests.Dependency
{
    [TestClass]
    public class IocManagerTest
    {
        private IIocManager _iocManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _iocManager = new IocManager();
        }

        /// <summary>
        /// 使用封装的IOC管理器包装的原生Castle容器注册
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            _iocManager.IocContainer.Register(Component.For<ITaskService>().ImplementedBy<TaskService>().LifestyleSingleton());
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 使用封装的IOC管理器封装后的注册方法注册
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 重复注册异常，检查是否已注册功能测试
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            if (!_iocManager.IsRegistered<ITaskService>())   //已注册，则不再次注册
                _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 重复注册异常，检查是否已注册功能测试
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            if (!_iocManager.IsRegistered(typeof(ITaskService)))   //已注册，则不再次注册
                _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 包含重复注册检查的注册测试
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            _iocManager.RegisterIfNot<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 包含重复注册检查的注册测试
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            _iocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            _iocManager.RegisterIfNot<ITaskService>(DependencyLifeStyle.Transient);
            ITaskService taskService = _iocManager.Resolve<ITaskService>();
            Assert.AreEqual("aa", taskService.SaveTask("aa"));
        }

        /// <summary>
        /// 属性注入测试
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            _iocManager.RegisterIfNot<ITaskMange, TaskMange>(DependencyLifeStyle.Transient);
            _iocManager.RegisterIfNot<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskMange taskMange = _iocManager.Resolve<ITaskMange>();
            Assert.AreEqual("aa", taskMange.TaskSave("aa"));
        }

        /// <summary>
        /// 构造函数注入测试
        /// </summary>
        [TestMethod]
        public void TestMethod8()
        {
            _iocManager.RegisterIfNot<ITaskMange, TaskMange2>(DependencyLifeStyle.Transient);
            _iocManager.RegisterIfNot<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            ITaskMange taskMange = _iocManager.Resolve<ITaskMange>();
            Assert.AreEqual("aa", taskMange.TaskSave("aa"));
        }
    }

    public interface ITaskMange
    {
        string TaskSave(string msg);
    }

    /// <summary>
    /// 属性注入
    /// </summary>
    public class TaskMange : ITaskMange
    {
        public ITaskService TaskService { get; set; }

        public string TaskSave(string msg)
        {
            return TaskService.SaveTask(msg);
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
            return TaskService.SaveTask(msg);
        }
    }

    public interface ITaskService
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