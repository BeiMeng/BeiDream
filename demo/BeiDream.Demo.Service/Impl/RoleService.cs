using BeiDream.Core.Domain.Uow;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;

namespace BeiDream.Demo.Service.Impl
{

    public class RoleService : IRoleService
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        ///用户领域服务
        /// </summary>
        public IAccountManager AccountManager { get; set; }

        public RoleService(IUnitOfWork unitOfWork, IAccountManager accountManager)
        {
            UnitOfWork = unitOfWork;
            AccountManager = accountManager;
        }
    }
}