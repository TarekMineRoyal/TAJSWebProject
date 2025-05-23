using Application.DTOs.User;

namespace Application.DTOs.Customer;

public class CustomerResponse
{

    public UserResponse UserResponse { get; set; }

    //public string Id { get; set; }

    //public string UserName { get; set; }

    //public string Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Whatsapp { get; set; }

    public string? Country { get; set; }
}
