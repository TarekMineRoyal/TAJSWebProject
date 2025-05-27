using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.User;

public class SignUpUserRequest
{
    public string Email { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }
}
