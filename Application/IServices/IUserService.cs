using Domain.Entities.Identity;

namespace Application.IServices;

public interface IUserService
{
<<<<<<< HEAD
    public User? ChangePassword(Guid id, string newPassword);
=======
    public string LogIn(string userName, string password);
>>>>>>> parent of cd0f207 (Samrah Gay)

    public User? ChangeEmail(Guid id, string newEmail);

<<<<<<< HEAD
    public Task<User?> ChangePasswordAsync(Guid id, string newPassword);

    public Task<User?> ChangeEmailAsync(Guid id, string newEmail);
=======
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
>>>>>>> parent of cd0f207 (Samrah Gay)
}
