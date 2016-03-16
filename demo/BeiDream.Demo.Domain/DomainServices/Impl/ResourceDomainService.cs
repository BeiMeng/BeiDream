using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.DomainServices.Contracts;
using BeiDream.Demo.Domain.Enums;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.DomainServices.Impl
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

        public List<Resource> GetNavigationModule(Guid userId)
        {
            var user = _userRepository.Find(userId);
            if (user.Roles.Any(p => p.IsAdmin))  //用户角色含有超级管理员角色将加载全部导航模块
                return ResourceRepository.GetAll().Where(p => p.Type == ResourceType.Module && p.Enabled).ToList();
            //todo:以下代码有待改进
            var list= ResourceRepository.GetAll().Include(p=>p.Permissions).
                Where(item => item.Type == ResourceType.Module 
                    && item.Enabled).ToList();
            List<Resource> li= list.Where(item => user.Roles.Any(role => item.Permissions.Any(p => p.RoleId == role.Id))).ToList();
            return li;
        }

        public List<Resource> GetNavigationMenuInModule(Guid parentId, Guid userId)
        {
            var user = _userRepository.Find(userId);
            if (user.Roles.Any(p => p.IsAdmin))  //用户角色含有超级管理员角色将加载当前导航模块下的所有菜单
                return ResourceRepository.GetAllNodes(parentId).Where(p=>p.Type==ResourceType.Menu).ToList();
            //todo:以下代码有待改进
            var list = ResourceRepository.GetAllNodes(parentId).Include(p => p.Permissions).
                Where(item => item.Type == ResourceType.Menu
                    && item.Enabled).ToList();
            List<Resource> li = list.Where(item => user.Roles.Any(role => item.Permissions.Any(p => p.RoleId == role.Id))).ToList();
            return li;
        }
    }
}