using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


<<<<<<< HEAD:Domain/Entities/Employee.cs
namespace Domain.Entities;

public partial class Employee
{   
    public Employee()
=======
namespace Domain.Entities.AppEntities
{
    public partial class Employee
>>>>>>> 7fa6cce8e9f093d84c3295cd73b8e4a1cda36e25:Domain/Entities/AppEntities/Employee.cs
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