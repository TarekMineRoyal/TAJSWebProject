using Domain.Entities.AppEntities;
using Domain.Entities.Identity;
using System.Data;

namespace Application.IServices;

public interface IJwtProvider
{
<<<<<<< HEAD
    public string Generate(string userId, string email, string? phoneNumber, IEnumerable<Permission>? permissions);
=======
    public string Generate(Employee employee, IEnumerable<Role> roles, string email);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25
}
