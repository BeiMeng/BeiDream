using BeiDream.Data.Ef;
using BeiDream.Data.Ef.Repositories;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Infrastructure.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}