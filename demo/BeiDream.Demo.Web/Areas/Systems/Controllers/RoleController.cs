using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Demo.Web.Areas.Systems.Models.Role;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        // GET: Systems/Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(VmRoleAddorEdit vm)
        {
            _roleService.AddorUpdate(VmToDto(vm));
            return Json(new { Code = 1, Message = "保存成功！" });
        }

        private RoleDto VmToDto(VmRoleAddorEdit vm)
        {
            return new RoleDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Description = vm.Description,
                IsAdmin = vm.IsAdmin,
                Enabled = vm.Enabled,
                Version = vm.Version
            };
        }

        public PartialViewResult Edit(Guid id)
        {
            var dto = _roleService.Find(id);
            return PartialView("Parts/Form", ToFormVm(dto));
        }
        private VmRoleAddorEdit ToFormVm(RoleDto dto)
        {
            return new VmRoleAddorEdit(dto.Id)
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsAdmin = dto.IsAdmin,
                Enabled = dto.Enabled,
                Version = dto.Version
            };
        }
        public PartialViewResult Add()
        {
            Guid addId = Guid.NewGuid();
            return PartialView("Parts/Form", new VmRoleAddorEdit(addId));
        }
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            _roleService.Delete(new Guid(ids));
            return Json(new { Code = 1, Message = "删除成功！" });
        }
        public ActionResult Query(RoleQuery query)
        {
            SetPage(query);
            var result = _roleService.Query(query).Convert(ToVm);
            return Json(new { total = result.TotalCount, rows = result });
        }
        public ActionResult QueryByUser(RoleQuery query,Guid userId)
        {
            SetPage(query);
            var result = _roleService.Query(query).Convert(ToVm);
            return Json(new { total = result.TotalCount, rows = result });
        }
        private VmRoleGrid ToVm(RoleDto dto)
        {
            return new VmRoleGrid
            {
                Id = dto.Id,
                Name = dto.Name,              
                IsAdmin=dto.IsAdmin,
                Enabled = dto.Enabled,
                DateCreated = dto.DateCreated,
                Checked=true
            };
        }
        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="query">查询实体</param>
        protected void SetPage(IPager query)
        {
            query.Page = GetPageIndex();
            query.PageSize = GetPageSize();
            query.Order = GetOrder();
        }
        /// <summary>
        /// 获取分页的页索引
        /// </summary>
        protected int GetPageIndex()
        {
            var page = Convert.ToInt32(Request["page"]);
            return page > 0 ? page : 1;
        }

        /// <summary>
        /// 获取分页大小
        /// </summary>
        protected int GetPageSize()
        {
            var pageSize = Convert.ToInt32(Request["rows"]);
            return pageSize > 0 ? pageSize : 20;
        }
        /// <summary>
        /// 获取排序
        /// </summary>
        protected string GetOrder()
        {
            return string.Format("{0} {1}", Convert.ToString(Request["sort"]), Convert.ToString(Request["order"]));
        }
    }
}