using Domain.Entities;
using System.Data;

namespace Application.IServices;

public interface IJwtProvider
{
    public string Generate(string userId, string email, string? phoneNumber,Role? role);
}
