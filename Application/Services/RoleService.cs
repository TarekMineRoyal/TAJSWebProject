using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleManagerRepository<Role> roleRepository;

    public RoleService(IRoleManagerRepository<Role> roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public Role? GetRoleById(Guid id)
    {
        return roleRepository.GetById(id);
    }

    public async Task<Role?> GetRoleByIdAsync(Guid id)
    {
        return await roleRepository.GetByIdAsync(id);
    }
}
