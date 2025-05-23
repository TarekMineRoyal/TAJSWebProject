using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class RolePermissionService : IRolePermissionService
{
    private readonly IRoleManagerRepository<RolePermission> rolePermissionRepository;
    private readonly IRoleManagerRepository<Permission> permissionRepository;

    public RolePermissionService(IRoleManagerRepository<RolePermission> rolePermissionRepository,
        IRoleManagerRepository<Permission> permissionRepository)
    {
        this.rolePermissionRepository = rolePermissionRepository;
        this.permissionRepository = permissionRepository;
    }

    public IEnumerable<Permission>? GetPermissionsByRoleId(Guid roleId)
    {
        var permissionIds = rolePermissionRepository.Where(x => x.RoleId == roleId.ToString());

        if(permissionIds is null) 
            return null;

        var permissions = new List<Permission>();

        foreach (var permissionId in permissionIds)
        {
            permissions.Add(permissionRepository.GetById(roleId));
        }

        return permissions;
    }

    public IEnumerable<Permission>? GetPermissionsByRoleId(string roleId)
    {
        var permissionIds = rolePermissionRepository.Where(x => x.RoleId == roleId.ToString());

        if (permissionIds is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var permissionId in permissionIds)
        {
            permissions.Add(permissionRepository.GetById(roleId));
        }

        return permissions;
    }

    public async Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(Guid roleId)
    {
        var permissionIds = await rolePermissionRepository.WhereAsync(x => x.RoleId == roleId.ToString());

        if (permissionIds is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var permissionId in permissionIds)
        {
            permissions.Add(await permissionRepository.GetByIdAsync(roleId));
        }

        return permissions;
    }

    public async Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(string roleId)
    {
        var permissionIds = await rolePermissionRepository.WhereAsync(x => x.RoleId == roleId.ToString());

        if (permissionIds is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var permissionId in permissionIds)
        {
            permissions.Add(await permissionRepository.GetByIdAsync(roleId));
        }

        return permissions;
    }
}
