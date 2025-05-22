using Application.IRepositories;
using Application.IServices;
using Domain.Entities;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUserManagerRepository<Employee> employeeRepository;
    private readonly IUserManagerRepository<User> userRepository;
    private readonly IJwtProvider jwtProvider;
    private readonly IRoleManagerRepository<Role> roleManagerRepository;

    public EmployeeService(IUserManagerRepository<Employee> employeeRepository, IUserManagerRepository<User> userRepository,
        IJwtProvider jwtProvider, IRoleManagerRepository<Role> roleManagerRepository)
    {
        this.employeeRepository = employeeRepository;
        this.userRepository = userRepository;
        this.jwtProvider = jwtProvider;
        this.roleManagerRepository = roleManagerRepository;
    }

    public Employee? AddEmployee(User user, Employee employee)
    {
        var returnedUser = userRepository.GetFirstOrDefault(x => x.UserName == user.UserName
        && x.PasswordHash == user.PasswordHash);

        if (returnedUser == null)
        {
            returnedUser = userRepository.Add(user);
        }

        employee.UserId = returnedUser.Id;

        employee = employeeRepository.Add(employee);

        return employee;
    }

    public async Task<Employee?> AddEmployeeAsync(User user, Employee employee)
    {
        var returnedUser = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == user.UserName
        && x.PasswordHash == user.PasswordHash);

        if (returnedUser == null)
        {
            returnedUser = await userRepository.AddAsync(user);
        }

        employee.UserId = returnedUser.Id;

        employee = await employeeRepository.AddAsync(employee);

        return employee;
    }

    public Employee? DeleteEmployee(Guid id)
    {
        var employee = employeeRepository.Remove(id);
        employeeRepository.SaveChanges();

        userRepository.Remove(id);
        userRepository.SaveChanges();

        return employee;
    }

    public async Task<Employee?> DeleteEmployeeAsync(Guid id)
    {
        var employee = await employeeRepository.RemoveAsync(id);
        await employeeRepository.SaveChangesAsync();

        await userRepository.RemoveAsync(id);
        await userRepository.SaveChangesAsync();

        return employee;
    }

    public Employee? GetEmployeeById(Guid id)
    {
        var employee = employeeRepository.GetById(id);

        return employee;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);

        return employee;
    }

    public string? LogIn(string userName, string password)
    {
        // Need to discuss abou the employee and the employee and adding another JwtTokenProvider
        var user = userRepository.GetFirstOrDefault(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var employee = employeeRepository.GetFirstOrDefault(x => x.UserId == user.Id);

        if (employee is null)
            return null;

        //var permissions = roleManagerRepository.GetFirstOrDefault(x => x.Id == employee.UserId);

        // pass the permissions to the jwtProvider ot use them

        var token = jwtProvider.Generate(user.Id, user.Email, null, null);

        return token;
    }

    public async Task<string> LogInAsync(string userName, string password)
    {
        // Need to discuss abou the employee and the employee and adding another JwtTokenProvider
        var user = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == userName && x.PasswordHash == password);

        if (user is null)
            return null;

        var employee = await employeeRepository.GetFirstOrDefaultAsync(x => x.UserId == user.Id);

        if (employee is null)
            return null;

        //var permissions = roleManagerRepository.GetFirstOrDefault(x => x.Id == employee.UserId);

        // pass the permissions to the jwtProvider ot use them

        var token = jwtProvider.Generate(user.Id, user.Email, null, null);

        return token;
    }

    public Employee? UpdateEmployee(Guid id, Employee employee)
    {
        var returnedEmployee = employeeRepository.Update(id, employee);
        employeeRepository.SaveChanges();

        return returnedEmployee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee)
    {
        var returnedEmployee = await employeeRepository.UpdateAsync(id, employee);
        await employeeRepository.SaveChangesAsync();

        return returnedEmployee;
    }
}
