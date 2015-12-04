using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.AutoMapper;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Web.Areas.Systems.Models.Resource;
using BeiDream.Web.Mvc.EasyUi;
using Castle.Components.DictionaryAdapter;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class ResourceController : EasyUiControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        // GET: Systems/Resource
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Query(ResourceQuery query)
        {
            SetPage(query);
            var result = _resourceService.Query(query).Convert(p => p.MapTo<VmResourceTreeGrid>());

            //List<VmResourceTreeGrid> li = new List<VmResourceTreeGrid>();
            //List<VmResourceTreeGrid> li2 = new List<VmResourceTreeGrid>();
            //List<VmResourceTreeGrid> li3 = new List<VmResourceTreeGrid>();
            //VmResourceTreeGrid v1=new VmResourceTreeGrid();
            //v1.Id = Guid.NewGuid().ToString();
            //v1.Name = "系统管理";
            //v1.Uri = "xtgl";
            //v1.Type = "模块";
            //v1.state = "closed";
            //v1.Enabled = true;
            //v1.DateCreated = DateTime.Now;
            //v1.children = li2;
            //li.Add(v1);
            //VmResourceTreeGrid v2 = new VmResourceTreeGrid();
            //v2.Id = Guid.NewGuid().ToString();
            //v2.Name = "应用管理";
            //v2.Uri = "yygl";
            //v2.Type = "模块";
            //v2.state = "closed";
            //v2.Enabled = true;
            //v2.DateCreated = DateTime.Now;
            //v2.children = li3;
            //li.Add(v2);
            //VmResourceTreeGrid item5 = new VmResourceTreeGrid();
            //item5.Id = Guid.NewGuid().ToString();
            //item5.Name = "资源管理";
            //item5.Type = "菜单";
            //item5.Uri = "/Systems/Resource";
            //item5.state = "closed";
            //item5.Enabled = true;
            //item5.DateCreated = DateTime.Now;
            //item5.children = null;
            //li2.Add(item5);

            //VmResourceTreeGrid item = new VmResourceTreeGrid();
            //item.Id = Guid.NewGuid().ToString();
            //item.Name = "用户管理";
            //item.Type = "菜单";
            //item.Uri = "/Systems/User";
            //item.state = "closed";
            //item.Enabled = true;
            //item.DateCreated = DateTime.Now;
            //item.children = null;
            //li3.Add(item);
            //VmResourceTreeGrid item2 = new VmResourceTreeGrid();
            //item2.Id = Guid.NewGuid().ToString();
            //item2.Name = "角色管理";
            //item2.Uri = "/Systems/Role";
            //item2.Type = "菜单";
            //item2.state = "closed";
            //item2.Enabled = true;
            //item2.DateCreated = DateTime.Now;
            //item2.children = null;
            //li3.Add(item2);
            return ToDataTreeGridResult(result, true, result.TotalCount);
            //return ToDataGridResult(li, 5);
        }
    }
}