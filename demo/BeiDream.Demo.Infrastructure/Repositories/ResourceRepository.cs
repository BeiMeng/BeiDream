using System;
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

    }
}