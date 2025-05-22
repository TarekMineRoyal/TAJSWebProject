using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUserManagerRepository<Customer> customerRepository;
    private readonly IJwtProvider jwtProvider;
    private readonly IUserManagerRepository<User> userRepository;

    public CustomerService(IUserManagerRepository<Customer> customerRepository, IJwtProvider jwtProvider,
        IUserManagerRepository<User> userRepository)
    {
        this.customerRepository = customerRepository;
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
    }

    public Customer AddCustomer(User user, Customer customer)
    {
        var returnedUser = userRepository.GetFirstOrDefault(x => x.UserName == user.UserName 
        && x.PasswordHash == user.PasswordHash);

        if (returnedUser == null)
        {
            returnedUser = userRepository.Add(user);
        }

        customer.UserId = returnedUser.Id;

        var returnedCustomer = customerRepository.Add(customer);

        customerRepository.SaveChanges();

        return returnedCustomer;
    }

    public async Task<Customer> AddCustomerAsync(User user, Customer customer)
    {
        var returnedUser = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == user.UserName
        && x.PasswordHash == user.PasswordHash);

        if (returnedUser == null)
        {
            returnedUser = await userRepository.AddAsync(user);
        }

        customer.UserId = returnedUser.Id;

        var returnedCustomer = await customerRepository.AddAsync(customer);

        await customerRepository.SaveChangesAsync();

        return returnedCustomer;
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

    public Customer? DeleteCustomer(Guid id)
    {
        var customer = customerRepository.Remove(id);
        customerRepository.SaveChanges();

        userRepository.Remove(id);
        userRepository.SaveChanges();

        return customer;
    }

    public async Task<Customer?> DeleteCustomerAsync(Guid id)
    {
        var customer = customerRepository.Remove(id);
        await customerRepository.SaveChangesAsync();

        userRepository.Remove(id);
        await userRepository.SaveChangesAsync();

        return customer;
    }

    public Customer? GetCustomerById(Guid id)
    {
        var customer = customerRepository.GetById(id);

        return customer;
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        return customer;
    }

    public string? LogIn(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        var user = userRepository.GetFirstOrDefault(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var customer = customerRepository.GetFirstOrDefault(x => x.UserId == user.Id);

        if(customer is null)
            return null;

        var token = jwtProvider.Generate(user.Id, user.Email, customer.PhoneNumber, null);

        return token;
    }

    public async Task<string> LogInAsync(string userName, string password)
    {
        // Need to discuss abou the customer and the employee and adding another JwtTokenProvider
        var user = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var customer = await customerRepository.GetFirstOrDefaultAsync(x => x.UserId == user.Id);

        if (customer is null)
            return null;

        var token = jwtProvider.Generate(user.Id, user.Email, customer.PhoneNumber, null);

        return token;
    }

    public Customer? UpdateCustomer(Guid id, Customer customer)
    {
        var returnedCustomer = customerRepository.Update(id, customer);
        customerRepository.SaveChanges();

        return returnedCustomer;
    }

    public async Task<Customer?> UpdateCustomerAsync(Guid id, Customer customer)
    {
        var returnedCustomer = await customerRepository.UpdateAsync(id, customer);
        await customerRepository.SaveChangesAsync();

        return returnedCustomer;
    }
}
