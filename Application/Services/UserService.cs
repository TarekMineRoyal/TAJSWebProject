<<<<<<< HEAD
﻿using Application.IServices;
using Domain.Entities;
using Application.IRepositories;
using Domain.Entities.Identity;

=======
﻿using Application.IRepositories;
using Application.IServices;
using Domain.Entities.Identity;
>>>>>>> parent of cd0f207 (Samrah Gay)

namespace Application.Services;

public class UserService : IUserService
{
<<<<<<< HEAD
    private readonly IUserManagerRepository<User> userRepository;

    public UserService(IUserManagerRepository<User> userRepository)
=======
    private readonly IGenericRepository<User> userRepository;
    private readonly IJwtProvider jwtProvider;

    public UserService(IGenericRepository<User> userRepository, IJwtProvider jwtProvider)
>>>>>>> parent of cd0f207 (Samrah Gay)
    {
        this.userRepository = userRepository;
        this.jwtProvider = jwtProvider;
    }

    public User? ChangeEmail(Guid id, string newEmail)
    {
        var user = userRepository.GetById(id);

        if (user == null)
            return null;

        user.Email = newEmail;

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> ChangeEmailAsync(Guid id, string newEmail)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        user.Email = newEmail;

        await userRepository.SaveChangesAsync();

        return user;
    }

    public User? ChangePassword(Guid id, string newPassword)
    {
        // Add Hashing the password

        var user = userRepository.GetById(id);

        if (user == null)
            return null;

        user.PasswordHash = newPassword;

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> ChangePasswordAsync(Guid id, string newPassword)
    {
        // Add Hashing the password

        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        user.PasswordHash = newPassword;

        await userRepository.SaveChangesAsync();

        return user;
    }
<<<<<<< HEAD
=======

    public User? DeleteUser(int id)
    {
        var user = userRepository.Remove(id);

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> DeleteUserAsync(int id)
    {
        var user = await userRepository.RemoveAsync(id);
        
        await userRepository.SaveChangesAsync();

        return user;
    }

    public User? GetUserById(int id)
    {
        return userRepository.GetById(id);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public string LogIn(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        throw new NotImplementedException();
    }

    public Task<string> LogInAsync(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        throw new NotImplementedException();
    }

    public User Signup(User user)
    {
        var returnedUser = userRepository.Add(user);
        userRepository.SaveChanges();

        return returnedUser;
    }

    public async Task<User> SignupAsync(User user)
    {
        var returnedUser = await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();

        return returnedUser;
    }
>>>>>>> parent of cd0f207 (Samrah Gay)
}
