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

namespace BeiDream.Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //mvc网站模块依赖注册
            MvcBootstrapper mvcBootstrapper = new MvcBootstrapper(Assembly.GetExecutingAssembly(),new MvcConventionalRegistrarConfig(true));
            mvcBootstrapper.Initialize();
            //应用服务模块依赖注册
            ServiceBootstrapper serviceBootstrapper = new ServiceBootstrapper();
            serviceBootstrapper.Initialize();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
