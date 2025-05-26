using Domain.Entities;
using Domain.Entities.Identity;
using System.Runtime;

namespace Application.IServices;

public interface IRoleService
{
    public Role? GetRoleById(Guid id);

    public IEnumerable<Role>? GetAllRole();

    public Role AddRole(Role permission);

    public Role? UpdateRole(Guid id, Role permission);

    public Role? RemoveRole(Guid id);


    public Task<Role?> GetRoleByIdAsync(Guid id);

    public Task<IEnumerable<Role>?> GetAllRolesAsync();

    public Task<Role> AddRoleAsync(Role permission);

    public Task<Role?> UpdateRoleAsync(Guid id, Role permission);

    public Task<Role?> RemoveRoleAsync(Guid id);
}
