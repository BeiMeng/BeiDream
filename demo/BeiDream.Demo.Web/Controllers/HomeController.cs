using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeiDream.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITaskService TaskService;
        public HomeController(ITaskService taskService)
        {
            TaskService = taskService;
        }

        public ActionResult Index()
        {
            string cc = TaskService.SaveTask("aa");
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