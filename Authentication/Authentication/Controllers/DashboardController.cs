using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        [Authorize(Roles ="Administrator")]
        [HttpGet("dashboard")]
        public IActionResult DashboardScreen()
        {
            return Ok("Dashboard Screen");
        }

        [Authorize(Roles = "User")]
        [HttpGet("userpanel")]
        public IActionResult UserScreen()
        {
            return Ok("User Panel Screen");
        }

        [HttpGet]
        public IActionResult General()
        {
            return Ok("General");
        }
    }
}
