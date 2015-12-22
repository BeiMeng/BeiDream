using System;
using System.Linq.Expressions;
using BeiDream.Core.Dependency;
using BeiDream.Core.Security.Authorization;
using BeiDream.Data.Ef;
using BeiDream.Data.Ef.Repositories;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Infrastructure.Repositories.DataPermissions.UserCriterias;
using BeiDream.Demo.Infrastructure.Security.Authorization;

namespace BeiDream.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
        /// <summary>
        /// 获取数据权限查询条件
        /// </summary>
        protected override Expression<Func<User, bool>> GetDataPermissions()
        {
            var userDataPermissionsManager =
                new UserDataPermissionsManager(new WebPermissionManager(new PermissionSupportService(),
                    false));
            return userDataPermissionsManager.GetPredicate();
        }
    }
}