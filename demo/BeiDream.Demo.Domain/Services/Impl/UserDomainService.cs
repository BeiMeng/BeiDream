using System;
using System.Collections.Generic;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Services.Contracts;

namespace BeiDream.Demo.Domain.Services.Impl
{
    /// <summary>
    /// 用户领域服务
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        /// <summary>
        ///角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }
        /// <summary>
        ///用户仓储
        /// </summary>
        public IUserRepository AccountRepository { get; set; }

        public UserDomainService(IUserRepository accountRepository, IRoleRepository roleRepository)
        {
            AccountRepository = accountRepository;
            RoleRepository = roleRepository;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            var user = AccountRepository.Find(userId);
            if(user==null)
                throw new Exception("设置用户不存在");
            //先把用户的角色信息全删除
            user.Roles.Clear();
            //再添加新设置的角色信息
            roleIds.ForEach(r => AccountRepository.Find(userId).Roles.Add(RoleRepository.Find(r)));
        }
    }
}