using Application.IRepositories;
using Application.IServices;
using Domain.Entities;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUserManagerRepository<Employee> employeeRepository;
    private readonly IUserManagerRepository<User> userRepository;
    private readonly IJwtProvider jwtProvider;
    private readonly IRoleManagerRepository<Role> roleRepository;
    private readonly IRolePermissionService rolePermissionService;

    public EmployeeService(IUserManagerRepository<Employee> employeeRepository, IUserManagerRepository<User> userRepository,
        IJwtProvider jwtProvider, IRoleManagerRepository<Role> roleRepository, IRolePermissionService rolePermissionService)
    {
        this.employeeRepository = employeeRepository;
        this.userRepository = userRepository;
        this.jwtProvider = jwtProvider;
        this.roleRepository = roleRepository;
        this.rolePermissionService = rolePermissionService;
    }

    public Employee? AddEmployee(User user, Employee employee)
    {
        //var returnedUser = userRepository.GetFirstOrDefault(x => x.UserName == user.UserName
        //&& x.PasswordHash == user.PasswordHash);

        //if (returnedUser == null)
        //{
        //    returnedUser = userRepository.Add(user);
        //}

        //employee.UserId = returnedUser.Id;

        employee = employeeRepository.Add(employee);

        employeeRepository.SaveChanges();

        return employee;
    }

    public async Task<Employee?> AddEmployeeAsync(User user, Employee employee)
    {
        //var returnedUser = await userRepository.GetFirstOrDefaultAsync(x => x.UserName == user.UserName
        //&& x.PasswordHash == user.PasswordHash);

        //if (returnedUser == null)
        //{
        //    returnedUser = await userRepository.AddAsync(user);
        //}

        //employee.UserId = returnedUser.Id;

        employee = await employeeRepository.AddAsync(employee);
        await employeeRepository.SaveChangesAsync();

        return employee;
    }

    public Employee? DeleteEmployee(Guid id)
    {
        var employee = employeeRepository.Remove(id);
        employeeRepository.SaveChanges();

        if (employee == null)
            return null;

        var user = userRepository.Remove(id);
        userRepository.SaveChanges();

        if (user == null)
            return null;

        employee.User = user;

        return employee;
    }

    public async Task<Employee?> DeleteEmployeeAsync(Guid id)
    {
        var employee = await employeeRepository.RemoveAsync(id);
        await employeeRepository.SaveChangesAsync();

        if (employee == null) 
            return null;

        var user = await userRepository.RemoveAsync(id);
        await userRepository.SaveChangesAsync();

        if (user == null)
            return null;

        employee.User = user;

        return employee;
    }

    public IEnumerable<Employee>? GetAllEmployees()
    {
        var employees = employeeRepository.GetAll();

        if (employees == null)
            return null;

        foreach (var employee in employees)
        {
            var user = userRepository.GetById(employee.UserId);

            if (user == null)
                continue;

            employee.User = user;
        }

        return employees;
    }

    public async Task<IEnumerable<Employee>?> GetAllEmployeesAsync()
    {
        var employees = await employeeRepository.GetAllAsync();

        if (employees == null)
            return null;

        foreach (var employee in employees)
        {
            var user = await userRepository.GetByIdAsync(employee.UserId);

            if (user == null)
                continue;

            employee.User = user;
        }

        return employees;
    }

    public Employee? GetEmployeeById(Guid id)
    {
        var employee = employeeRepository.GetById(id);

        if (employee == null)
            return null;

        var user = userRepository.GetById(id);

        if (user == null)
            return null;

        employee.User = user;

        return employee;
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);

        if (employee == null)
            return null;

        var user = await userRepository.GetByIdAsync(id);

        if (user == null)
            return null;

        employee.User = user;

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

        var role = roleRepository.GetById(employee.UserId);

        var permissions = rolePermissionService.GetPermissionsByRoleId(role.Id);

        var token = jwtProvider.Generate(user.Id, user.Email, null, permissions);

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

        var role = await roleRepository.GetByIdAsync(employee.RoleId);

        if (role is null)
            return null;

        var permissions = await rolePermissionService.GetPermissionsByRoleIdAsync(role.Id);

        var token = jwtProvider.Generate(user.Id, user.Email, null, permissions);

        return token;
    }

    public Employee? UpdateEmployee(Guid id, Employee employee)
    {
        var returnedEmployee = employeeRepository.Update(id, employee);
        employeeRepository.SaveChanges();

        if (returnedEmployee == null)
            return null;

        var user = userRepository.GetById(id);

        if (user is null)
            return null;

        returnedEmployee.User = user;

        return returnedEmployee;
    }

    public async Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee)
    {
        var returnedEmployee = await employeeRepository.UpdateAsync(id, employee);
        await employeeRepository.SaveChangesAsync();

        if (returnedEmployee == null)
            return null;

        var user = await userRepository.GetByIdAsync(id);

        if (user is null)
            return null;

        returnedEmployee.User = user;

        return returnedEmployee;
    }
}
