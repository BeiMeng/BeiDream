using System.Web;
using BeiDream.Demo.Service.Security.Authentication;
using BeiDream.Demo.Web.Security.Authentication;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

//启动注册
[assembly: PreApplicationStartMethod(typeof(AuthenticationModuleRegister), "Initialize")]
namespace BeiDream.Demo.Web.Security.Authentication
{
    public class AuthenticationModuleRegister
    {
        public static void Initialize()
        {
            DynamicModuleUtility.RegisterModule(typeof(OwnAuthenticationModule));
        }
    }
}