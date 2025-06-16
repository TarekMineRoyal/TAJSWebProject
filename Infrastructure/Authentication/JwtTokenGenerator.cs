using Application.DTOs.User;
using Application.IServices;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public JwtTokenGenerator(IConfiguration configuration, IUserService userService, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if (user == null)
            {
                throw new ArgumentException($"User with email {email} not found");
            }

            string role;
            if (await _userManager.IsInRoleAsync(user, "Customer"))
            {
                role = "Customer";
            }
            else if(await _userManager.IsInRoleAsync(user, "Employee"))
            {
                role = "Employee";
            }
            else if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                role = "Admin";
            }
            else
            {
                role = "User";

            }

            var claims = new[]
                    {
            //new Claim(JwtRegisteredClaimNames.Sub, userDto.Id),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}