using Application.DTOs.Customer;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ICustomerService customerService;

    public CustomerController(IMapper mapper, ICustomerService customerService)
    {
        this.mapper = mapper;
        this.customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);

        if (customer == null)
            return BadRequest();

        var customerResponse = mapper.Map<CustomerResponse>(customer);

        return Ok(customerResponse);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest addCustomerRequest)
    {
        var user = mapper.Map<User>(addCustomerRequest.user);

        var customer = mapper.Map<Customer>(addCustomerRequest);

        customer = await customerService.AddCustomerAsync(user, customer);

        var customerResponse = mapper.Map<CustomerResponse>(customer);

        return Ok(customerResponse);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCustomer(Guid id, UpdateCustomerRequest updateCustomerRequest)
    {
        var customer = mapper.Map<Customer>(updateCustomerRequest);

        customer = await customerService.UpdateCustomerAsync(id, customer);

        if (customer == null)
            return BadRequest();

        var customerResponse = mapper.Map<CustomerResponse>(customer);

        return Ok(customerResponse);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        var customer = await customerService.DeleteCustomerAsync(id);

        if (customer == null)
            return BadRequest();

        var customerResponse = mapper.Map<CustomerResponse>(customer);

        return Ok(customerResponse);
    }

    [HttpPost("LogIn")]
    public async Task<IActionResult> LogIn(string userName, string password)
    {
        var token = await customerService.LogInAsync(userName, password);

        if (token == null)
            return BadRequest();

        return Ok(token);
    }
}