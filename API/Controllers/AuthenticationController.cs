using Application.DTOs.User;
using Application.IServices;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowReactApp")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationController(
            IAuthService authService,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _authService = authService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result.Succeeded)
            {

                /*var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var role = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;*/

                var token = _jwtTokenGenerator.GenerateToken();

                return Ok(token);
            }
            return BadRequest();

        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "You have logout of the system" });
        }
    }

}

