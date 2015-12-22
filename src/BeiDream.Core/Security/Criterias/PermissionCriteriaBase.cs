using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BeiDream.Core.Domain.Entities;
using BeiDream.Core.Domain.Repositories;
using BeiDream.Core.ExpressionHelper.Extensions;
using BeiDream.Core.Security.Authorization;

namespace BeiDream.Core.Security.Criterias {
    /// <summary>
    /// 权限查询条件
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class PermissionCriteriaBase<T> : ICriteria<T> where T : class, IAggregateRoot{
        /// <summary>
        /// 初始化权限查询条件
        /// </summary>
        /// <param name="permissionManager">权限管理器</param>
        protected PermissionCriteriaBase( IPermissionManager permissionManager ) {
            PermissionManager = permissionManager;
            _criterias = new List<ICriteria<T>>();
        }

        /// <summary>
        /// 权限管理器
        /// </summary>
        protected IPermissionManager PermissionManager { get; set; }
        /// <summary>
        /// 应用程序上下文
        /// </summary>
        protected IApplicationSession ApplicationSession;

        /// <summary>
        /// 查询条件集合
        /// </summary>
        private readonly ICollection<ICriteria<T>> _criterias;
        /// <summary>
        /// 获取应用程序上下文
        /// </summary>
        protected virtual IApplicationSession GetApplicationContext()
        {
            return ApplicationSession ?? (ApplicationSession = Security.ApplicationSession.Current);
        }

        /// <summary>
        /// 添加包含的查询范围条件
        /// </summary>
        /// <param name="childCriteria">包含的查询范围条件</param>
        public void Add( ICriteria<T> childCriteria ) {
            if ( childCriteria == null )
                return;
            _criterias.Add( childCriteria );
        }

        /// <summary>
        /// 获取谓词
        /// </summary>
        public Expression<Func<T, bool>> GetPredicate() {
            if( Authenticate() )
                return CreatePredicate();
            return GetChildsPredicate();
        }

        /// <summary>
        /// 授权
        /// </summary>
        private bool Authenticate() {
            return PermissionManager.HasPermission( GetPermissionCode() );
        }

        /// <summary>
        /// 获取权限编码
        /// </summary>
        protected abstract string GetPermissionCode();

        /// <summary>
        /// 创建谓词
        /// </summary>
        protected abstract Expression<Func<T, bool>> CreatePredicate();

        /// <summary>
        /// 获取子范围条件谓词
        /// </summary>
        private Expression<Func<T, bool>> GetChildsPredicate() {
            Expression<Func<T, bool>> predicate = null;
            foreach ( var criteria in _criterias )
                predicate = predicate.Or( criteria.GetPredicate() );
            return predicate;
        }
    }
}
