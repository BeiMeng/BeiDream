using System;
using System.Collections.Generic;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Service.Users;
using BeiDream.Web.Api;

namespace BeiDream.Demo.Web.Controllers
{
    public class TestApiController : OwnApiController
    {
        private readonly IUserService _userService;
        //private readonly ISignInManager _signInManager;
        public TestApiController()
        {
        }
        public TestApiController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/TestApi
        public IEnumerable<string> Get()
        {
            var users = _userService.Find(Guid.NewGuid());
            return new string[] { "value1", "value2" };
        }
    }
}