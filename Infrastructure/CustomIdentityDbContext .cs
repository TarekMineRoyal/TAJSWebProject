using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Infrastructure
{
    public class CustomIdentityDbContext : IdentityDbContext<User>
    {
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
