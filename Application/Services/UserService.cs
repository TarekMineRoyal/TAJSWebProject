using Application.IServices;
using Domain.Entities;
using Application.IRepositories;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserManagerRepository<User> userRepository;

    public UserService(IUserManagerRepository<User> userRepository)
    {
        this.userRepository = userRepository;
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
}
