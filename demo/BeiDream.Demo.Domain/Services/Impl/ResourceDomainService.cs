using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.Enums;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Services.Impl
{
    public class ResourceDomainService : IResourceDomainService
    {
        private readonly IUserRepository _userRepository;
        /// <summary>
        ///角色仓储
        /// </summary>
        public IResourceRepository ResourceRepository { get; set; }
        public ResourceDomainService(IResourceRepository resourceRepository,IUserRepository userRepository)
        {
            _userRepository = userRepository;
            ResourceRepository = resourceRepository;
        }

        public PagerList<Resource> Query(ResourceQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Order))   //分页必须先进行排序
                query.Order = "Id desc";
            query.TotalCount = ResourceRepository.GetAll().Count();
            IQueryable<Resource> roles = GetQueryConditions(ResourceRepository.GetAll(), query)   //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                    .Skip(query.GetSkipCount())
                    .Take(query.PageSize);
            var result = new PagerList<Resource>(query);
            result.AddRange(roles.ToList());
            return result;
        }

        public List<Resource> QueryAll()
        {
            return ResourceRepository.GetAll().ToList();
        }

        public Resource Find(Guid id)
        {
            return ResourceRepository.Find(id);
        }

        public void AddorUpdate(Resource entity)
        {
            var model = ResourceRepository.Find(entity.Id);
            Resource resourceParent = entity.ParentId == null ? null : ResourceRepository.Find((Guid)entity.ParentId);
            if (model == null)
            {
                entity.FixPathAndLevel(resourceParent);
                ResourceRepository.Add(entity);
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
                //model.Version = entity.Version;
            }
        }

        public void DeleteTree(Guid id)
        {
            var resource = ResourceRepository.Find(id);
            List<Resource> resources = ResourceRepository.GetAllNodes(id).ToList();
            ResourceRepository.Delete(resource);
            foreach (var item in resources)
            {
                ResourceRepository.Delete(item);
            }
        }

        public List<Resource> GetNavigationModule(Guid userId)
        {
            var user = _userRepository.Find(userId);
            if (user.Roles.Any(p => p.IsAdmin))  //用户角色含有超级管理员角色将加载全部导航模块
                return ResourceRepository.GetAll().Where(p => p.Type == ResourceType.Module && p.Enabled).ToList();
            return ResourceRepository.GetAll().Include(p=>p.Permissions).
                Where(item => item.Type == ResourceType.Module 
                    && item.Enabled && 
                    user.Roles.Any(role => item.Permissions.Any(p => p.RoleId == role.Id))).ToList();
            //List<Resource> li= list.Where(item => user.Roles.Any(role => item.Permissions.Any(p => p.RoleId == role.Id))).ToList();           
        }

        public List<Resource> GetNavigationMenuInModule(Guid parentId, Guid userId)
        {
            var user = _userRepository.Find(userId);
            if (user.Roles.Any(p => p.IsAdmin))  //用户角色含有超级管理员角色将加载当前导航模块下的所有菜单
                return ResourceRepository.GetAllNodes(parentId).Where(p=>p.Type==ResourceType.Menu).ToList();
            return ResourceRepository.GetAllNodes(parentId).Include(p => p.Permissions).
                Where(item => item.Type == ResourceType.Menu
                    && item.Enabled &&
                    user.Roles.Any(role => item.Permissions.Any(p => p.RoleId == role.Id))).ToList();
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
    }
}