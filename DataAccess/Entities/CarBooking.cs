using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class CarBooking
    {
        public CarBooking()
        {
            Booking = new Booking();
            ImageShots = new HashSet<ImageShot>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("bookingId")]
        public int? BookingId { get; set; }

        [Column("carId")]
        public Car? Car { get; set; }

        [Required]
        [Column("pickupLocation", TypeName = "nvarchar(50)")]
        public string? PickupLocation { get; set; }

        [Required]
        [Column("dropoffLocation", TypeName = "nvarchar(50)")]
        public string? DropoffLocation { get; set; }

        [Required]
        [Column("withDriver")]
        public bool WithDriver { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ICollection<ImageShot> ImageShots { get; set; }

    }
}
