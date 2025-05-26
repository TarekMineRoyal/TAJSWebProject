using Domain.Entities.AppEntities;

namespace Application.IServices;

public interface IEmployeeService
{
    public Employee? GetEmployeeById(Guid id);

<<<<<<< HEAD
    public IEnumerable<Employee>? GetAllEmployees();
=======
    public Employee CreateEmployee(Employee employee);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25

    public Employee? AddEmployee(User user, Employee employee);

<<<<<<< HEAD
    public Employee? UpdateEmployee(Guid id, Employee employee);

    public Employee? DeleteEmployee(Guid employeeId);

    public string? LogIn(string userName, string password);


    public Task<Employee?> GetEmployeeByIdAsync(Guid id);

    public Task<IEnumerable<Employee>?> GetAllEmployeesAsync();

    public Task<Employee?> AddEmployeeAsync(User user, Employee employee);

    public Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee);

    public Task<Employee?> DeleteEmployeeAsync(Guid id);

    public Task<string> LogInAsync(string userName, string password);
=======
    public Employee? DeleteEmployee(Employee employee);
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25
}
