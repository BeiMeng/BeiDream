using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.AutoMapper;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Core.Events.Bus.EventBus;
using BeiDream.Core.Events.Bus.EventData;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Service.Roles.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Roles
{
    public class RoleService : IRoleService
    {
        /// <summary>
        ///角色领域服务
        /// </summary>
        private readonly IRoleDomainService _roleDomainService;
        private readonly IRoleRepository _roleRepository;
        public IEventBus EventBus { get; set; }

        public RoleService(IRoleDomainService roleDomainService, IRoleRepository roleRepository)
        {
            _roleDomainService = roleDomainService;
            _roleRepository = roleRepository;
            EventBus = NullEventBus.Instance;
        }

        
        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query)
        {
            return PagerList(query).Convert(p => p.MapTo<RoleDto>());
        }

        private PagerList<Role> PagerList(RoleQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Order)) //分页必须先进行排序
                query.Order = "Id desc";
            query.TotalCount = _roleRepository.GetAll().Count();
            IQueryable<Role> roles = GetQueryConditions(_roleRepository.GetAll(), query) //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                .Skip(query.GetSkipCount())
                .Take(query.PageSize);
            var result = new PagerList<Role>(query);
            result.AddRange(roles.ToList());
            return result;
        }

        /// <summary>
        /// 构造前台传递的查询条件
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<Role> GetQueryConditions(IQueryable<Role> queryable, RoleQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                queryable = queryable.Where(p => p.Name.Contains(query.Name));
            if (query.Enabled != null)
                queryable = queryable.Where(p => p.Enabled == query.Enabled);
            if (query.IsAdmin != null)
                queryable = queryable.Where(p => p.IsAdmin == query.IsAdmin);
            return queryable;
        }
        public void AddorUpdate(RoleDto dto)
        {
            var entity = dto.MapTo<Role>();
            var model = _roleRepository.Find(entity.Id);
            if (model == null)
            {
                //AddBefore(entity);
                _roleRepository.Add(entity);
            }
            else
            {
                //UpdateBefore(entity);
                //model.Id = entity.Id;
                model.Name = entity.Name;
                model.Description = entity.Description;
                model.IsAdmin = entity.IsAdmin;
                model.Enabled = entity.Enabled;
                //model.Version = entity.Version;
            }
        }

        [NoUnitOfWork]
        public RoleDto Find(Guid id)
        {
            var role = _roleRepository.Find(id);
            return role.MapTo<RoleDto>();
        }

        public void Delete(Guid id)
        {
            var role = _roleRepository.Find(id);
            _roleRepository.Delete(role);
        }

        [NoUnitOfWork]
        public PagerList<RoleDto> Query(RoleQuery query, Guid userId)
        {
            return PagerList(query).Convert(item => item.ToDto(userId));
        }

        public void SetPermissions(Guid roleId, List<Guid> resourceIds)
        {
            EventBus.Trigger(new SetPermissionsCompletedEventData { RoleId = roleId });
            _roleDomainService.SetPermissions(roleId,resourceIds);
        }
    }

    public class SetPermissionsCompletedEventData : EventData
    {
        public Guid RoleId { get; set; }
    }
}