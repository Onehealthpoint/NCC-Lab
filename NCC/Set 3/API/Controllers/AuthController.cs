using Microsoft.AspNetCore.Mvc;
using set3_JWT.Models;
using set3_JWT.Services;

namespace set3_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var token = _authService.Authenticate(model);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }
    }
}
