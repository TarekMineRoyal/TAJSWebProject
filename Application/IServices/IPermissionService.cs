using Domain.Entities;

namespace Application.IServices;

public interface IPermissionService
{
    public Permission? GetPermissionById(Guid id);

    public Task<Permission?> GetPermissionByIdAsync(Guid id);
}
