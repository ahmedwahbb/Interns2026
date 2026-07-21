using Microsoft.AspNetCore.Mvc;
using NorthWaveConsole.Application.DTOs;
using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        
        private const string DemoUsername = "admin";
        private const string DemoPassword = "Admin123!";

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            if (request.Username != DemoUsername || request.Password != DemoPassword)
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = _jwtTokenService.GenerateToken(request.Username);
            return Ok(new LoginResponse { Token = token });
        }
    }
}
