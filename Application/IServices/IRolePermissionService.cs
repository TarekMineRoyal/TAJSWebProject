using Domain.Entities;

namespace Application.IServices;

public interface IRolePermissionService
{
    public IEnumerable<Permission>? GetPermissionsByRoleId(Guid roleId);

    public IEnumerable<Permission>? GetPermissionsByRoleId(string roleId);

    public RolePermission? AddPermissionToRole(RolePermission rolePermission);

    public RolePermission? RemovePermissionFromRole(Guid id);



    public Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(Guid roleId);

    public Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(string roleId);

    public Task<RolePermission?> AddPermissionToRoleAsync(RolePermission rolePermission);

    public Task<RolePermission?> RemovePermissionFromRoleAsync(Guid id);
}
