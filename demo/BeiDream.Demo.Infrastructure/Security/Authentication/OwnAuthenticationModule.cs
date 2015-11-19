using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BeiDream.Core.Dependency;
using BeiDream.Core.Security;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Domain.Repositories;

namespace BeiDream.Demo.Infrastructure.Security.Authentication
{
    public class OwnAuthenticationModule : AuthenticateModuleBase
    {
        protected override ApplicationSession CreateApplicationSession(string name)
        {
            ApplicationSession applicationSession = new ApplicationSession(true, name)
            {
                RoleIds = GetRolesIdByUserId(name).ToArray()
            };
            return applicationSession;
        }

        private List<string> GetRolesIdByUserId(string userId)
        {
            var userRepository = IocManager.Instance.Resolve<IUserRepository>();
            var user = userRepository.GetAll().Include(p => p.Roles).FirstOrDefault(p => p.Id == new Guid(userId));
            return user != null ? user.Roles.Select(role => role.Id.ToString()).ToList() : new List<string>();
            //if (userId == "admin")
            //    return new[] { "R1", "R2" };
            //if (userId == "aaa")
            //    return new[] { "R3", "R4" };
            //return null;
        }
    }
}