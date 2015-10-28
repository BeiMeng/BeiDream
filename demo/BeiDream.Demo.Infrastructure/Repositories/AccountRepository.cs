using BeiDream.Data.Ef;
using BeiDream.Data.Ef.Repositories;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Repositories;
namespace BeiDream.Demo.Infrastructure.Repositories
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class AccountRepository : Repository<Account>,IUserRepository
    {
        public AccountRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}