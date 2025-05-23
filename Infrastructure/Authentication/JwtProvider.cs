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

    public string Generate(Employee employee, IEnumerable<Role> roles, string email)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
        };


        if (roles != null)
        {
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
        }

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
