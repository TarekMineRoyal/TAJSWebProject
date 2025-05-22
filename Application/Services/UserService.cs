using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository<User> userRepository;
    private readonly IJwtProvider jwtProvider;

    public UserService(IUserRepository<User> userRepository, IJwtProvider jwtProvider)
    {
        this.userRepository = userRepository;
        this.jwtProvider = jwtProvider;
    }

    public User? ChangeEmail(Guid id, string newEmail)
    {
        var user = userRepository.GetById(id.ToString());

        if (user == null)
            return null;

        user.Email = newEmail;

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> ChangeEmailAsync(Guid id, string newEmail)
    {
        var user = await userRepository.GetByIdAsync(id.ToString());

        if (user == null)
            return null;

        user.Email = newEmail;

        await userRepository.SaveChangesAsync();

        return user;
    }

    public User? ChangePassword(Guid id, string newPassword)
    {
        // Add Hashing the password

        var user = userRepository.GetById(id.ToString());

        if (user == null)
            return null;

        user.PasswordHash = newPassword;

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> ChangePasswordAsync(Guid id, string newPassword)
    {
        // Add Hashing the password

        var user = await userRepository.GetByIdAsync(id.ToString());

        if (user == null)
            return null;

        user.PasswordHash = newPassword;

        await userRepository.SaveChangesAsync();

        return user;
    }

    public User? DeleteUser(Guid id)
    {
        var user = userRepository.Remove(id.ToString());

        userRepository.SaveChanges();

        return user;
    }

    public async Task<User?> DeleteUserAsync(Guid id)
    {
        var user = await userRepository.RemoveAsync(id.ToString());
        
        await userRepository.SaveChangesAsync();

        return user;
    }

    public IEnumerable<User>? GetAllUsers()
    {
        return userRepository.GetAll();
    }

    public Task<IEnumerable<User>?> GetAllUsersAsync()
    {
        return userRepository.GetAllAsync();
    }

    public User? GetUserById(Guid id)
    {
        return userRepository.GetById(id.ToString());
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await userRepository.GetByIdAsync(id.ToString());
    }

    public string? LogIn(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        var user = userRepository.GetFirstOrDefault(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var token = jwtProvider.Generate(user.Id, user.Email, null, null);

        return token;
    }

    public async Task<string> LogInAsync(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        var user = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var token = jwtProvider.Generate(user.Id, user.Email, null, null);

        return token;
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
}
