using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Web.Areas.Systems.Models.Role;
using BeiDream.Web.Mvc.EasyUi;
using System;
using System.Web.Mvc;
using BeiDream.AutoMapper;
using BeiDream.Demo.Service.Roles;
using BeiDream.Demo.Service.Roles.Dtos;
using BeiDream.Demo.Web.Areas.Systems.Models;
using BeiDream.Demo.Web.Security.Authorization;
using BeiDream.Utils;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    [RoleAuthorize(true)]
    public class RoleController : EasyUiControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        #region 增删改查
        [RoleAuthorize]
        public ActionResult Index()
        {
            return View(new VmPermission());
        }
        public ActionResult QueryForm()
        {
            return PartialView("Parts/QueryForm", new RoleQuery());
        }

        public ActionResult Query(RoleQuery query)
        {
            SetPage(query);
            var result = _roleService.Query(query).Convert(p => p.ToGridVm());
            return ToDataGridResult(result, result.TotalCount);
        }
        [RoleAuthorize]
        public PartialViewResult Add()
        {
            Guid addId = Guid.NewGuid();
            return PartialView("Parts/Form", new VmRoleAddorEdit(addId));
        }
        [RoleAuthorize]
        public PartialViewResult Edit(Guid id)
        {
            var dto = _roleService.Find(id);
            return PartialView("Parts/Form", dto.MapTo<VmRoleAddorEdit>());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(VmRoleAddorEdit vm)
        {
            _roleService.AddorUpdate(vm.MapTo<RoleDto>());
            return AjaxOkResponse("保存成功！");
        }
        [RoleAuthorize]
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            _roleService.Delete(new Guid(ids));
            return AjaxOkResponse("删除成功！");
        }

        #endregion 增删改查

        /// <summary>
        ///获取分页的角色列表，以及查询的用户id的所有角色选中状态
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult QueryByUser(RoleQuery query, Guid userId)
        {
            SetPage(query);
            var result = _roleService.Query(query, userId).Convert(p => p.ToGridVm());
            return ToDataGridResult(result, result.TotalCount);
        }

        /// <summary>
        /// 显示设置界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [RoleAuthorize]
        public PartialViewResult EditResources(Guid id)
        {
            return PartialView("Parts/RolePermissions", id);
        }
        /// <summary>
        /// 保存用户操作的资源设置信息
        /// </summary>
        /// <param name="roleId">当前设置的角色id</param>
        /// <param name="ids">选中的资源id集合</param>
        /// <returns></returns>
        public ActionResult SetPermissions(Guid roleId, string ids)
        {
            _roleService.SetPermissions(roleId, ConvertHelper.ToList<Guid>(ids));
            return AjaxOkResponse("保存成功！");
        }
    }
}