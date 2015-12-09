using System;
using System.Collections.Generic;
using BeiDream.Core.Application.Services;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Service.Contracts
{
    public interface IResourceService : IApplicationService
    {
        PagerList<ResourceDto> Query(ResourceQuery query);
        List<ResourceDto> QueryAll();
        ResourceDto Find(Guid id);
        void AddorUpdate(ResourceDto dto);
        /// <summary>
        /// 树形结构数据删除模式，节点删除，相应的它的所有子节点全部删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteTree(Guid id);
        /// <summary>
        ///查询角色数据
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <param name="roleId">角色ID,与此角色ID关联的资源checked属性设置为true</param>
        /// <returns></returns>
        PagerList<ResourceDto> Query(ResourceQuery query, Guid roleId);
        /// <summary>
        /// 获取导航菜单模块
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        List<ResourceDto> GetNavigationModule(Guid userId);
    }
}