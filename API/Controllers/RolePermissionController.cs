using Application.DTOs.Permission;
using Application.DTOs.RolePermission;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolePermissionController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRolePermissionService _rolePermissionService;

    public RolePermissionController(IMapper mapper, IRolePermissionService rolePermissionService)
    {
        _mapper = mapper;
        _rolePermissionService = rolePermissionService;
    }

    [HttpGet("{roleId:guid}/permissions")]
    public async Task<IActionResult> GetPermissionsByRoleId(Guid roleId)
    {
        var permissions = await _rolePermissionService.GetPermissionsByRoleIdAsync(roleId);

        if (permissions == null)
            return NoContent();

        var permissionResponses = _mapper.Map<IEnumerable<PermissionResponse>>(permissions);
        return Ok(permissionResponses);
    }

    [HttpPost]
    public async Task<IActionResult> AddPermissionToRole([FromBody] AddRolePermissionRequest request)
    {
        var rolePermission = _mapper.Map<RolePermission>(request);
        var result = await _rolePermissionService.AddPermissionToRoleAsync(rolePermission);

        if (result == null)
            return BadRequest("Failed to add permission to role");

        var response = _mapper.Map<RolePermissionResponse>(result);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemovePermissionFromRole(Guid id)
    {
        var result = await _rolePermissionService.RemovePermissionFromRoleAsync(id);

        if (result == null)
            return BadRequest("Failed to remove permission from role");

        var response = _mapper.Map<RolePermissionResponse>(result);
        return Ok(response);
    }
}