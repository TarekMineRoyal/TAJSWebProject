using Application.IRepositories;
using Application.IServices;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly IUserManagerRepository<Customer> customerRepository;
    private readonly IUserManagerRepository<User> userRepository;

    public CustomerService(IUserManagerRepository<Customer> customerRepository, 
        IUserManagerRepository<User> userRepository)
    {
        this.customerRepository = customerRepository;
        this.userRepository = userRepository;
    }

    public Customer AddCustomer(User user, Customer customer)
    {
        //var returnedUser = userRepository.GetFirstOrDefault(x => x.UserName == user.UserName 
        //&& x.PasswordHash == user.PasswordHash);

        //if (returnedUser == null)
        //{
        //    returnedUser = userRepository.Add(user);
        //}

        //customer.UserId = returnedUser.Id;

        var returnedCustomer = customerRepository.Add(customer);

        customerRepository.SaveChanges();

        //returnedCustomer.User = returnedUser;

        return returnedCustomer;
    }

    public async Task<Customer> AddCustomerAsync(User user, Customer customer)
    {
        //var returnedUser = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == user.UserName
        //&& x.PasswordHash == user.PasswordHash);

        //if (returnedUser == null)
        //{
        //    returnedUser = await userRepository.AddAsync(user);
        //}

        //customer.UserId = returnedUser.Id;

        var returnedCustomer = await customerRepository.AddAsync(customer);

        await customerRepository.SaveChangesAsync();

        //returnedCustomer.User = returnedUser;

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

    public Customer? DeleteCustomer(Guid id)
    {
        var customer = customerRepository.Remove(id);
        customerRepository.SaveChanges();

        if (customer == null)
            return null;

        var user = userRepository.Remove(id);
        userRepository.SaveChanges();

        if (user == null)
            return null;

        customer.User = user;

        return customer;
    }

    public async Task<Customer?> DeleteCustomerAsync(Guid id)
    {
        var customer = customerRepository.Remove(id);
        await customerRepository.SaveChangesAsync();

        if (customer == null)
            return null;

        var user = userRepository.Remove(id);
        await userRepository.SaveChangesAsync();

        if(user == null)
            return null;

        customer.User = user;

        return customer;
    }

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
    {
        var returnedCustomer = customerRepository.Update(id, customer);
        customerRepository.SaveChanges();

        if (returnedCustomer == null)
            return null;

        var user = userRepository.GetById(id);

        if (user is null) 
            return null;

        returnedCustomer.User = user;

        return returnedCustomer;
    }

    public async Task<Customer?> UpdateCustomerAsync(Guid id, Customer customer)
    {
        var returnedCustomer = await customerRepository.UpdateAsync(id, customer);
        await customerRepository.SaveChangesAsync();

        if (returnedCustomer == null)
            return null;

        var user = await userRepository.GetByIdAsync(id);

        if (user is null)
            return null;

        returnedCustomer.User = user;

        return returnedCustomer;
    }
}
