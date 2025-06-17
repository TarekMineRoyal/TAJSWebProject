using Application.DTOs.Permission;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IPermissionService permissionService;

    public PermissionController(IMapper mapper, IPermissionService permissionService)
    {
        this.mapper = mapper;
        this.permissionService = permissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPermissions()
    {
        var permissions = await permissionService.GetAllPermissionsAsync();

        if(permissions == null) 
            return NoContent();

        var permissionResponses = mapper.Map<IEnumerable<PermissionResponse>>(permissions);

        return Ok(permissionResponses);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetPermissionById(Guid id)
    {
        var permission = await permissionService.GetPermissionByIdAsync(id);

        if(permission == null)
            return BadRequest();

        var permissionResponse = mapper.Map<PermissionResponse>(permission);

        return Ok(permissionResponse);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdatePermission(Guid id, UpdatePermissionRequest updatePermissionRequest)
    {
        var permission = mapper.Map<Permission>(updatePermissionRequest);

        permission = await permissionService.UpdatePermissionAsync(id, permission);

        if (permission == null)
            return BadRequest();

        var permissionResponse = mapper.Map<PermissionResponse>(permission);

        return Ok(permissionResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddPermission(AddPermissionRequest addPermissionRequest)
    {
        var permission = mapper.Map<Permission>(addPermissionRequest);

        permission = await permissionService.AddPermissionAsync(permission);

        if(permission == null)
            return BadRequest();

        var permissionResponse = mapper.Map<PermissionResponse>(permission);

        return Ok(permissionResponse);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeletePermission(Guid id)
    {
        var permission = await permissionService.RemovePermissionAsync(id);

        if(permission == null)
                return BadRequest();

        var permissionResponse = mapper.Map<PermissionResponse>(permission);

        return Ok(permissionResponse);
    }
}
