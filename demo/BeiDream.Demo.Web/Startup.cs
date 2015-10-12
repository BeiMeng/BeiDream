using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeiDream.Demo.Web.Startup))]
namespace BeiDream.Demo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
