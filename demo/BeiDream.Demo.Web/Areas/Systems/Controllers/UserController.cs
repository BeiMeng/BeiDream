using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Demo.Service.Impl;
using BeiDream.Demo.Web.Areas.Systems.Models.User;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Systems/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(VmUserAddorEdit vm)
        {
            _userService.AddorUpdate(VmToDto(vm));
            return Json(new { Code = 1, Message = "保存成功！" });
        }

        private UserDto VmToDto(VmUserAddorEdit vm)
        {
            return new UserDto()
            {
                Id=vm.Id,
                Name=vm.Name,
                Password=vm.Password,
                DisplayName=vm.DisplayName,
                Email=vm.Email,
                Enabled=vm.Enabled,
                Version=vm.Version
            };
        }

        public PartialViewResult Edit(Guid id)
        {
            var dto = _userService.Find(id);
            return PartialView("Parts/Form", ToFormVm(dto));
        }
        private VmUserAddorEdit ToFormVm(UserDto dto)
        {
            return new VmUserAddorEdit(dto.Id)
            {
                Id = dto.Id,
                Name = dto.Name,
                Password=dto.Password,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                Version=dto.Version
            };
        }
        public PartialViewResult Add()
        {
            Guid addId = Guid.NewGuid();
            return PartialView("Parts/Form", new VmUserAddorEdit(addId));
        }
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            _userService.Delete(new Guid(ids));
            return Json(new { Code = 1, Message = "删除成功！" });
        }
        [HttpPost]
        public ActionResult Query(UserQuery query)
        {
            SetPage(query);
            var result = _userService.Query(query).Convert(ToVm);
            return Json(new { total = result.TotalCount, rows = result });
        }

        private VmUserGrid ToVm(UserDto dto)
        {
            return new VmUserGrid
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                DateCreated = dto.DateCreated
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
            var pageSize =Convert.ToInt32( Request["rows"]);
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