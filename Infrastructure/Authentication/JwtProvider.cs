using Application.IServices;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hotel_Restaurant_Reservation.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions options;

    public JwtProvider(IOptions<JwtOptions> options)
    {
        this.options = options.Value;

        if (string.IsNullOrEmpty(this.options.SecretKey))
            throw new ArgumentNullException(nameof(JwtOptions.SecretKey), "JWT SecretKey is not configured.");

        if (string.IsNullOrEmpty(this.options.Issuer))
            throw new ArgumentNullException(nameof(JwtOptions.Issuer), "JWT Issuer is not configured.");

        if (string.IsNullOrEmpty(this.options.Audience))
            throw new ArgumentNullException(nameof(JwtOptions.Audience), "JWT Audience is not configured.");
    }

<<<<<<< HEAD
    public string Generate(string userId, string email, string? phoneNumber, IEnumerable<Permission>? permissions)
=======
    public string Generate(Employee employee, IEnumerable<Role> roles, string email)
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
        };


<<<<<<< HEAD
        if (permissions is not null)
        {
            foreach (var permission in permissions)
            {
                claims.Add(new Claim(ClaimTypes.Role, permission.Name));
            }
        }
            

        if (phoneNumber is not null)
            claims.Add(new Claim(ClaimTypes.MobilePhone, phoneNumber));

=======
        if (roles != null)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
        }
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            options.Issuer,
            options.Audience,
            claims,
            null,
            DateTime.Now.AddHours(2),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}
