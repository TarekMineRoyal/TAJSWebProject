using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class Region
    {
        public Region()
        {
            TripPlans = new HashSet<TripPlan>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("bookingId")]
        public int? BookingId { get; set; }

        [Required]
        [Column("name", TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        public virtual ICollection<TripPlan> TripPlans { get; set; }

    }
}
