using Application.DTOs.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(UserRegisterDto dto);
        Task<SignInResult> LoginAsync(UserLoginDto dto);
        Task LogoutAsync();
    }
}
