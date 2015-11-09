using System;
using System.Collections.Generic;
using System.Globalization;
using BeiDream.Core.Domain.Uow;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.Extensions;
using BeiDream.Utils.PagerHelper;

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
            throw new Exception("用户查询异常，全局异常测试");
            return UserDomainService.Query(query).Convert(ToDto);
        }
        private UserDto ToDto(User entity)
        {
            return new UserDto()
            {
                Id=entity.Id,
                Name=entity.Name,
                Password=entity.Password,
                Email=entity.Email,
                DisplayName=entity.DisplayName,
                Enabled=entity.Enabled,
                DateCreated = entity.DateCreated.ToChineseDateTimeString(true),
                Version=entity.Version
            };
        }
        public void AddorUpdate(UserDto dto)
        {
            throw new Exception("用户保存异常，全局异常测试");
            UserDomainService.AddorUpdate(ToEntity(dto));
        }
        private User ToEntity(UserDto dto)
        {
            return new User()
            {
                Id = dto.Id,
                Password=dto.Password,
                Name = dto.Name,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled.SafeValue(),
                Version = dto.Version
            };
        }
        [NoUnitOfWork]
        public UserDto Find(Guid id)
        {
            var user=UserDomainService.Find(id);
            return ToDto(user);
        }

        public void Delete(Guid id)
        {
            UserDomainService.Delete(id);
        }
    }
}