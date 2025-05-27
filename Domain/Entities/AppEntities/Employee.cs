<<<<<<< HEAD
﻿using Domain.Entities.Identity;
=======
﻿using System;
using System.Collections.Generic;
>>>>>>> parent of cd0f207 (Samrah Gay)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


<<<<<<< HEAD

namespace Domain.Entities.AppEntities;

public partial class Employee
{   
    public Employee()
=======
namespace Domain.Entities.AppEntities
{
    public partial class Employee
>>>>>>> parent of cd0f207 (Samrah Gay)
    {
        public Employee()
        {
            Bookings = new HashSet<Booking>();
            Posts = new HashSet<Post>();
        }
        [Key, Column("id", TypeName = "nvarchar(450)")]
        [ForeignKey("User")]
        public string? UserId { get; set; }

        [Required, Column("hireDate")]
        public DateTime HireDate { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}