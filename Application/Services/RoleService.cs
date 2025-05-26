using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
using Domain.Entities.Identity;

namespace Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleManagerRepository<Role> roleRepository;

    public RoleService(IRoleManagerRepository<Role> roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public Role AddRole(Role role)
    {
        var returnedRole = roleRepository.GetFirstOrDefault(x => x.Name == role.Name);

        if (returnedRole != null)
        {
            role = returnedRole;
            return role;
        }
        else
            role.Id = Guid.NewGuid().ToString();

        returnedRole = roleRepository.Add(role);

        roleRepository.SaveChanges();

        return returnedRole;
    }

    public async Task<Role> AddRoleAsync(Role role)
    {
        var returnedRole = await roleRepository.GetFirstOrDefaultAsync(x => x.Name == role.Name);

        if (returnedRole != null)
        {
            role = returnedRole;
            return role;
        }
        else
            role.Id = Guid.NewGuid().ToString();

        returnedRole = await roleRepository.AddAsync(role);

        await roleRepository.SaveChangesAsync();

        return returnedRole;
    }

    public IEnumerable<Role>? GetAllRole()
    {
        return roleRepository.GetAll();
    }

    public async Task<IEnumerable<Role>?> GetAllRolesAsync()
    {
        return await roleRepository.GetAllAsync();
    }

    public Role? GetRoleById(Guid id)
    {
        return roleRepository.GetById(id);
    }

    public async Task<Role?> GetRoleByIdAsync(Guid id)
    {
        return await roleRepository.GetByIdAsync(id);
    }

    public Role? RemoveRole(Guid id)
    {
        var role = roleRepository.Remove(id);

        roleRepository.SaveChanges();

        return role;
    }

    public async Task<Role?> RemoveRoleAsync(Guid id)
    {
        var role = await roleRepository.RemoveAsync(id);

        await roleRepository.SaveChangesAsync();

        return role;
    }

    public Role? UpdateRole(Guid id, Role role)
    {
        var newRole = roleRepository.Update(id, role);

        roleRepository.SaveChanges();

        if (newRole == null)
            return null;

        return newRole;
    }

    public async Task<Role?> UpdateRoleAsync(Guid id, Role role)
    {
        var newRole = await roleRepository.UpdateAsync(id, role);

        await roleRepository.SaveChangesAsync();

        if (newRole == null)
            return null;

        return newRole;
    }
}