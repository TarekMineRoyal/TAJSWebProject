using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class IdentitySeed
    {
        public static async Task SeedRolesAndAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Customer", "Employee" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminEmail = "admin@domain.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new User
                {
                    UserName = adminEmail,
                    FirstName = "Admin",
                    LastName = "Admin",

                    Email = adminEmail,
                    Name = "Admin User",
                    Address = "any address",
                };

                var result = await userManager.CreateAsync(user, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            var customerEmail = "customer@domain.com";
            var customerUser = await userManager.FindByEmailAsync(customerEmail);
            if (customerUser == null)
            {
                var user = new User
                {
                    UserName = customerEmail,
                    FirstName = "Customer",
                    LastName = "Customer",

                    Email = customerEmail,
                    Name = "Customer User",
                    Address = "any address",
                };

                var result = await userManager.CreateAsync(user, "Customer123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                }
            }
        }
    }
}
