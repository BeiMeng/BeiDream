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
        public IUserDomainService UserDomainService { get; set; }

        public UserService(IUserDomainService userDomainService)
        {
            UserDomainService = userDomainService;
        }

        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            UserDomainService.SetRoles(userId, roleIds);
        }

        [NoUnitOfWork]
        public PagerList<UserDto> Query(UserQuery query)
        {
            //throw new Exception("用户查询异常，easyui ajax操作全局异常测试");
            return UserDomainService.Query(query).Convert(p=>p.ToDto());
        }

        public void AddorUpdate(UserDto dto)
        {
            //throw new Exception("用户保存异常，Form表单提交全局异常测试");
            UserDomainService.AddorUpdate(dto.ToEntity());
        }

        [NoUnitOfWork]
        public UserDto Find(Guid id)
        {
            var user = UserDomainService.Find(id);
            return user.ToDto();
        }

        public void Delete(Guid id)
        {
            UserDomainService.Delete(id);
        }
    }
}