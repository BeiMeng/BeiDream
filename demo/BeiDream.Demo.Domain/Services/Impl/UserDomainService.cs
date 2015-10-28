using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Utils.PagerHelper;

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
        public IUserRepository UserRepository { get; set; }

        public UserDomainService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            //var user = AccountRepository.Find(userId);
            //if(user==null)
            //    throw new Exception("设置用户不存在");
            ////先把用户的角色信息全删除
            //user.Roles.Clear();
            ////再添加新设置的角色信息
            //roleIds.ForEach(r => AccountRepository.Find(userId).Roles.Add(RoleRepository.Find(r)));
        }

        public PagerList<User> Query(UserQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Order))   //分页必须先进行排序
                query.Order = "Id desc";
            var result = new PagerList<User>(query);
            IQueryable<User> users =
                UserRepository.GetAll().OrderByIfOrderNullOrEmpty(query.Order)
                    .Skip(query.GetSkipCount())
                    .Take(query.PageSize);
            result.AddRange(users.ToList());
            return result;
        }
    }
}