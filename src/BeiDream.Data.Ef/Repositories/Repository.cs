using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BeiDream.Core.Security;

namespace BeiDream.Data.Ef.Repositories
{
    public abstract class Repository<TAggregateRoot> : Repository<TAggregateRoot, Guid>
        where TAggregateRoot : class, IAggregateRoot<Guid>
    {
        protected Repository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }

    public abstract class Repository<TAggregateRoot, TKey> : IRepository<TAggregateRoot, TKey> where TAggregateRoot : class, IAggregateRoot<TKey>
    {
        protected IDbContext DbContext { get; private set; }
        /// <summary>
        /// 应用程序上下文
        /// </summary>
        protected IApplicationSession ApplicationSession;
        protected Repository(IDbContext dbContext)
        {
            ApplicationSession = GetApplicationContext();
            DbContext = dbContext;
        }

        private DbSet<TAggregateRoot> Set
        {
            get { return DbContext.Set<TAggregateRoot>(); }
        }

        public void Add(TAggregateRoot entity)
        {
            Set.Add(entity);
        }

        public void Update(TAggregateRoot entity)
        {
            AttachIfNot(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        #region 删除操作
        /// <summary>
        /// 删除单个实体集合
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TAggregateRoot entity)
        {
            Set.Remove(entity);
        }
        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Delete(IEnumerable<TAggregateRoot> entities)
        {
            if (entities == null)
                return;
            var list = entities.ToList();
            if (!list.Any())
                return;
            Set.RemoveRange(list);
        }
        public void Delete(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            var entities = Set.Where(predicate);
            Delete(entities);
        } 
        #endregion

        public TAggregateRoot Find(TKey id)
        {
            return Set.Find(id);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> GetAll()
        {
            return Set;
        }
        /// <summary>
        /// 获取过滤数据权限的所有数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TAggregateRoot> GetAllFilterDataPermissions()
        {
            if (ApplicationSession.IsAdmin)
                return Set;
            return Set.Where(GetDataPermissions());
        }
        /// <summary>
        /// 获取应用程序上下文
        /// </summary>
        protected IApplicationSession GetApplicationContext()
        {
            return ApplicationSession ?? (ApplicationSession = Core.Security.ApplicationSession.Current);
        }
        /// <summary>
        /// 获取数据权限查询条件
        /// </summary>
        protected virtual Expression<Func<TAggregateRoot, bool>> GetDataPermissions()
        {
            return p => true;   
        }

        protected virtual void AttachIfNot(TAggregateRoot entity)
        {
            if (!Set.Local.Contains(entity))
            {
                Set.Attach(entity);
            }
        }
    }
}