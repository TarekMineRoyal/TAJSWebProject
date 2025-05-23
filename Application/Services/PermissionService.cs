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

    public Permission? GetPermissionById(Guid id)
    {
        return permissionRepository.GetById(id);
    }

    public async Task<Permission?> GetPermissionByIdAsync(Guid id)
    {
        return await permissionRepository.GetByIdAsync(id);
    }
}
