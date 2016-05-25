using System.Web.Http;
using BeiDream.Utils.Logging;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BeiDream.Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            LogConfig.Initialize();
            ILogger logger = LogManager.GetLogger(typeof(MvcApplication));
            logger.Debug("网站启动");
            CastleConfig.Initialize();
            logger.Debug("依赖注入初始化完成");
            DatabaseConfig.Initialize();
            logger.Debug("数据库初始化完成");
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}