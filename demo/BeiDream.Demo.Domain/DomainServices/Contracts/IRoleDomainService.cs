using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Services;

namespace BeiDream.Demo.Domain.DomainServices.Contracts
{
    public interface IRoleDomainService : IDomainService
    {
        /// <summary>
        /// 设置资源
        /// </summary>
        /// <param name="roleId">被设置资源的角色Id</param>
        /// <param name="resourceIds">选择的资源集合</param>
        void SetPermissions(Guid roleId, List<Guid> resourceIds);
    }
}