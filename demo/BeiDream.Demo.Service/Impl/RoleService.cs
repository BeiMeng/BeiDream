using BeiDream.Core.Domain.Uow;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;

namespace BeiDream.Demo.Service.Impl
{

    public class RoleService : IRoleService
    {
        /// <summary>
        ///用户领域服务
        /// </summary>
        public IAccountDomainService AccountDomainService { get; set; }

        public RoleService( IAccountDomainService accountDomainService)
        {
            AccountDomainService = accountDomainService;
        }
    }
}