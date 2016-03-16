using System;
using BeiDream.Utils.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BeiDream.AutoMapper;
using BeiDream.Demo.Service.Resources;
using BeiDream.Demo.Web.Areas.Systems.Models.Resource;
using BeiDream.Demo.Web.Security.Authorization;
using BeiDream.Web.Mvc;
using BeiDream.Web.Mvc.EasyUi.Tree;

namespace BeiDream.Demo.Web.Controllers
{
    [RoleAuthorize(true)]
    public class HomeController : OwnControllerBase
    {
        private readonly IResourceService _resourceService;
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        public HomeController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public ActionResult Index()
        {
            Logger.Debug("访问首页");
            return View();
        }
        /// <summary>
        /// 获取左侧导航模块
        /// </summary>
        /// <returns></returns>
        public ActionResult LeftNavigationModule()
        {
            Guid userId = new Guid(GetApplicationSession().Name);
            List<VmResourceTreeGrid> treeNodes = _resourceService.GetNavigationModule(userId).Select(p => p.MapTo<VmResourceTreeGrid>()).ToList();
            //////系统初始化登录,如果导航模块为0且是超级管理员登录，添加系统管理模块
            //List<VmResourceTreeGrid> treeNodes=new List<VmResourceTreeGrid>();
            //if(treeNodes.Count==0 && GetApplicationSession().IsAdmin)
            //    treeNodes.Add(new VmResourceTreeGrid() { Id = "47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a", Name = "系统模块", iconClass = "icon-man" });
            return PartialView("Part/Left", treeNodes);
        }
        /// <summary>
        /// 获取左侧导航某个模块下的菜单树页面
        /// </summary>
        /// <returns></returns>
        public ActionResult LeftNavigationMenusInModulePage(Guid parentId)
        {
            return PartialView("Part/MenuInModule", parentId);
        }
        /// <summary>
        /// 获取左侧导航某个模块下的菜单树数据
        /// </summary>
        /// <returns></returns>
        public ActionResult LeftNavigationMenusInModule(Guid parentId)
        {
            Guid userId = new Guid(GetApplicationSession().Name);
            List<VmResourceTreeGrid> treeNodes = _resourceService.GetNavigationMenuInModule(parentId, userId).Select(p => p.ToTreeGridVm()).ToList();
            //List<VmResourceTreeGrid> treeNodes = new List<VmResourceTreeGrid>();
            //if (treeNodes.Count == 0 && GetApplicationSession().IsAdmin)
            //    treeNodes.Add(new VmResourceTreeGrid() { Id = "c5efa0ba-2260-3178-1b05-07c268cb8b5c", Name = "资源管理", iconClass = "icon-man", attributes = new { url = "/Systems/Resource" } });
            return ToJsonResult(new EasyUiTreeData(treeNodes).GetNodes());
        }
        //public ActionResult GetTree()
        //{
        //    //var node = new TreeNode { Id = "1", text = "系统管理", state = "closed", children = new List<TreeNode>() { new TreeNode { Id = "2", ParentId = "1", state = "closed", text = "应用程序管理", attributes = new { url = "/systems/User" } } } };
        //    //var ss = JsonConvert.SerializeObject(node);
        //    return Content("[{\"id\":\"c5efa0ba-2260-3178-1b05-07c268cb8b5c\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"角色管理\",\"iconCls\":\"icon-man\",\"attributes\":{\"url\":\"/Systems/Role\"},\"children\":[]}" +
        //                   ",{\"id\":\"6e4f9cc7-2d4b-45c6-9ef2-eb5eafdaa49e\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"用户管理\",\"iconCls\":\"icon-more\",\"attributes\":{\"url\":\"/Systems/User\"},\"children\":[]}" +
        //                   ",{\"id\":\"6e4f9cc7-2d4b-45c6-9ef2-eb5eafdaa49e\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"资源管理\",\"iconCls\":\"icon-more\",\"attributes\":{\"url\":\"/Systems/Resource\"},\"children\":[]}]");
        //}
    }

    //public class TreeNode
    //{
    //    public string Id { get; set; }
    //    public string ParentId { get; set; }
    //    public string text { get; set; }
    //    public string state { get; set; }
    //    public object attributes { get; set; }
    //    public List<TreeNode> children { get; set; }
    //}
}