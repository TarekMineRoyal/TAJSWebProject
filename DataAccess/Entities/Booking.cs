using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public enum BType
    {
        Pending,
        Approved,
    }

    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
            
            CarBooking = new CarBooking();
            TripBooking = new TripBooking();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("carBookingId")]
        public int? CarBookingId { get; set; }

        [Column("tripBookingId")]
        public int? TripBookingId { get; set; }

        [Required]
        [Column("bookingType")]
        public bool BookingType { get; set; }

        [Required]
        [Column("startDateTime", TypeName = "datetime2(7)")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Column("endDateTime", TypeName = "datetime2(7)")]
        public DateTime EndDateTime { get; set; }

        [Required]
        [Column("status")]
        [EnumDataType(typeof(BType))]
        public BType Status { get; set; }

        [Required]
        [Column("numOfPassengers")]
        public int NumberOfPassengers { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual CarBooking CarBooking { get; set; }
        public virtual TripBooking TripBooking { get; set; }

    }
}
