using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Web.Model;
using BeiDream.Web.Mvc;


namespace BeiDream.Demo.Web.Controllers
{
    public class SecurityController : OwnControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISignInManager _signInManager;

        public SecurityController(IUserService userService,ISignInManager signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if(model.ValidateCode!="8888")
                throw new Exception("验证码错误！");
            var user = _userService.Login(model.UserNameOrEmail, model.Password);
            if(user==null)
                throw new Exception("用户名或密码错误！");
            _signInManager.SignIn(user.Id.ToString(), model.RememberMe);
            return AjaxOkResponse("登陆成功！");
        }
        public ActionResult LogOut()
        {
            _signInManager.SignOut();
            return View("LogIn");
        }

    }
}