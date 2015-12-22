using System.Collections.Generic;
using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Repositories;
using BeiDream.Core.Security.Authorization;
using BeiDream.Core.Security.Criterias;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Infrastructure.Repositories.DataPermissions.UserCriterias
{
    /// <summary>
    /// 用户数据权限管理器
    /// </summary>
    public class UserDataPermissionsManager : PermissionCriteriaManagerBase<User>,ITransientDependency
    {
        public UserDataPermissionsManager(IPermissionManager permissionManager) : base(permissionManager)
        {
        }

        protected override void AddCriterias(ICollection<ICriteria<User>> criterias)
        {
            criterias.Add(new LookSelfCreateUsers(PermissionManager));
            criterias.Add(new LookSelfModifyUsers(PermissionManager));
        }
    }
}