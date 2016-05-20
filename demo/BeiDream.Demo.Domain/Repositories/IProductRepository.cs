using BeiDream.Core.Domain.Repositories;
using BeiDream.Demo.Domain.Model;

namespace BeiDream.Demo.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product,int>
    {
         
    }
}