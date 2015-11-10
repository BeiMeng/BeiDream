using BeiDream.Core.Linq.Extensions;
using BeiDream.Demo.Domain.Model;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Domain.Services.Contracts;
using BeiDream.Utils.PagerHelper;
using System;
using System.Linq;

namespace BeiDream.Demo.Domain.Services.Impl
{
    public class RoleDomainService : IRoleDomainService
    {
        /// <summary>
        ///角色仓储
        /// </summary>
        public IRoleRepository RoleRepository { get; set; }

        public RoleDomainService(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        public PagerList<Role> Query(RoleQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.Order))   //分页必须先进行排序
                query.Order = "Id desc";
            query.TotalCount = RoleRepository.GetAll().Count();
            IQueryable<Role> roles = GetQueryConditions(RoleRepository.GetAll(), query)   //where查询条件必须放在排序和分页前，不然生成SQL有BUG
                .OrderByIfOrderNullOrEmpty(query.Order)
                    .Skip(query.GetSkipCount())
                    .Take(query.PageSize);
            var result = new PagerList<Role>(query);
            result.AddRange(roles.ToList());
            return result;
        }

        /// <summary>
        /// 构造前台传递的查询条件
        /// </summary>
        /// <param name="queryable"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private IQueryable<Role> GetQueryConditions(IQueryable<Role> queryable, RoleQuery query)
        {
            if (!string.IsNullOrWhiteSpace(query.Name))
                queryable = queryable.Where(p => p.Name.Contains(query.Name));
            if (query.Enabled != null)
                queryable = queryable.Where(p => p.Enabled == query.Enabled);
            if (query.IsAdmin != null)
                queryable = queryable.Where(p => p.IsAdmin == query.IsAdmin);
            return queryable;
        }

        public void AddorUpdate(Role entity)
        {
            var model = RoleRepository.Find(entity.Id);
            if (model == null)
            {
                AddBefore(entity);
                RoleRepository.Add(entity);
            }
            else
            {
                UpdateBefore(entity);
                //model.Id = entity.Id;
                model.Name = entity.Name;
                model.Description = entity.Description;
                model.IsAdmin = entity.IsAdmin;
                model.Enabled = entity.Enabled;
                //model.Version = entity.Version;
            }
        }

        private void AddBefore(Role entity)
        {
            entity.DateCreated = DateTime.Now;
        }

        private void UpdateBefore(Role entity)
        {
            entity.DateUpdated = DateTime.Now;
        }

        public Role Find(Guid id)
        {
            return RoleRepository.Find(id);
        }

        public void Delete(Guid id)
        {
            var role = RoleRepository.Find(id);
            RoleRepository.Delete(role);
        }
    }
}