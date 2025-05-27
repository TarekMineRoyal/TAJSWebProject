using Application.DTOs.User;

namespace Application.DTOs.Customer;

public class AddCustomerRequest
{
    public SignUpUserRequest user { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Whatsapp { get; set; }

    public string? Country { get; set; }
}
