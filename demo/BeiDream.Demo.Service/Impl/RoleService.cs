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
        ///用户领域服务
        /// </summary>
        public IRoleDomainService RoleDomainService { get; set; }

        public RoleService(IRoleDomainService roleDomainService)
        {
            RoleDomainService = roleDomainService;
        }

        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query)
        {
            return RoleDomainService.Query(query).Convert(p =>p.MapTo<RoleDto>());
        }

        public void AddorUpdate(RoleDto dto)
        {
            RoleDomainService.AddorUpdate(dto.MapTo<Role>());
        }

        [NoUnitOfWork]
        public RoleDto Find(Guid id)
        {
            var role = RoleDomainService.Find(id);
            return role.MapTo<RoleDto>();
        }

        public void Delete(Guid id)
        {
            RoleDomainService.Delete(id);
        }

        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query, Guid userId)
        {
            return RoleDomainService.Query(query).Convert(item => item.ToDto(userId));
        }
    }
}