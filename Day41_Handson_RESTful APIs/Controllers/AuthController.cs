using ApiTestingDemo.Models;
using ApiTestingDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.Username == "admin" && model.Password == "admin123")
            {
                var token = _jwtService.GenerateToken(model.Username);

                return Ok(new
                {
                    message = "Login successful",
                    token = token
                });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
    }
}
