using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Demo.Web.Areas.Systems.Models;
using BeiDream.Demo.Web.Areas.Systems.Models.Resource;
using BeiDream.Demo.Web.Security.Authorization;
using BeiDream.Utils.Reflection;
using BeiDream.Web.Mvc.EasyUi;
using BeiDream.Web.Mvc.EasyUi.Tree;
using Castle.Components.DictionaryAdapter;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    [RoleAuthorize(true)]
    public class ResourceController : EasyUiControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [RoleAuthorize]
        public ActionResult Index()
        {
            return View(new VmPermission());
        }
        public ActionResult QueryForm()
        {
            return PartialView("Parts/QueryForm", new ResourceQuery());
        }
        public ActionResult Query(ResourceQuery query)
        {
            SetPage(query);
            var result = _resourceService.Query(query).Convert(p => p.ToTreeGridVm());
            return ToDataTreeGridResult(result, false, result.TotalCount);
        }
        [RoleAuthorize]
        public PartialViewResult Add(string id)
        {
            return PartialView("Parts/Form", new VmResourceAddorEdit(id));
        }
        [RoleAuthorize]
        public PartialViewResult Edit(Guid id)
        {
            var dto = _resourceService.Find(id);
            return PartialView("Parts/Form", dto.MapTo<VmResourceAddorEdit>());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(VmResourceAddorEdit vm)
        {
            _resourceService.AddorUpdate(vm.MapTo<ResourceDto>());
            return AjaxOkResponse("保存成功！");
        }
        [RoleAuthorize]
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            _resourceService.DeleteTree(new Guid(ids));
            return AjaxOkResponse("删除成功！");
        }
        public ActionResult GetResources()
        {
            var list = _resourceService.QueryAll();
            List<VmResourceTreeGrid> dtos = list.Select(item => item.MapTo<VmResourceTreeGrid>()).ToList();
            return ToJsonResult(new EasyUiTreeData(dtos).GetNodes());
        }
        public ActionResult GetResourceTypes()
        {
            //todo，设计成通用的，传入枚举类型，自动生成下拉列表模式
            List<EasyUiCombobox> list=new List<EasyUiCombobox>();
            list.Add(new EasyUiCombobox() { value = "Module", text = "模块", group = "" });
            list.Add(new EasyUiCombobox() { value = "Menu", text = "菜单", group = "" });
            list.Add(new EasyUiCombobox() { value = "Operation", text = "操作(按钮)", group = "" });
            return ToJsonResult(list);
        }
        ///// <summary>
        /////获取分页的资源列表，以及查询的角色id的所拥有资源(权限)选中状态
        ///// </summary>
        ///// <param name="query"></param>
        ///// <param name="roleId"></param>
        ///// <returns></returns>
        //public ActionResult QueryByRole(ResourceQuery query, Guid roleId)
        //{
        //    SetPage(query);
        //    var result = _resourceService.Query(query, roleId).Convert(p => p.ToTreeGridVm());
        //    return ToDataTreeGridResult(result, false, result.TotalCount);
        //}
        /// <summary>
        ///获取分页的资源列表，以及查询的角色id的所拥有资源(权限)选中状态
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult QueryByRole(Guid roleId)
        {
            var list = _resourceService.QueryAll(roleId);
            List<VmResourceTreeGrid> dtos = list.Select(item => item.MapTo<VmResourceTreeGrid>()).ToList();
            return ToJsonResult(new EasyUiTreeData(dtos).GetNodes());
        }
    }
}