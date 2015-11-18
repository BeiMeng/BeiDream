using System.Linq;
using BeiDream.Core.Dependency;
using BeiDream.Core.Security;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Domain.Repositories;

namespace BeiDream.Demo.Service.Security.Authentication
{
    public class OwnAuthenticationModule : AuthenticateModuleBase
    {
        protected override ApplicationSession CreateApplicationSession(string name)
        {
            ApplicationSession applicationSession = new ApplicationSession(true, name)
            {
                RoleIds = GetRolesIdByUserId(name)
            };
            return applicationSession;
        }

        private string[] GetRolesIdByUserId(string userId)
        {
            var userRepository = IocManager.Instance.Resolve<IUserRepository>();
            if (userId == "admin")
                return new[] { "R1", "R2" };
            if (userId == "aaa")
                return new[] { "R3", "R4" };
            return null;
        }
    }
}