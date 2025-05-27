using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities.Identity;

public class User : IdentityUser
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    
    public string Name { get; set; }


    [Required]
    public string Address { get; set; }
}