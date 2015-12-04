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
            //throw new Exception("用户保存异常，Form表单提交全局异常测试");
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
    }
}