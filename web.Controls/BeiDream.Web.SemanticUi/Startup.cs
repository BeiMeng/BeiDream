using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeiDream.Web.SemanticUi.Startup))]

namespace BeiDream.Web.SemanticUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}