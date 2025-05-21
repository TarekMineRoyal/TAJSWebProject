using Domain.Entities;

namespace Application.IServices;

public interface IUserService
{
    public string? LogIn(string userName, string password);

    public User Signup(User user);

    public User? ChangePassword(string id, string newPassword);

    public User? ChangeEmail(string id, string newEmail);

    public User? DeleteUser(string id);

    public User? GetUserById(string id);

    public IEnumerable<User>? GetAllUsers();


    public Task<string> LogInAsync(string userName, string password);

    public Task<User> SignupAsync(User user);

    public Task<User?> ChangePasswordAsync(string id, string newPassword);

    public Task<User?> ChangeEmailAsync(string id, string newEmail);

    public Task<User?> DeleteUserAsync(string id);

    public Task<User?> GetUserByIdAsync(string id);

    public Task<IEnumerable<User>?> GetAllUsersAsync();
}
