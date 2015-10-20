using System;
using System.Data.Entity;
using BeiDream.Core.Domain.Uow;

namespace BeiDream.Data.Ef.Uow
{
    public class EfUnitOfWork : IUnitOfWork 
    {
        private readonly IDbContext _dbContext;
        protected EfUnitOfWork(IDbContext dbContext)
        {
            TraceId = Guid.NewGuid().ToString();
            _dbContext = dbContext;
        }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; private set; }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}