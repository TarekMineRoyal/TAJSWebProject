using Domain.Entities;

namespace Application.IServices;

public interface IUserService
{
    public string? LogIn(string userName, string password);

    public User Signup(User user);

    public User? ChangePassword(Guid id, string newPassword);

    public User? ChangeEmail(Guid id, string newEmail);

    public User? DeleteUser(Guid id);

    public User? GetUserById(Guid id);

    public IEnumerable<User>? GetAllUsers();


    public Task<string> LogInAsync(string userName, string password);

    public Task<User> SignupAsync(User user);

    public Task<User?> ChangePasswordAsync(Guid id, string newPassword);

    public Task<User?> ChangeEmailAsync(Guid id, string newEmail);

    public Task<User?> DeleteUserAsync(Guid id);

    public Task<User?> GetUserByIdAsync(Guid id);

    public Task<IEnumerable<User>?> GetAllUsersAsync();
}
