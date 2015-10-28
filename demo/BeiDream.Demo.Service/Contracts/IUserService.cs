using System;
using System.Collections.Generic;
using BeiDream.Core.Application.Services;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Contracts
{
    /// <summary>
    /// 用户应用服务接口
    /// </summary>
    public interface IUserService : IApplicationService
    {
        /// <summary>
        /// 设置角色
        /// </summary>
        /// <param name="userId">被设置角色的用户Id</param>
        /// <param name="roleIds">选择的角色集合</param>
        void SetRoles(Guid userId,List<Guid> roleIds);

        PagerList<UserDto> Query(UserQuery query);
    }
}