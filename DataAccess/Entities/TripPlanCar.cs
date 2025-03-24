using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class TripPlanCar
    {
        public TripPlanCar()
        {
            //CarBookings = new HashSet<CarBooking>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }

        [Column("tripPlanIdId")]
        public int? TripPlanId { get; set; }

        [Column("carId")]
        public int? CarId { get; set; }

        public TripPlan? TripPlan { get; set; }
        public Car? Car { get; set; }

        //public Category? Category { get; set; }
        //public virtual ICollection<CarBooking> CarBookings { get; set; }
    }
}
