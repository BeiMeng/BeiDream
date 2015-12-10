using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.Extensions;
using BeiDream.Utils.PagerHelper;
using System;
using System.Collections.Generic;
using BeiDream.AutoMapper;

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
        private readonly IUserDomainService _userDomainService;

        public UserService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            _userDomainService.SetRoles(userId, roleIds);
        }

        [NoUnitOfWork]
        public PagerList<UserDto> Query(UserQuery query)
        {
            //todo：easyui组件的ajax请求异常，暂时无法拦截
            //throw new Exception("用户查询异常，easyui ajax操作全局异常测试");
            return _userDomainService.Query(query).Convert(p => p.ToDto());
        }

        public void AddorUpdate(UserDto dto)
        {
            _userDomainService.AddorUpdate(dto.ToEntity());
        }

        [NoUnitOfWork]
        public UserDto Find(Guid id)
        {
            var user = _userDomainService.Find(id);
            return user.ToDto();
        }

        public void Delete(Guid id)
        {
            _userDomainService.Delete(id);
        }

        public UserDto Login(string userNameOrEmail, string password)
        {
            ValidateArgument(userNameOrEmail, password);
            return _userDomainService.Login(userNameOrEmail, password).ToDto();
        }
        /// <summary>
        /// 验证参数
        /// </summary>
        private void ValidateArgument(string userNameOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(userNameOrEmail))
                throw new Exception("用户名或邮箱不能为空！");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("密码不能为空！");
        }
    }
}