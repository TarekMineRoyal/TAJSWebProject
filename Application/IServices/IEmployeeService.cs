using Domain.Entities;
using Domain.Entities.AppEntities;
using Domain.Entities.Identity;

namespace Application.IServices;

public interface IEmployeeService
{
    public Employee? GetEmployeeById(int id);

<<<<<<< HEAD
    public IEnumerable<Employee>? GetAllEmployees();
=======
    public Employee CreateEmployee(Employee employee);
>>>>>>> parent of cd0f207 (Samrah Gay)

    public Employee? UpdateEmployee(Employee employee);

<<<<<<< HEAD
    public Employee? UpdateEmployee(Guid id, Employee employee);

    public Employee? DeleteEmployee(Guid employeeId);

    

    public Task<Employee?> GetEmployeeByIdAsync(Guid id);

    public Task<IEnumerable<Employee>?> GetAllEmployeesAsync();

    public Task<Employee?> AddEmployeeAsync(User user, Employee employee);

    public Task<Employee?> UpdateEmployeeAsync(Guid id, Employee employee);

    public Task<Employee?> DeleteEmployeeAsync(Guid id);

=======
    public Employee? DeleteEmployee(Employee employee);
>>>>>>> parent of cd0f207 (Samrah Gay)
}
