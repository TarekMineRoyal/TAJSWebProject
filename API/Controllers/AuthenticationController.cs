using Application.DTOs.User;
using Application.IServices;
using Application.Services;
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
        private readonly IUserService _userService;

        public AuthenticationController(
            IAuthService authService,
            IJwtTokenGenerator jwtTokenGenerator,
            IUserService userService)
        {
            _authService = authService;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            if (result.Succeeded)
            {
                var token = await _jwtTokenGenerator.GenerateToken(dto.Email);

                return Ok(token);
            }
            return BadRequest();

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterDto dto)
        {
            var user = _userService.GetByEmail(dto.Email);
            if (user is not null)
            {
                return BadRequest("User with this email is already exist.");
            }
            await _authService.RegisterAsync(dto);
            var token = await _jwtTokenGenerator.GenerateToken(dto.Email);

            return Ok(token);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "You have logout of the system" });
        }
    }

}

