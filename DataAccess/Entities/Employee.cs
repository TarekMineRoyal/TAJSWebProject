using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class Employee
    {
        [Key, Column("id", TypeName = "nvarchar(450)")]
        public string? Id { get; set; }

        [Required, Column("hireDate")]
        public DateTime HireDate { get; set; }

    }
}