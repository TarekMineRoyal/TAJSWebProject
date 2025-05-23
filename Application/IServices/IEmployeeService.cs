using Domain.Entities.AppEntities;

namespace Application.IServices;

public interface IEmployeeService
{
    public Employee? GetEmployeeById(int id);

    public Employee CreateEmployee(Employee employee);

    public Employee? UpdateEmployee(Employee employee);

    public Employee? DeleteEmployee(Employee employee);
}
