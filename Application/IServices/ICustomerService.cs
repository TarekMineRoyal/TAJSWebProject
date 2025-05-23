using Domain.Entities;

namespace Application.IServices;

public interface ICustomerService : IUserService
{
    public Customer? GetCustomerById(Guid id);

    public IEnumerable<Customer>? GetAllCustomers();

    public Customer AddCustomer(User user, Customer customer);

    public Customer? UpdateCustomer(Guid id, Customer customer);

    public Customer? DeleteCustomer(Guid id);

    public string? LogIn(string userName, string password);


    public Task<Customer?> GetCustomerByIdAsync(Guid id);

    public Task<IEnumerable<Customer>?> GetAllCustomersAsync();

    public Task<Customer> AddCustomerAsync(User user, Customer customer);

    public Task<Customer?> UpdateCustomerAsync(Guid id, Customer customer);

    public Task<Customer?> DeleteCustomerAsync(Guid id);

    public Task<string> LogInAsync(string userName, string password);
}
