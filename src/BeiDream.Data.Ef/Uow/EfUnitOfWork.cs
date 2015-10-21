using System;
using System.Data.Entity;
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
    }
}