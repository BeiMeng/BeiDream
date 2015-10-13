using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BeiDream.Core.Dependency;
using BeiDream.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Reflection;

namespace BeiDream.Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //IWindsorContainer windsor = new WindsorContainer();
            //windsor.Register(
            //    Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient()
            //    //Component.For<ITaskService>().ImplementedBy<TaskService>().LifestyleSingleton()
            //    );
            //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(windsor.Kernel));
            MvcBootstrapper mvcBootstrapper = new MvcBootstrapper(new MvcConventionalRegistrarConfig(true), Assembly.GetExecutingAssembly());
            mvcBootstrapper.Initialize();
            //mvcBootstrapper.IocManager.Register<ITaskService, TaskService>(DependencyLifeStyle.Transient);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
