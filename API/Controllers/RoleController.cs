using Application.DTOs.Role;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;

    public RoleController(IMapper mapper, IRoleService roleService)
    {
        _mapper = mapper;
        _roleService = roleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleService.GetAllRolesAsync();

        if (roles == null)
            return NoContent();

        var roleResponses = _mapper.Map<IEnumerable<RoleResponse>>(roles);

        return Ok(roleResponses);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var role = await _roleService.GetRoleByIdAsync(id);

        if (role == null)
            return NotFound();

        var roleResponse = _mapper.Map<RoleResponse>(role);

        return Ok(roleResponse);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateRole(Guid id, UpdateRoleRequest updateRoleRequest)
    {
        var role = _mapper.Map<Role>(updateRoleRequest);

        role = await _roleService.UpdateRoleAsync(id, role);

        if (role == null)
            return BadRequest();

        var roleResponse = _mapper.Map<RoleResponse>(role);

        return Ok(roleResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(AddRoleRequest addRoleRequest)
    {
        var role = _mapper.Map<Role>(addRoleRequest);

        role = await _roleService.AddRoleAsync(role);

        if (role == null)
            return BadRequest();

        var roleResponse = _mapper.Map<RoleResponse>(role);

        return Ok(roleResponse);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        var role = await _roleService.RemoveRoleAsync(id);

        if (role == null)
            return BadRequest();

        var roleResponse = _mapper.Map<RoleResponse>(role);

        return Ok(roleResponse);
    }
}