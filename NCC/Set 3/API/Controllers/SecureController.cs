using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace set3_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "This is a secure endpoint!" });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return Ok(new { Message = "This is an admin-only endpoint!" });
        }
    }
}
