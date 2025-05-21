using Domain.Entities;

namespace Application.IServices;

public interface IUserService
{
    public string? LogIn(string userName, string password);

    public User Signup(User user);

    public User? ChangePassword(int id, string newPassword);

    public User? ChangeEmail(int id, string newEmail);

    public User? DeleteUser(int id);

    public User? GetUserById(int id);


    public Task<string> LogInAsync(string userName, string password);

    public Task<User> SignupAsync(User user);

    public Task<User?> ChangePasswordAsync(int id, string newPassword);

    public Task<User?> ChangeEmailAsync(int id, string newEmail);

    public Task<User?> DeleteUserAsync(int id);

    public Task<User?> GetUserByIdAsync(int id);
}
