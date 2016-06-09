using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euro2016Web.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Euro2016Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetTop()
        {
            return new ObjectResult(_userService.GetTop(10));
        }
    }
}
