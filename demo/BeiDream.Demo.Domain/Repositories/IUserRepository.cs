using BeiDream.Core.Domain.Repositories;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Domain.Repositories
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}