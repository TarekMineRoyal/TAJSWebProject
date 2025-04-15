﻿using DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<DataAccess.Entities.User.User>> GetUsersAsync();
        public Task<DataAccess.Entities.User.User> GetUserByIdAsync(string id);
        public Task<DataAccess.Entities.User.User> AddUserAsync(DataAccess.Entities.User.User user);
        public Task UpdateUserAsync(DataAccess.Entities.User.User user);
        public Task DeleteUserAsync(string id);
    }
}