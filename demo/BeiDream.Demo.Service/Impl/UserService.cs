using System;
using System.Collections.Generic;
using System.Globalization;
using BeiDream.Core.Domain.Uow;
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

        public PagerList<UserDto> Query(UserQuery query)
        {
            return UserDomainService.Query(query).Convert(ToDto);
        }

        private UserDto ToDto(User entity)
        {
            return new UserDto()
            {
                Id=entity.Id,
                Name=entity.Name,
                Email=entity.Email,
                DisplayName=entity.DisplayName,
                Enabled=entity.Enabled,
                DateCreated = entity.DateCreated.ToChineseDateTimeString(true)
            };
        }
    }
}