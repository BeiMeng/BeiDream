using BeiDream.Core.Security;
using BeiDream.Core.Security.Authentication;

namespace BeiDream.Demo.Service.Security.Authentication
{
    public class OwnAuthenticationModule : AuthenticateModuleBase
    {
        protected override ApplicationSession CreateApplicationSession(string name)
        {
            ApplicationSession applicationSession=new ApplicationSession(true,name);
            if (name == "admin")
                applicationSession.RoleIds = new[] {"R1", "R2"};
            if (name == "aaa")
                applicationSession.RoleIds = new[] { "R3", "R4" };
            return applicationSession;
        }
    }
}