using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;
using System;
using System.Collections.Generic;

namespace BeiDream.Demo.Domain.Services.Contracts
{
    public interface IRoleDomainService : IDomainService
    {
        PagerList<Role> Query(RoleQuery query);

        void AddorUpdate(Role entity);

        Role Find(Guid id);

        void Delete(Guid id);
        /// <summary>
        /// 设置资源
        /// </summary>
        /// <param name="roleId">被设置资源的角色Id</param>
        /// <param name="resourceIds">选择的资源集合</param>
        void SetPermissions(Guid roleId, List<Guid> resourceIds);
    }
}