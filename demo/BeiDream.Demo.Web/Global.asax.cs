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
using BeiDream.Demo.Service;
using BeiDream.Logging.Log4Net;
using BeiDream.Utils.Logging;
using BeiDream.Web.Mvc.Dependency;
using Castle.Windsor.Installer;

namespace BeiDream.Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Log4NetLoggingInitializer.Initialize(new LoggingConfig(true, LogLevel.All));
            ILogger logger = LogManager.GetLogger(typeof(MvcApplication));
            logger.Debug("网站启动");
            //mvc网站模块依赖注册
            MvcBootstrapper mvcBootstrapper = new MvcBootstrapper(new ConventionalRegistrarConfig());
            AopRegistrar.Initialize(mvcBootstrapper.IocManager);
            ValidationInterceptorRegistrar.Initialize(mvcBootstrapper.IocManager);
            mvcBootstrapper.Initialize();
            logger.Debug("依赖注入完成");
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
