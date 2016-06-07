using Euro2016Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euro2016Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        protected readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(_homeService.GetHomeViewModel(User.Identity.Name, null));
        }
        [HttpPost("UpdateScore")]
        public IActionResult UpdateScore([FromBody]BetPostViewModel data)
        {
            _homeService.UpdateScore(data.MatchId, User.Identity.Name, data.IsOne, data.Value);
            return Ok();
        }
        [HttpPost("UpdateName")]
        public IActionResult UpdateName([FromBody]NamePostViewModel data)
        {
            _homeService.UpdateName(User.Identity.Name, data.Name);
            return Ok();
        }
    }
}
