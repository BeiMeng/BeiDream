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
    public class UserService : IUserService
    {

        /// <summary>
        ///用户领域服务
        /// </summary>
        public IUserDomainService AccountDomainService { get; set; }
        public UserService(IUserDomainService accountDomainService)
        {
            AccountDomainService = accountDomainService;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            AccountDomainService.SetRoles(userId, roleIds);
        }
    }
}