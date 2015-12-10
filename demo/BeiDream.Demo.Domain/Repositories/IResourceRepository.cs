using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.Core.Domain.Repositories;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Domain.Repositories
{
    /// <summary>
    /// 资源仓储接口
    /// </summary>
    public interface IResourceRepository : IRepository<Resource>
    {
        /// <summary>
        /// 根据父ID找到其下的子节点(只是子节点)
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IQueryable<Resource> GetChildrenNodes(Guid parentId);
        /// <summary>
        /// 根据父ID找到其下的所有节点(通过查找物理路径方式)
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IQueryable<Resource> GetAllNodes(Guid parentId);
    }
}