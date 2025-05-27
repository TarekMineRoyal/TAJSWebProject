using Application.IRepositories;
using Application.IServices;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.Services;

public class CustomerService : ICustomerService
{
<<<<<<< HEAD
    private readonly IUserManagerRepository<Customer> customerRepository;
    private readonly IUserManagerRepository<User> userRepository;

    public CustomerService(IUserManagerRepository<Customer> customerRepository, 
        IUserManagerRepository<User> userRepository)
=======
    private readonly IGenericRepository<Customer> customerRepository;
    private readonly IJwtProvider jwtProvider;
    private readonly IGenericRepository<User> userRepository;

    public CustomerService(IGenericRepository<Customer> customerRepository, IJwtProvider jwtProvider, 
        IGenericRepository<User> userRepository)
>>>>>>> parent of cd0f207 (Samrah Gay)
    {
        this.customerRepository = customerRepository;
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

<<<<<<< HEAD
    public IEnumerable<Customer>? GetAllCustomers()
    {
        var customers = customerRepository.GetAll();

        if(customers == null)
            return null;

        foreach (var customer in customers)
        {
            var user = userRepository.GetById(customer.UserId);

            if(user == null)
                continue;

            customer.User = user;
        }

        return customers;
    }

    public async Task<IEnumerable<Customer>?> GetAllCustomersAsync()
    {
        var customers = await customerRepository.GetAllAsync();

        if (customers == null)
            return null;

        foreach (var customer in customers)
        {
            var user = await userRepository.GetByIdAsync(customer.UserId);

            if (user == null)
                continue;

            customer.User = user;
        }

        return customers;
    }

    public Customer? GetCustomerById(Guid id)
    {
        var customer = customerRepository.GetById(id);

        if (customer == null) 
            return null;

        var user = userRepository.GetById(id);

        if (user == null) 
            return null;

        customer.User = user;

        return customer;
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);

        if (customer == null)
            return null;

        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        customer.User = user;

        return customer;
    }



    public Customer? UpdateCustomer(Guid id, Customer customer)
=======
    public Customer? UpdateCustomer(int id, Customer customer)
>>>>>>> parent of cd0f207 (Samrah Gay)
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
