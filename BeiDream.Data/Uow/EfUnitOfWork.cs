using System;
using System.Data.Entity;
using BeiDream.Core.Domain.Uow;

namespace BeiDream.Data.Uow
{
    public class EfUnitOfWork : DbContext, IUnitOfWork 
    {
        /// <summary>
        /// 初始化Entity Framework工作单元
        /// </summary>
        /// <param name="connectionName">连接字符串的名称</param>
        protected EfUnitOfWork(string connectionName)
            : base(connectionName)
        {
            TraceId = Guid.NewGuid().ToString();

        }
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}