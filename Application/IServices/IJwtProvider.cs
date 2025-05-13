using Domain.Entities;
using System.Data;

namespace Application.IServices;

public interface IJwtProvider
{
    public string Generate(Employee employee, IEnumerable<Role> roles, string email);
}
