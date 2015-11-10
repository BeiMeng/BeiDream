using BeiDream.Core.Application.Services;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;
using System;

namespace BeiDream.Demo.Service.Contracts
{
    public interface IRoleService : IApplicationService
    {
        PagerList<RoleDto> Query(RoleQuery query);

        void AddorUpdate(RoleDto dto);

        RoleDto Find(Guid id);

        void Delete(Guid id);

        /// <summary>
        ///查询角色数据
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="userId">用户ID,与此用户ID关联的角色checked属性设置为true</param>
        /// <returns></returns>
        PagerList<RoleDto> Query(RoleQuery query, Guid userId);
    }
}