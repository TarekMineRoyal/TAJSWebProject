using Domain.Entities;
using System.Runtime;

namespace Application.IServices;

public interface IRoleService
{
    public Role? GetRoleById(Guid id);

    public Task<Role?> GetRoleByIdAsync(Guid id);
}
