using Application.DTOs.User;

namespace Application.DTOs.Employee;

public class EmployeeResponse
{
    public UserResponse UserResponse { get; set; }

    public DateTime HireDate { get; set; }
}
