using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Entities.AppEntities;

public partial class Employee
{   
    public Employee()
    {
    }
    [Key, Column("id", TypeName = "nvarchar(450)")]
    [ForeignKey("User")]
    public string? UserId { get; set; }

    [Required, Column("hireDate")]
    public DateTime HireDate { get; set; }

    public string RoleId { get; set; }

    //public ICollection<Booking> Bookings { get; set; }

    //public ICollection<Post> Posts { get; set; }

    public Role Role { get; set; }

    public User User { get; set; }

}