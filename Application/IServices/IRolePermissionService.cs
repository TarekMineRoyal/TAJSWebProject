using Domain.Entities;

namespace Application.IServices;

public interface IRolePermissionService
{
    public IEnumerable<Permission>? GetPermissionsByRoleId(Guid roleId);

    public IEnumerable<Permission>? GetPermissionsByRoleId(string roleId);

    public Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(Guid roleId);

    public Task<IEnumerable<Permission>?> GetPermissionsByRoleIdAsync(string roleId);
}
