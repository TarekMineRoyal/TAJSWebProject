using Domain.Entities;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class IdentitySeed
    {
        public static async Task SeedRolesAndAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, CustomIdentityDbContext identityDbContext)
        {
            // 1. Seed Roles if they don't exist
            string[] roleNames = { "Admin", "Customer", "Employee" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Get role objects to use later
            var adminRole = await roleManager.FindByNameAsync("Admin");
            var employeeRole = await roleManager.FindByNameAsync("Employee");

            // 2. Seed Users and link to Customer/Employee
            // Seed Admin User
            if (await userManager.FindByEmailAsync("admin@domain.com") == null)
            {
                var adminUser = new User { UserName = "admin@domain.com", Email = "admin@domain.com", FirstName = "Admin", LastName = "User", Name = "Admin User", Address = "123 Admin St" };
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded) await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Seed Employee User and corresponding Employee entity
            if (await userManager.FindByEmailAsync("employee@domain.com") == null)
            {
                var employeeUser = new User { UserName = "employee@domain.com", Email = "employee@domain.com", FirstName = "John", LastName = "Doe", Name = "John Doe", Address = "456 Staff Rd" };
                var result = await userManager.CreateAsync(employeeUser, "Employee123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employeeUser, "Employee");
                    // Use the 'employeeRole' variable declared earlier
                    var newEmployee = new Employee { UserId = employeeUser.Id, HireDate = DateTime.Now, RoleId = employeeRole.Id };
                    identityDbContext.Employees.Add(newEmployee);
                }
            }

            // Seed Customer User and corresponding Customer entity
            if (await userManager.FindByEmailAsync("customer@domain.com") == null)
            {
                var customerUser = new User { UserName = "customer@domain.com", Email = "customer@domain.com", FirstName = "Jane", LastName = "Smith", Name = "Jane Smith", Address = "789 Client Ave" };
                var result = await userManager.CreateAsync(customerUser, "Customer123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(customerUser, "Customer");
                    var newCustomer = new Customer { UserId = customerUser.Id, FirstName = "Jane", LastName = "Smith", PhoneNumber = "123-456-7890", Country = "USA" };
                    identityDbContext.Customers.Add(newCustomer);
                }
            }
            await identityDbContext.SaveChangesAsync();

            // 3. Seed Permissions
            string[] permissions = { "manage-posts", "manage-users", "view-dashboard", "manage-bookings", "manage-cars" };
            foreach (var permissionName in permissions)
            {
                if (!await identityDbContext.Permissions.AnyAsync(p => p.Name == permissionName))
                {
                    identityDbContext.Permissions.Add(new Permission { Id = Guid.NewGuid().ToString(), Name = permissionName });
                }
            }
            await identityDbContext.SaveChangesAsync();

            // 4. Seed RolePermissions
            var allPermissions = identityDbContext.Permissions.ToList();

            // Assign all permissions to Admin
            foreach (var permission in allPermissions)
            {
                if (!await identityDbContext.RolePermissions.AnyAsync(rp => rp.RoleId == adminRole.Id && rp.PermissionId == permission.Id))
                {
                    identityDbContext.RolePermissions.Add(new RolePermission { Id = Guid.NewGuid().ToString(), RoleId = adminRole.Id, PermissionId = permission.Id });
                }
            }

            // Assign specific permissions to Employee
            var employeePermission = allPermissions.FirstOrDefault(p => p.Name == "manage-posts");
            if (employeePermission != null && !await identityDbContext.RolePermissions.AnyAsync(rp => rp.RoleId == employeeRole.Id && rp.PermissionId == employeePermission.Id))
            {
                identityDbContext.RolePermissions.Add(new RolePermission { Id = Guid.NewGuid().ToString(), RoleId = employeeRole.Id, PermissionId = employeePermission.Id });
            }
            await identityDbContext.SaveChangesAsync();
        }
    }
}