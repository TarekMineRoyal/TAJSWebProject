using Application.DTOs.User;
using Application.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public UserController(IMapper mapper, IUserService userService)
    {
        this.mapper = mapper;
        this.userService = userService;
    }

    [HttpPut]
    [Route("{id:guid}/email")]
    public async Task<IActionResult> ChangeEmail(Guid id, string email)
    {
        var user = await userService.ChangeEmailAsync(id, email);

        var userResponse = mapper.Map<UserResponse>(user);

        return Ok(userResponse);
    }

    [HttpPut]
    [Route("{id:guid}/password")]
    public async Task<IActionResult> ChangePassword(Guid id, string password)
    {
        var user = await userService.ChangePasswordAsync(id, password);

        var userResponse = mapper.Map<UserResponse>(user);

        return Ok(userResponse);
    }
}
