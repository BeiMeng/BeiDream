using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Domain.Repositories;
using BeiDream.Demo.Service;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Utils.Logging;

namespace BeiDream.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(HomeController));
        public ITaskMange TaskMange;
        public IAccountRepository AccountRepository;
        public IAccountService AccountService;
        public IRoleService RoleService;
        public HomeController(ITaskMange taskMang, IAccountRepository accountRepository, IAccountService accountService, IRoleService roleService)
        {
            AccountService = accountService;
            TaskMange = taskMang;
            AccountRepository = accountRepository;
            RoleService = roleService;
        }

        public ActionResult Index()
        {
            var aa = AccountRepository.GetAll().ToList().Count;
            string cc = TaskMange.TaskSave("aa");
            Logger.Debug(aa);
            Guid userId = new Guid("");
            List<Guid> roleIds = new List<Guid> { new Guid("") };
            AccountService.SetRoles(userId,roleIds);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}