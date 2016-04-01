using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Datas;
using BeiDream.Core.Domain.Uow;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Service.Users.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Users
{
    /// <summary>
    /// 用户应用服务
    /// </summary>
    public class UserService:ServiceBase ,IUserService
    {
        /// <summary>
        ///用户领域服务
        /// </summary>
        private readonly IUserDomainService _userDomainService;

        private readonly IUserRepository _userRepository;

        public UserService(IUserDomainService userDomainService, IUserRepository userRepository)
        {
            _userDomainService = userDomainService;
            _userRepository = userRepository;
        }
        public void SetRoles(Guid userId, List<Guid> roleIds)
        {
            _userDomainService.SetRoles(userId, roleIds);
        }
        [NoUnitOfWork]
        //[DisableFiltersAttribute(FiltersEnum.SoftDelete)]   //示范：关闭数据过滤器(参数为过滤器名称列表)
        public PagerList<UserDto> Query(UserQuery query)
        {
            //todo：easyui组件的ajax请求异常，暂时无法拦截
            //throw new Exception("用户查询异常，easyui ajax操作全局异常测试");
            if (string.IsNullOrWhiteSpace(query.Order))   //分页必须先进行排序
                query.Order = "Id desc";
            query.TotalCount = _userRepository.GetAllFilterDataPermissions().Count();
            IQueryable<User> users = GetQueryConditions(_userRepository.GetAllFilterDataPermissions(), query)   //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                    .Skip(query.GetSkipCount())
                    .Take(query.PageSize);
            var result = new PagerList<User>(query);
            result.AddRange(users.ToList());
            return result.Convert(p => p.ToDto());
        }
        /// <summary>
        /// 构造前台传递的查询条件
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<User> GetQueryConditions(IQueryable<User> queryable, UserQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                queryable = queryable.Where(p => p.Name.Contains(query.Name));
            if (query.Enabled != null)
                queryable = queryable.Where(p => p.Enabled == query.Enabled);
            return queryable;
        }
        public void AddorUpdate(UserDto dto)
        {
            var entity = dto.ToEntity();
            //var query = _userRepository.GetAllAsNoTracking();
            //var model = query.SingleOrDefault(p => p.Id == entity.Id);
            var model = _userRepository.Find(entity.Id);
            if (model == null)
            {
                //AddBefore(entity);
                _userRepository.Add(entity);
            }
            else
            {
                //UpdateBefore(entity);
                //model.Id = entity.Id;
                model.Name = entity.Name;
                model.Password = entity.Password;
                model.DisplayName = entity.DisplayName;
                model.Email = entity.Email;
                model.Enabled = entity.Enabled;
                model.Version = entity.Version;
                _userRepository.Update(model);   //执行update，会触发乐观并发验证,  不执行只会更新，不会触发乐观并发验证
            }
        }

        [NoUnitOfWork]
        public UserDto Find(Guid id)
        {
            var user = _userRepository.Find(id);
            return user.ToDto();
        }

        public void Delete(Guid id)
        {
            var user = _userRepository.Find(id);
            if (user == null)
                throw new Exception("删除的用户不存在");
            _userRepository.Delete(user);
        }
        public UserDto Login(LoginInfoInput loginInfoInput)
        {
            var user = _userRepository.GetAll().FirstOrDefault(p => p.Name == loginInfoInput.UserNameOrEmail || p.Email == loginInfoInput.UserNameOrEmail);
            if (user == null)
                throw new Exception("用户名或邮箱错误");
            user.ValidateDisabled();
            user.ValidatePassword(loginInfoInput.Password);
            user.UpdateLoginSuccess();
            return user.ToDto();
        }
        ///// <summary>
        ///// 验证参数
        ///// </summary>
        //private void ValidateArgument(LoginInfoInput loginInfoInput)
        //{
        //    if (string.IsNullOrWhiteSpace(userNameOrEmail))
        //        throw new Exception("用户名或邮箱不能为空！");
        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new Exception("密码不能为空！");
        //}
    }
}