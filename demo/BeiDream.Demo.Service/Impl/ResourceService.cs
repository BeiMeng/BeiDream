using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.AutoMapper;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Domain.Services.Impl;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Impl
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceDomainService _resourceDomainService;

        public ResourceService(IResourceDomainService resourceDomainService)
        {
            _resourceDomainService = resourceDomainService;
        }
        [NoUnitOfWork]
        public PagerList<ResourceDto> Query(ResourceQuery query)
        {
            return _resourceDomainService.Query(query).Convert(p => p.MapTo<ResourceDto>());
        }
        [NoUnitOfWork]
        public List<ResourceDto> QueryAll()
        {
            var list = _resourceDomainService.QueryAll();
            List<ResourceDto> dtos= list.Select(item => item.MapTo<ResourceDto>()).ToList();
            return dtos;
        }
        [NoUnitOfWork]
        public ResourceDto Find(Guid id)
        {
            var role = _resourceDomainService.Find(id);
            return role.MapTo<ResourceDto>();
        }

        public void AddorUpdate(ResourceDto dto)
        {
            _resourceDomainService.AddorUpdate(dto.MapTo<Resource>());
        }

        public void DeleteTree(Guid id)
        {
            _resourceDomainService.DeleteTree(id);
        }
        [NoUnitOfWork]
        public PagerList<ResourceDto> Query(ResourceQuery query, Guid roleId)
        {
            return _resourceDomainService.Query(query).Convert(p => p.ToDto(roleId));
        }
        [NoUnitOfWork]
        public List<ResourceDto> GetNavigationModule(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}