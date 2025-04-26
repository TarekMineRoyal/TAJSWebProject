using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.DataAccess;

namespace Domain.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(string id);
        public Task<User> AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(string id);
    }
}