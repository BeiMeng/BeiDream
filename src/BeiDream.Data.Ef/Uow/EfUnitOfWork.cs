using System;
using System.Data.Entity;
using BeiDream.Core.Dependency;
using BeiDream.Core.Domain.Uow;
using Castle.MicroKernel.Lifestyle;

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