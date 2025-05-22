using Domain.Entities;

namespace Application.IServices;

public interface IEmployeeService
{
    public Employee? GetEmployeeById(int id);

    public Employee AddEmployee(Employee employee);

    public Employee? UpdateEmployee(Employee employee);

    public Employee? DeleteEmployee(Employee employee);


    public Task<Employee?> GetEmployeeByIdAsync(int id);

    public Task<Employee> AddEmployeeAsync(Employee employee);

    public Task<Employee?> UpdateEmployeeAsync(Employee employee);

    public Task<Employee?> DeleteEmployeeAsync(Employee employee);
}
