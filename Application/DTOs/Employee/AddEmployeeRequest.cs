using Application.DTOs.User;

namespace Application.DTOs.Employee;

public class AddEmployeeRequest
{
    public SignUpUserRequest user { get; set; }

    public DateTime HireDate { get; set; }

    public string RoleId { get; set; }
}
