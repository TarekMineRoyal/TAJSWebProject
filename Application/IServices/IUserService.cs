using Domain.Entities.Identity;

namespace Application.IServices;

public interface IUserService
{
<<<<<<< HEAD
    public User? ChangePassword(Guid id, string newPassword);
=======
    public string LogIn(string userName, string password);

    public User Signup(User user);

    public User? ChangePassword(int id, string newPassword);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25

    public User? ChangeEmail(int id, string newEmail);

<<<<<<< HEAD
=======
    public User? DeleteUser(int id);

    public User? GetUserById(int id);


    public Task<string> LogInAsync(string userName, string password);

    public Task<User> SignupAsync(User user);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25

    public Task<User?> ChangePasswordAsync(int id, string newPassword);

<<<<<<< HEAD
    public Task<User?> ChangeEmailAsync(Guid id, string newEmail);
=======
    public Task<User?> ChangeEmailAsync(int id, string newEmail);

    public Task<User?> DeleteUserAsync(int id);

    public Task<User?> GetUserByIdAsync(int id);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25
}
