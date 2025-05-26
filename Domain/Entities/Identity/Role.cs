using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class Role : IdentityRole
{
    public ICollection<RolePermission> RolePermissions { get; set; }
}
