using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;
using System;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Service.Impl
{
    public class RoleService : IRoleService
    {
        /// <summary>
        ///角色领域服务
        /// </summary>
        private readonly IRoleDomainService _roleDomainService;

        public RoleService(IRoleDomainService roleDomainService)
        {
            _roleDomainService = roleDomainService;
        }

        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query)
        {
            return _roleDomainService.Query(query).Convert(p => p.MapTo<RoleDto>());
        }

        public void AddorUpdate(RoleDto dto)
        {
            _roleDomainService.AddorUpdate(dto.MapTo<Role>());
        }

        [NoUnitOfWork]
        public RoleDto Find(Guid id)
        {
            var role = _roleDomainService.Find(id);
            return role.MapTo<RoleDto>();
        }

        public void Delete(Guid id)
        {
            _roleDomainService.Delete(id);
        }

        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query, Guid userId)
        {
            return _roleDomainService.Query(query).Convert(item => item.ToDto(userId));
        }
    }
}