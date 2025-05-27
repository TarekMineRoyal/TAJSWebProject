using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(string email, string role = "Customer");
    }
}