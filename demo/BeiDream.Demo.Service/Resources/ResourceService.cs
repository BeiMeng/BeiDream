using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.AutoMapper;
using BeiDream.Core.Domain.Datas;
using BeiDream.Core.Domain.Uow.Interception;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Service.Resources.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Resources
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceDomainService _resourceDomainService;
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceDomainService resourceDomainService, IResourceRepository resourceRepository)
        {
            _resourceDomainService = resourceDomainService;
            _resourceRepository = resourceRepository;
        }
       [NoUnitOfWork]
        public PagerList<ResourceDto> Query(ResourceQuery query)
       {
           return PagerList(query).Convert(p => p.MapTo<ResourceDto>());
       }

        private PagerList<Resource> PagerList(ResourceQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Order)) //分页必须先进行排序
                query.Order = "Id desc";
            query.TotalCount = _resourceRepository.GetAll().Count();
            IQueryable<Resource> roles = GetQueryConditions(_resourceRepository.GetAll(), query)
                //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                .Skip(query.GetSkipCount())
                .Take(query.PageSize);
            var result = new PagerList<Resource>(query);
            result.AddRange(roles.ToList());
            return result;
        }

        /// <summary>
       /// 构造前台传递的查询条件
       /// </summary>
       /// <param name="queryable"></param>
       /// <param name="query"></param>
       /// <returns></returns>
       private IQueryable<Resource> GetQueryConditions(IQueryable<Resource> queryable, ResourceQuery query)
       {
           if (!string.IsNullOrWhiteSpace(query.Name))
               queryable = queryable.Where(p => p.Name.Contains(query.Name));
           if (query.Enabled != null)
               queryable = queryable.Where(p => p.Enabled == query.Enabled);
           return queryable;
       }
        [NoUnitOfWork]
        public List<ResourceDto> QueryAll()
        {
            var list = _resourceRepository.GetAll().ToList();
            List<ResourceDto> dtos= list.Select(item => item.MapTo<ResourceDto>()).ToList();
            return dtos;
        }
        [NoUnitOfWork]
        public List<ResourceDto> QueryAll(Guid roleId)
        {
            var list = _resourceRepository.GetAll().ToList();
            List<ResourceDto> dtos = list.Select(item => item.ToDto(roleId)).ToList();
            return dtos;
        }

        [NoUnitOfWork]
        public ResourceDto Find(Guid id)
        {
            var role = _resourceRepository.Find(id);
            return role.MapTo<ResourceDto>();
        }

        public void AddorUpdate(ResourceDto dto)
        {
            var entity = dto.MapTo<Resource>();
            //var query = _resourceRepository.GetAllAsNoTracking();
            //var model = query.SingleOrDefault(p => p.Id == entity.Id);
            var model = _resourceRepository.Find(entity.Id);
            Resource resourceParent = entity.ParentId == null ? null : _resourceRepository.Find((Guid)entity.ParentId);
            if (model == null)
            {
                entity.FixPathAndLevel(resourceParent);
                _resourceRepository.Add(entity);
            }
            else
            {
                model.FixPathAndLevel(resourceParent);
                //model.Id = entity.Id;
                model.ApplicationId = entity.ApplicationId;
                model.ParentId = entity.ParentId;
                model.Name = entity.Name;
                //model.Path = entity.Path;
                //model.Level = entity.Level;
                model.SortId = entity.SortId;
                model.Uri = entity.Uri;
                model.Type = entity.Type;
                model.Enabled = entity.Enabled;
                model.Version = entity.Version;
                _resourceRepository.Update(model);  
            }
        }


        public void DeleteTree(Guid id)
        {
            var resource = _resourceRepository.Find(id);
            List<Resource> resources = _resourceRepository.GetAllNodes(id).ToList();
            _resourceRepository.Delete(resource);
            foreach (var item in resources)
            {
                _resourceRepository.Delete(item);
            }
        }
        [NoUnitOfWork]
        public PagerList<ResourceDto> Query(ResourceQuery query, Guid roleId)
        {
            return PagerList(query).Convert(p => p.ToDto(roleId));
        }
        [NoUnitOfWork]
        public List<ResourceDto> GetNavigationModule(Guid userId)
        {
            return _resourceDomainService.GetNavigationModule(userId).Select(item => item.MapTo<ResourceDto>()).ToList();
        }
        [NoUnitOfWork]
        public List<ResourceDto> GetNavigationMenuInModule(Guid parentId, Guid userId)
        {
            return _resourceDomainService.GetNavigationMenuInModule(parentId, userId).Select(item => item.MapTo<ResourceDto>()).ToList();
        }
    }
}