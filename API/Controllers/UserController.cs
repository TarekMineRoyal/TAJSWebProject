using Application.DTOs.User;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
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

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsersAsync();

        var userResponses = mapper.Map<IEnumerable<UserResponse>>(users);

        return Ok(userResponses);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var users = await userService.GetUserByIdAsync(id);

        var userResponses = mapper.Map<UserResponse>(users);

        return Ok(userResponses);
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpUserRequest signUpUserRequest)
    {
        var user = mapper.Map<User>(signUpUserRequest);

        user = await userService.AddUserAsync(user);

        var userResponse = mapper.Map<UserResponse>(user);

        return Ok(userResponse);
    }

    [HttpPost("LogIn")]
    public async Task<IActionResult> LogIn(string userName, string password)
    {
        var token = await userService.LogInAsync(userName, password);

        if(token != null)
        {
            return Ok(token);
        }

        return BadRequest();
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

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await userService.DeleteUserAsync(id);

        if(user != null)
        {
            var userResponse = mapper.Map<UserResponse>(user);

            return Ok(userResponse);
        }

        return BadRequest();
    }
}
