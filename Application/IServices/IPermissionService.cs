using Domain.Entities;

namespace Application.IServices;

public interface IPermissionService
{
    public Permission? GetPermissionById(Guid id);

    public IEnumerable<Permission>? GetAllPermissions();

    public Permission AddPermission(Permission permission);

    public Permission? UpdatePermission(Guid id, Permission permission);

    public Permission? RemovePermission(Guid id);


    public Task<Permission?> GetPermissionByIdAsync(Guid id);

    public Task<IEnumerable<Permission>?> GetAllPermissionsAsync();

    public Task<Permission> AddPermissionAsync(Permission permission);

    public Task<Permission?> UpdatePermissionAsync(Guid id, Permission permission);

    public Task<Permission?> RemovePermissionAsync(Guid id);
}
