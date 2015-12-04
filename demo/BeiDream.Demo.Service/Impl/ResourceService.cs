using BeiDream.AutoMapper;
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

        public PagerList<ResourceDto> Query(ResourceQuery query)
        {
            return _resourceDomainService.Query(query).Convert(p => p.MapTo<ResourceDto>());
        }
    }
}