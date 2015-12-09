using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;
using System;
using System.Collections.Generic;

namespace BeiDream.Demo.Domain.Services.Contracts
{
    /// <summary>
    /// 用户领域服务接口
    /// </summary>
    public interface IUserDomainService : IDomainService
    {
        /// <summary>
        /// 设置角色
        /// </summary>
        /// <param name="userId">被设置角色的用户Id</param>
        /// <param name="roleIds">选择的角色集合</param>
        void SetRoles(Guid userId, List<Guid> roleIds);

        PagerList<User> Query(UserQuery query);

        void AddorUpdate(User entity);

        User Find(Guid id);

        void Delete(Guid id);
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userNameOrEmail">用户名或邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        User Login(string userNameOrEmail, string password);
    }
}