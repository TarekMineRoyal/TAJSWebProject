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
    /// Represents a car rental booking with specific vehicle and location details
    /// </summary>
    public partial class CarBooking
    {
        /// <summary>
        /// Initializes a new instance of the CarBooking class
        /// </summary>
        public CarBooking()
        {
            // Note: Removed Booking initialization as it can cause issues with EF Core
            ImageShots = new HashSet<ImageShot>();
        }

        #region Key Properties
        /// <summary>
        /// The unique identifier for the car booking
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }
        #endregion

        #region Booking Reference
        /// <summary>
        /// Foreign key to the associated booking
        /// </summary>
        [Column("bookingId")]
        public int BookingId { get; set; }
        #endregion

        #region Vehicle Information
        /// <summary>
        /// The car being booked (nullable if car might be deleted)
        /// </summary>
        [Required]
        [Column("carId")]
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        #endregion

        #region Location Details
        /// <summary>
        /// The pickup location for the car rental
        /// </summary>
        [Required(ErrorMessage = "Pickup location is required")]
        [Column("pickupLocation", TypeName = "nvarchar(100)")]
        [StringLength(100, ErrorMessage = "Pickup location cannot exceed 100 characters")]
        public string? PickupLocation { get; set; }

        /// <summary>
        /// The drop-off location for the car rental
        /// </summary>
        [Required(ErrorMessage = "Drop-off location is required")]
        [Column("dropoffLocation", TypeName = "nvarchar(100)")]
        [StringLength(100, ErrorMessage = "Drop-off location cannot exceed 100 characters")]
        public string? DropoffLocation { get; set; }
        #endregion

        #region Service Options
        /// <summary>
        /// Indicates whether the booking includes a driver
        /// </summary>
        [Required]
        [Column("withDriver")]
        public bool WithDriver { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// The main booking information
        /// </summary>
        public virtual Booking? Booking { get; set; }

        /// <summary>
        /// Collection of images associated with this car booking
        /// </summary>
        public virtual ICollection<ImageShot> ImageShots { get; set; }
        #endregion
    }
}