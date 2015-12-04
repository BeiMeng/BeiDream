using BeiDream.Core.Application.Services;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Contracts
{
    public interface IResourceService : IApplicationService
    {
        PagerList<ResourceDto> Query(ResourceQuery query);
    }
}