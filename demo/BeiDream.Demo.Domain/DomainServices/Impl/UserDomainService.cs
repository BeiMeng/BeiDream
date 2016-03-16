using System;
using System.Collections.Generic;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Repositories;

namespace BeiDream.Demo.Domain.DomainServices.Impl
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
        public IUserRepository UserRepository { get; set; }

        public UserDomainService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            var user = UserRepository.Find(userId);
            if (user == null)
                throw new Exception("设置用户不存在");
            //先把用户的角色信息全删除
            user.Roles.Clear();
            //再添加新设置的角色信息
            roleIds.ForEach(r => user.Roles.Add(RoleRepository.Find(r)));
        }
    }
}