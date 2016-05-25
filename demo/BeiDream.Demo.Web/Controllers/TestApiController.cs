using System;
using System.Collections.Generic;
using BeiDream.Core.Security.Authentication;
using BeiDream.Demo.Service.Users;
using BeiDream.Demo.Web.Security.Authorization;
using BeiDream.Web.Api;

namespace BeiDream.Demo.Web.Controllers
{
    [OwnApiAuthorize("aaa")]
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
            var users = _userService.Find(new Guid("5C42FF5F-49D4-4CDD-9DF3-0FAA2FE688C2"));
            return new string[] { "value1", "value2" };
        }
    }
}