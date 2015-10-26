using BeiDream.Core.Application.Services;
using BeiDream.Demo.Service.Dtos;

namespace BeiDream.Demo.Service.Contracts
{
    public interface IRoleService : IApplicationService
    {
        void AddRole(RoleDto input);
    }
}