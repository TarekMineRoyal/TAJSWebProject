using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class TripBooking
    {
        public TripBooking()
        {
            Booking = new Booking();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("BookingId")]
        [Column("BookingId")]
        public int? BookingId { get; set; }

        [Required]
        [Column("withGuide")]
        public bool WithGuide { get; set; }



        [Column("tripPlanId")]
        [ForeignKey("TripPlanId")]
        public int? TripPlanId { get; set; }

        public TripPlan? TripPlan { get; set; }
        public virtual Booking Booking { get; set; }

    }
}
