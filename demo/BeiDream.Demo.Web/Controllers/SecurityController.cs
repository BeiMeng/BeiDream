using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Web.Model;


namespace BeiDream.Demo.Web.Controllers
{
    public class SecurityController : BeiDream.Web.Mvc.ControllerBase
    {
        // GET: Security
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult LogInA(LoginViewModel model)
        {
            return AjaxOkResponse("保存成功！");
        }

    }
}