using BeiDream.Demo.Web.Security.Authentication;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

//注册
[assembly: OwinStartup( typeof( OwinConfig ) )]

namespace BeiDream.Demo.Web.Security.Authentication {
    /// <summary>
    /// Owin配置
    /// </summary>
    public class OwinConfig {
        /// <summary>
        /// 配置
        /// </summary>
        public void Configuration( IAppBuilder app ) {
            //使用cookie存储安全信息
            app.UseCookieAuthentication( new CookieAuthenticationOptions {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Security/LogIn")
            } );
        }
    }
}
