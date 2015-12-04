using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Services.Contracts
{
    public interface IResourceDomainService : IDomainService
    {
        PagerList<Resource> Query(ResourceQuery query);
    }
}