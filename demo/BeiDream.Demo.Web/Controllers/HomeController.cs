using BeiDream.Utils.Logging;
using System.Collections.Generic;
using System.Web.Mvc;
using BeiDream.Demo.Web.Security.Authorization;

namespace BeiDream.Demo.Web.Controllers
{
    //[RoleAuthorize(true)]
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            Logger.Debug("访问首页");
            return View();
        }

        public ActionResult GetTree()
        {
            //var node = new TreeNode { Id = "1", text = "系统管理", state = "closed", children = new List<TreeNode>() { new TreeNode { Id = "2", ParentId = "1", state = "closed", text = "应用程序管理", attributes = new { url = "/systems/User" } } } };
            //var ss = JsonConvert.SerializeObject(node);
            return Content("[{\"id\":\"c5efa0ba-2260-3178-1b05-07c268cb8b5c\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"角色管理\",\"iconCls\":\"icon-man\",\"attributes\":{\"url\":\"/Systems/Role\"},\"children\":[]}" +
                           ",{\"id\":\"6e4f9cc7-2d4b-45c6-9ef2-eb5eafdaa49e\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"用户管理\",\"iconCls\":\"icon-more\",\"attributes\":{\"url\":\"/Systems/User\"},\"children\":[]}" +
                           ",{\"id\":\"6e4f9cc7-2d4b-45c6-9ef2-eb5eafdaa49e\",\"ParentId\":\"47ccd9a8-f834-45d7-9fd5-0ceba98e7d1a\",\"text\":\"资源管理\",\"iconCls\":\"icon-more\",\"attributes\":{\"url\":\"/Systems/Resource\"},\"children\":[]}]");
        }
    }

    public class TreeNode
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public object attributes { get; set; }
        public List<TreeNode> children { get; set; }
    }
}