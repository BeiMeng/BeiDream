using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Web.Model;
using BeiDream.Web.Mvc;


namespace BeiDream.Demo.Web.Controllers
{
    public class SecurityController : OwnControllerBase
    {
        private readonly ISignInManager _signInManager;

        public SecurityController(ISignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            _signInManager.SignIn(model.UserName,model.RememberMe);
            return AjaxOkResponse("登陆成功！");
        }
        public ActionResult LogOut()
        {
            _signInManager.SignOut();
            return View("LogIn");
        }

    }
}