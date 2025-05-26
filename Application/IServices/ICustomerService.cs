using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.IServices;

public interface ICustomerService
{
<<<<<<< HEAD
    public Customer? GetCustomerById(Guid id);

    public IEnumerable<Customer>? GetAllCustomers();

    public Customer AddCustomer(User user, Customer customer);
=======
    public Customer CreateCustomer(User user, Customer customer);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25

    public Customer? UpdateCustomer(Guid id, Customer customer);

    public Customer? DeleteCustomer(Guid id);

    public string? LogIn(string userName, string password);


    public Task<Customer?> GetCustomerByIdAsync(Guid id);

    public Task<IEnumerable<Customer>?> GetAllCustomersAsync();

    public Task<Customer> CreateCustomerAsync(User user, Customer customer);

    public Task<Customer?> UpdateCustomerAsync(Guid id, Customer customer);

    public Task<Customer?> DeleteCustomerAsync(Guid id);

    public Task<string> LogInAsync(string userName, string password);
}
