using System;
using System.Collections.Generic;
using System.Linq;
using BeiDream.Data.Ef;
using BeiDream.Data.Ef.Repositories;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Repositories;

namespace BeiDream.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// 资源仓储
    /// </summary>
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Resource> GetChildrenNodes(Guid parentId)
        {
            return this.GetAll().Where(p => p.ParentId == parentId).OrderBy(p => p.SortId);
        }

        public IQueryable<Resource> GetAllNodes(Guid parentId)
        {
            return this.GetAll().Where(p => p.Path.StartsWith(parentId.ToString()) && p.Id != parentId).OrderBy(p => p.SortId);
        }
    }
}