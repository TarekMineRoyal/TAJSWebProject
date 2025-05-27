using Domain.Entities;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.IServices;

public interface IEmployeeService
{
    public Employee? GetEmployeeById(Guid id);

    public IEnumerable<Employee>? GetAllEmployees();

    public Employee? AddEmployee(User user, Employee employee);

    public Employee? UpdateEmployee(Guid id, Employee employee);

    public Employee? DeleteEmployee(Guid employeeId);

    

    public Task<Employee?> GetEmployeeByIdAsync(Guid id);

    public Task<IEnumerable<Employee>?> GetAllEmployeesAsync();

    public Task<Employee?> AddEmployeeAsync(User user, Employee employee);

    public Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee);

    public Task<Employee?> DeleteEmployeeAsync(Guid id);

}
