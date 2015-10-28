using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Service.Impl;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: Systems/User
        public ActionResult Index()
        {
            return View();
        }
    }
}