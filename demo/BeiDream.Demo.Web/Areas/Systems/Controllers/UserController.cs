using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Demo.Service.Impl;
using BeiDream.Demo.Web.Areas.Systems.Models.User;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
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
            return Json(new { Code = 1, Message = "保存成功！" });
        }
        public PartialViewResult Edit(Guid id)
        {
            return PartialView("Parts/Form", new VmUserAddorEdit(id){Name="AAAAA"});
        }
        public PartialViewResult Add()
        {
            Guid addId = Guid.NewGuid();
            return PartialView("Parts/Form", new VmUserAddorEdit(addId));
        }
        [HttpPost]
        public ActionResult Delete(string ids)
        {
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