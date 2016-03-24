using BeiDream.Core.Domain.Entities;
using BeiDream.Data.Ef.EntityFramework.DynamicFilters;
using BeiDream.Utils.Logging;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BeiDream.Core.Domain.Datas;
using BeiDream.Core.Domain.Entities.Auditing;
using BeiDream.Core.Security;
using BeiDream.Utils;

namespace BeiDream.Data.Ef
{
    public class DbContextBase : DbContext
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(DbContextBase));

        public DbContextBase(string dbName)
            : base(dbName)
        {
            WriteLog();
        }

        public Guid TraceId { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter<ISoftDelete, bool>(FiltersEnum.SoftDelete.ToString(), entity => entity.IsDeleted, false);
        }
        public IDisposable DisableFilters(params string[] filterNames)
        {
            foreach (var filterName in filterNames)
            {
                this.DisableFilter(filterName);
            }
            return new DisposeAction(() => EnableFilters(filterNames));
        }

        private IDisposable EnableFilters(params string[] filterNames)
        {
            foreach (var filterName in filterNames)
            {
                this.EnableFilter(filterName);
            }
            return new DisposeAction(() => DisableFilters(filterNames));
        }
        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog()
        {
            Database.Log = log =>
            {
                Logger.Fatal(log);
            };
        }
        #region SaveChanges(保存更改)

        /// <summary>
        /// 保存更改
        /// </summary>
        public override sealed int SaveChanges()
        {
            SaveChangesBefore();
            var result = base.SaveChanges();
            return SaveChangesAfter(result);
        }

        /// <summary>
        /// 保存更改前操作
        /// </summary>
        protected virtual void SaveChangesBefore()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        InterceptAddedOperation(entry);
                        break;
                    case EntityState.Modified:
                        InterceptModifiedOperation(entry);
                        break;
                    case EntityState.Deleted:
                        InterceptDeletedOperation(entry);
                        break;
                }
            }
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        protected virtual void InterceptAddedOperation(DbEntityEntry entry)
        {
            InitCreationAudited(entry);
            InitModificationAudited(entry);
        }

        /// <summary>
        /// 初始化创建审计信息
        /// </summary>
        private void InitCreationAudited(DbEntityEntry entry)
        {
            if ((entry.Entity is ICreationAudited) == false)
                return;
            var result = entry.Cast<ICreationAudited>().Entity;
            result.CreationTime = DateTime.Now;
            result.CreatorUserId = GetApplicationSession().Name;
        }

        /// <summary>
        /// 获取应用程序上下文
        /// </summary>
        private IApplicationSession GetApplicationSession()
        {
            return ApplicationSession.Current ?? new ApplicationSession(false, "");
        }

        /// <summary>
        /// 初始化修改审计信息
        /// </summary>
        private void InitModificationAudited(DbEntityEntry entry)
        {
            if ((entry.Entity is IModificationAudited) == false)
                return;
            var result = entry.Cast<IModificationAudited>().Entity;
            result.LastModificationTime = DateTime.Now;
            result.LastModifierUserId = GetApplicationSession().Name;
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        protected virtual void InterceptModifiedOperation(DbEntityEntry entry)
        {
            InitModificationAudited(entry);
        }

        /// <summary>
        /// 拦截删除操作
        /// </summary>
        protected virtual void InterceptDeletedOperation(DbEntityEntry entry)
        {
        }

        /// <summary>
        /// 保存更改后操作
        /// </summary>
        /// <param name="result">影响的行数</param>
        protected virtual int SaveChangesAfter(int result)
        {
            return result;
        }

        #endregion
    }
}