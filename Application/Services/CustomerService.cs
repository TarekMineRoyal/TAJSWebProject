using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IGenericRepository<Customer> customerRepository;
    private readonly IJwtProvider jwtProvider;
    private readonly IGenericRepository<User> userRepository;

    public CustomerService(IGenericRepository<Customer> customerRepository, IJwtProvider jwtProvider, 
        IGenericRepository<User> userRepository)
    {
        this.customerRepository = customerRepository;
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
    }

    public Customer AddCustomer(User user, Customer customer)
    {
        customer.UserId = user.Id;

        var returnedCustomer = customerRepository.Add(customer);

        customerRepository.SaveChanges();

        return returnedCustomer;
    }

    public async Task<Customer> AddCustomerAsync(User user, Customer customer)
    {
        customer.UserId = user.Id;

        var returnedCustomer = await customerRepository.AddAsync(customer);

        await customerRepository.SaveChangesAsync();

        return returnedCustomer;
    }

    public Customer? DeleteCustomer(int customerId)
    {
        var customer = customerRepository.Remove(customerId);
        customerRepository.SaveChanges();

        userRepository.Remove(customerId);
        userRepository.SaveChanges();

        return customer;
    }

    public async Task<Customer?> DeleteCustomerAsync(int customerId)
    {
        var customer = customerRepository.Remove(customerId);
        await customerRepository.SaveChangesAsync();

        userRepository.Remove(customerId);
        await userRepository.SaveChangesAsync();

        return customer;
    }

    public Customer? UpdateCustomer(int id, Customer customer)
    {
        var returnedCustomer = customerRepository.Update(id, customer);
        customerRepository.SaveChanges();

        return returnedCustomer;
    }

    public async Task<Customer?> UpdateCustomerAsync(int id, Customer customer)
    {
        var returnedCustomer = await customerRepository.UpdateAsync(id, customer);
        await customerRepository.SaveChangesAsync();

        return returnedCustomer;
    }
}
