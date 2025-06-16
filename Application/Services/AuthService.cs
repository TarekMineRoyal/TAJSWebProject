using Application.DTOs.User;
using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserManagerRepository<User> _userRepository;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IUserManagerRepository<User> userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
        }

        public async Task<IdentityResult> RegisterAsync(UserRegisterDto dto)
        {
            User user;

            user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = $"{dto.FirstName} {dto.LastName}",
                Address = dto.Address,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {   
                await _userManager.AddToRoleAsync(user, "Customer");
                //user = await _userRepository.AddAsync(user);
                //await _userRepository.SaveChangesAsync();
            }
            return result;
        }

        public async Task<SignInResult> LoginAsync(UserLoginDto dto)
        {
            return await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
