using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace BeiDream.Demo.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            //启用属性路由,在Action上添加[Route("customers/{customerId}/orders/{orderId}")]则使用新定义的路由,如果不添加则使用默认路由
            config.MapHttpAttributeRoutes();

            //注册WebApi路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
