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
        [Column("bookingId")]
        public int? BookingId { get; set; }

        [Required]
        [Column("withGuide")]
        public bool WithGuide { get; set; }
        public virtual Booking Booking { get; set; }

    }
}
