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

    public RolePermission? AddPermissionToRole(RolePermission rolePermission)
    {
        rolePermission.Id = Guid.NewGuid().ToString();

        var returnedRolePermission = rolePermissionRepository.Add(rolePermission);

        rolePermissionRepository.SaveChanges();

        return returnedRolePermission;
    }

    public async Task<RolePermission?> AddPermissionToRoleAsync(RolePermission rolePermission)
    {
        rolePermission.Id = Guid.NewGuid().ToString();

        var returnedRolePermission = await rolePermissionRepository.AddAsync(rolePermission);

        await rolePermissionRepository.SaveChangesAsync();

        return returnedRolePermission;
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
        var rolePermissionIds = rolePermissionRepository.Where(x => x.RoleId == roleId.ToString());

        if (rolePermissionIds is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var permissionId in rolePermissionIds)
        {
            permissions.Add(permissionRepository.GetById(permissionId.PermissionId));
        }

        return permissions;
    }

    public async Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(Guid roleId)
    {
        var rolePermissions = await rolePermissionRepository.WhereAsync(x => x.RoleId == roleId.ToString());

        if (rolePermissions is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var rolePermission in rolePermissions)
        {
            permissions.Add(await permissionRepository.GetByIdAsync(rolePermission.PermissionId));
        }

        return permissions;
    }

    public async Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(string roleId)
    {
        var rolePermissions = await rolePermissionRepository.WhereAsync(x => x.RoleId == roleId.ToString());

        if (rolePermissions is null)
            return null;

        var permissions = new List<Permission>();

        foreach (var rolePermission in rolePermissions)
        {
            permissions.Add(await permissionRepository.GetByIdAsync(rolePermission.PermissionId));
        }

        return permissions;
    }

    public RolePermission? RemovePermissionFromRole(Guid id)
    {
        var returnedRolePermission = rolePermissionRepository.Remove(id);

        rolePermissionRepository.SaveChanges();

        return returnedRolePermission;
    }

    public async Task<RolePermission?> RemovePermissionFromRoleAsync(Guid id)
    {
        var returnedRolePermission = await rolePermissionRepository.RemoveAsync(id);

        await rolePermissionRepository.SaveChangesAsync();

        return returnedRolePermission;
    }
}
