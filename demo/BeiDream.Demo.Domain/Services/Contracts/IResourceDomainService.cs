using System;
using System.Collections.Generic;
using BeiDream.Core.Domain.Services;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Domain.Services.Contracts
{
    public interface IResourceDomainService : IDomainService
    {
        PagerList<Resource> Query(ResourceQuery query);
        List<Resource> QueryAll();
        Resource Find(Guid id);
        void AddorUpdate(Resource entity);
        /// <summary>
        /// 树形结构数据删除模式，节点删除，相应的它的所有子节点全部删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteTree(Guid id);
    }
}