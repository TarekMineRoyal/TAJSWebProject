using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    /// <summary>
    /// Represents the status of a booking
    /// </summary>
    public enum BType
    {
        /// <summary>
        /// Booking is pending approval
        /// </summary>
        Pending,

        /// <summary>
        /// Booking has been approved
        /// </summary>
        Approved
    }

    /// <summary>
    /// Represents a booking entity that serves as the base for both car and trip bookings
    /// </summary>
    public partial class Booking
    {
        /// <summary>
        /// Initializes a new instance of the Booking class with default collections
        /// </summary>
        public Booking()
        {
            Payments = new HashSet<Payment>();
            CarBooking = new CarBooking();
            TripBooking = new TripBooking();
        }

        #region Key Properties
        /// <summary>
        /// The unique identifier for the booking
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key for the associated car booking (nullable)
        /// </summary>
        [Column("carBookingId")]
        public int? CarBookingId { get; set; }

        /// <summary>
        /// Foreign key for the associated trip booking (nullable)
        /// </summary>
        [Column("tripBookingId")]
        public int? TripBookingId { get; set; }
        #endregion

        #region Booking Details
        /// <summary>
        /// The type of booking (true for car rental, false for trip)
        /// Note: Consider using an enum for better readability
        /// </summary>
        [Required]
        [Column("bookingType")]
        public bool BookingType { get; set; }

        /// <summary>
        /// The start date and time of the booking
        /// </summary>
        [Required]
        [Column("startDateTime", TypeName = "datetime2(7)")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// The end date and time of the booking
        /// </summary>
        [Required]
        [Column("endDateTime", TypeName = "datetime2(7)")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// The current status of the booking
        /// </summary>
        [Required]
        [Column("status")]
        [EnumDataType(typeof(BType))]
        public BType Status { get; set; }

        /// <summary>
        /// The number of passengers included in the booking
        /// </summary>
        [Required]
        [Column("numOfPassengers")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of passengers must be at least 1")]
        public int NumberOfPassengers { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// Collection of payments associated with this booking
        /// </summary>
        public virtual ICollection<Payment> Payments { get; set; }

        /// <summary>
        /// The associated car booking details (if this is a car rental)
        /// </summary>
        public virtual CarBooking? CarBooking { get; set; }

        /// <summary>
        /// The associated trip booking details (if this is a trip)
        /// </summary>
        public virtual TripBooking? TripBooking { get; set; }
        #endregion
    }
}