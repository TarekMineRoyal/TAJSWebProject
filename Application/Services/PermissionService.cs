using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IRoleManagerRepository<Permission> permissionRepository;

    public PermissionService(IRoleManagerRepository<Permission> permissionRepository)
    {
        this.permissionRepository = permissionRepository;
    }

    public Permission AddPermission(Permission permission)
    {
        var returnedPermission = permissionRepository.GetFirstOrDefault(x => x.Name == permission.Name);

        if (returnedPermission != null)
        {
            permission = returnedPermission;

            return permission;
        }
        else
            permission.Id = Guid.NewGuid().ToString();


        returnedPermission = permissionRepository.Add(permission);

        permissionRepository.SaveChanges();

        return returnedPermission;
    }

    public async Task<Permission> AddPermissionAsync(Permission permission)
    {
        var returnedPermission = await permissionRepository.GetFirstOrDefaultAsync(x => x.Name == permission.Name);

        if (returnedPermission != null)
        {
            permission = returnedPermission;

            return permission;
        }
        else
            permission.Id = Guid.NewGuid().ToString();

        returnedPermission = await permissionRepository.AddAsync(permission);

        await permissionRepository.SaveChangesAsync();

        return returnedPermission;
    }

    public IEnumerable<Permission>? GetAllPermissions()
    {
        return permissionRepository.GetAll();
    }

    public async Task<IEnumerable<Permission>?> GetAllPermissionsAsync()
    {
        return await permissionRepository.GetAllAsync();
    }

    public Permission? GetPermissionById(Guid id)
    {
        return permissionRepository.GetById(id);
    }

    public async Task<Permission?> GetPermissionByIdAsync(Guid id)
    {
        return await permissionRepository.GetByIdAsync(id);
    }

    public Permission? RemovePermission(Guid id)
    {
        var permission = permissionRepository.Remove(id);

        permissionRepository.SaveChanges();

        return permission;
    }

    public async Task<Permission?> RemovePermissionAsync(Guid id)
    {
        var permission = await permissionRepository.RemoveAsync(id);

        await permissionRepository.SaveChangesAsync();

        return permission;
    }

    public Permission? UpdatePermission(Guid id, Permission permission)
    {
        var newPermission = permissionRepository.Update(id, permission);

        permissionRepository.SaveChanges();

        if(newPermission == null) 
            return null;

        return newPermission;
    }

    public async Task<Permission?> UpdatePermissionAsync(Guid id, Permission permission)
    {
        var newPermission = await permissionRepository.UpdateAsync(id, permission);

        await permissionRepository.SaveChangesAsync();

        if (newPermission == null)
            return null;

        return newPermission;
    }
}
