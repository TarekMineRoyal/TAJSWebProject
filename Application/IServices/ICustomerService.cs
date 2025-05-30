﻿using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.IServices;

public interface ICustomerService
{
    public Customer? GetCustomerById(Guid id);

    public IEnumerable<Customer>? GetAllCustomers();

    public Customer AddCustomer(User user, Customer customer);

    public Customer? UpdateCustomer(Guid id, Customer customer);

    public Customer? DeleteCustomer(Guid id);



    public Task<Customer?> GetCustomerByIdAsync(Guid id);

    public Task<IEnumerable<Customer>?> GetAllCustomersAsync();

    public Task<Customer> AddCustomerAsync(User user, Customer customer);

    public Task<Customer?> UpdateCustomerAsync(Guid id, Customer customer);

    public Task<Customer?> DeleteCustomerAsync(Guid id);

}
