using BeiDream.Core.Domain.Uow;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;

namespace BeiDream.Demo.Service.Impl
{

    public class RoleService : IRoleService
    {
        /// <summary>
        ///用户领域服务
        /// </summary>
        public IUserDomainService UserDomainService { get; set; }

        public RoleService(IUserDomainService userDomainService)
        {
            UserDomainService = userDomainService;
        }

        public void AddRole(RoleDto input)
        {
            
        }
    }
}