using Domain.Entities;

namespace Application.IServices;

public interface ICustomerService
{
    public Customer AddCustomer(User user, Customer customer);

    public Customer? UpdateCustomer(int id, Customer customer);

    public Customer? DeleteCustomer(int customerId);


    public Task<Customer> AddCustomerAsync(User user, Customer customer);

    public Task<Customer?> UpdateCustomerAsync(int id, Customer customer);

    public Task<Customer?> DeleteCustomerAsync(int customerId);
}
