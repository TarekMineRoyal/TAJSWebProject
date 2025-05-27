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
>>>>>>> parent of cd0f207 (Samrah Gay)

    public Customer? UpdateCustomer(int id, Customer customer);

    public Customer? DeleteCustomer(int customerId);

<<<<<<< HEAD


    public Task<Customer?> GetCustomerByIdAsync(Guid id);

    public Task<IEnumerable<Customer>?> GetAllCustomersAsync();
=======
>>>>>>> parent of cd0f207 (Samrah Gay)

    public Task<Customer> AddCustomerAsync(User user, Customer customer);

    public Task<Customer?> UpdateCustomerAsync(int id, Customer customer);

<<<<<<< HEAD
    public Task<Customer?> DeleteCustomerAsync(Guid id);

=======
    public Task<Customer?> DeleteCustomerAsync(int customerId);
>>>>>>> parent of cd0f207 (Samrah Gay)
}
