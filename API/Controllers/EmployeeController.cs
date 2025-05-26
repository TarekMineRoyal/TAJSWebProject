using Application.DTOs.Customer;
using Application.DTOs.Employee;
using Application.DTOs.User;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IEmployeeService employeeService;

    public EmployeeController(IMapper mapper, IEmployeeService employeeService)
    {
        this.mapper = mapper;
        this.employeeService = employeeService;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCustomerById(Guid id)
    {
        var employee = await employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
            return BadRequest();

        var employeeResponse = mapper.Map<EmployeeResponse>(employee);

        employeeResponse.UserResponse = mapper.Map<UserResponse>(employee.User);
        return Ok(employeeResponse);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await employeeService.GetAllEmployeesAsync();

        if (employees == null)
            return BadRequest();

        var employeeResponses = new List<EmployeeResponse>();

        foreach (var employee in employees)
        {
            var employeeResponse = mapper.Map<EmployeeResponse>(employee);

            employeeResponse.UserResponse = mapper.Map<UserResponse>(employee.User);

            employeeResponses.Add(employeeResponse);
        }

        return Ok(employeeResponses);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
    {
        var user = mapper.Map<User>(addEmployeeRequest.user);

        var employee = mapper.Map<Employee>(addEmployeeRequest);

        employee = await employeeService.AddEmployeeAsync(user, employee);

        var employeeResponse = mapper.Map<EmployeeResponse>(employee);

        employeeResponse.UserResponse = mapper.Map<UserResponse>(employee.User);

        return Ok(employeeResponse);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest updateEmployeeRequest)
    {
        var employee = mapper.Map<Employee>(updateEmployeeRequest);

        employee = await employeeService.UpdateEmployeeAsync(id, employee);

        if (employee == null)
            return BadRequest();

        var employeeResponse = mapper.Map<EmployeeResponse>(employee);

        employeeResponse.UserResponse = mapper.Map<UserResponse>(employee.User);

        return Ok(employeeResponse);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var employee = await employeeService.DeleteEmployeeAsync(id);

        if (employee == null)
            return BadRequest();

        var employeeResponse = mapper.Map<EmployeeResponse>(employee);

        employeeResponse.UserResponse = mapper.Map<UserResponse>(employee.User);

        return Ok(employeeResponse);
    }

    [HttpPost("LogIn")]
    public async Task<IActionResult> LogIn(string userName, string password)
    {
        var token = await employeeService.LogInAsync(userName, password);

        if (token == null)
            return BadRequest();

        return Ok(token);
    }
}
