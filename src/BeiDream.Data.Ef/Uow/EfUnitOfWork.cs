using System;
using BeiDream.Core.Domain.Uow;

namespace BeiDream.Data.Ef.Uow
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public EfUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public IDisposable DisableFilters(params string[] filterNames)
        {
           return _dbContext.DisableFilters(filterNames);
        }
    }
}