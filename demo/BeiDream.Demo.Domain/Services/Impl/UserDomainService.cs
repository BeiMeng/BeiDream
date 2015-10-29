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
            query.TotalCount = UserRepository.GetAll().Count();
            IQueryable<User> users = GetQueryConditions(UserRepository.GetAll(), query)   //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                    .Skip(query.GetSkipCount())
                    .Take(query.PageSize);
            var result = new PagerList<User>(query);
            result.AddRange(users.ToList());
            return result;
        }
        /// <summary>
        /// 构造前台传递的查询条件
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<User> GetQueryConditions(IQueryable<User> queryable,UserQuery query)
        {
            if(!string.IsNullOrWhiteSpace(query.Name))
                queryable=queryable.Where(p => p.Name.Contains(query.Name));
            if(query.Enable!=null)
                queryable = queryable.Where(p => p.Enabled==query.Enable);
            return queryable;
        }
    }
}