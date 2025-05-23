using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AppEntities
{
    /// <summary>
    /// Represents a vehicle available for rental or inclusion in trips
    /// </summary>
    public partial class Car
    {
        /// <summary>
        /// Initializes a new instance of the Car class with empty collections
        /// </summary>
        public Car()
        {
            CarBookings = new HashSet<CarBooking>();
            TripPlanCars = new HashSet<TripPlanCar>();
        }

        #region Key Properties
        /// <summary>
        /// The unique identifier for the car
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        #endregion

        #region Vehicle Details
        /// <summary>
        /// The model name of the car (e.g., "Toyota Camry")
        /// </summary>
        [Required(ErrorMessage = "Car model is required")]
        [Column("model", TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters")]
        public string? Model { get; set; }

        /// <summary>
        /// The seating capacity of the car
        /// </summary>
        [Required(ErrorMessage = "Seat count is required")]
        [Column("seats")]
        [Range(1, 40, ErrorMessage = "Seats must be between 1 and 40")]
        public int Seats { get; set; }

        /// <summary>
        /// The primary color of the car
        /// </summary>
        [Required(ErrorMessage = "Color is required")]
        [Column("color", TypeName = "nvarchar(30)")]
        [StringLength(30, ErrorMessage = "Color cannot exceed 30 characters")]
        public string? Color { get; set; }

        /// <summary>
        /// The filename or path of the car's primary image
        /// </summary>
        [Required(ErrorMessage = "Image reference is required")]
        [Column("image", TypeName = "nvarchar(255)")]  // Expanded length for file paths
        public string? Image { get; set; }

        /// <summary>
        /// Maximum baggage weight capacity (in kg)
        /// </summary>
        [Required(ErrorMessage = "Maximum baggage weight is required")]
        [Column("mbw", TypeName = "decimal(16,2)")]
        [Range(0.01, 1000, ErrorMessage = "Baggage weight must be between 0.01 and 1,000 kg")]
        public decimal Mbw { get; set; }

        #endregion

        #region Pricing Information
        /// <summary>
        /// Price per hour for rental
        /// </summary>
        [Required(ErrorMessage = "Price per hour is required")]
        [Column("pph", TypeName = "decimal(16,2)")]
        [Range(0.01, 10000000, ErrorMessage = "Price must be between 0.01 and 10,000,000")]
        public decimal Pph { get; set; }

        /// <summary>
        /// Price per day for rental
        /// </summary>
        [Required(ErrorMessage = "Price per day is required")]
        [Column("ppd", TypeName = "decimal(16,2)")]
        [Range(0.01, 10000000, ErrorMessage = "Price must be between 0.01 and 10,000,000")]
        public decimal Ppd { get; set; }
        #endregion

        #region Relationships
        /// <summary>
        /// Foreign key for the car's category (optional)
        /// </summary>
        [Column("categoryId")]
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// The category this car belongs to (optional)
        /// </summary>
        public Category? Category { get; set; }

        /// <summary>
        /// Collection of trip plans that include this car
        /// </summary>
        public virtual ICollection<TripPlanCar> TripPlanCars { get; set; }

        /// <summary>
        /// Collection of bookings for this car
        /// </summary>
        public virtual ICollection<CarBooking> CarBookings { get; set; }
        #endregion
    }
}