using System;
using BeiDream.Core.Application.Services;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Contracts
{
    public interface IRoleService : IApplicationService
    {
        PagerList<RoleDto> Query(RoleQuery query);
        void AddorUpdate(RoleDto dto);
        RoleDto Find(Guid id);
        void Delete(Guid id);
    }
}