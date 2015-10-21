using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Uow;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;

namespace BeiDream.Demo.Service.Impl
{
    /// <summary>
    /// 用户应用服务
    /// </summary>
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 工作单元
        /// </summary>
        public IUnitOfWork UnitOfWork { get; set; }
        /// <summary>
        ///用户领域服务
        /// </summary>
        public IAccountManager AccountManager { get; set; }
        public AccountService(IUnitOfWork unitOfWork,IAccountManager accountManager)
        {
            UnitOfWork = unitOfWork;
            AccountManager = accountManager;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            AccountManager.SetRoles(userId,roleIds);
            UnitOfWork.Commit();
        }
    }
}