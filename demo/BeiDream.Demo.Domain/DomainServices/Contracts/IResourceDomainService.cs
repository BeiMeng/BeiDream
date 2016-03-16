using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.DomainServices.Contracts
{
    public interface IResourceDomainService : IDomainService
    {
        /// <summary>
        /// 获取导航菜单模块
        /// </summary>
        /// <param name="userId">当前登录用户Id</param>
        /// <returns></returns>
        List<Resource> GetNavigationModule(Guid userId);

        /// <summary>
        /// 获取导航菜单某个模块的菜单树
        /// </summary>
        /// <param name="parentId">父Id</param>
        /// <param name="userId">当前登录用户Id</param>
        /// <returns></returns>
        List<Resource> GetNavigationMenuInModule(Guid parentId, Guid userId);
    }
}