using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class TripPlan
    {
        public TripPlan()
        {
            TripPlanCars = new HashSet<TripPlanCar>();
            TripBookings = new HashSet<TripBooking>();
        }
        [Key]
        [Column("id")]

        public int Id { get; set; }
        [Required]
        [Column("startDateTime", TypeName = "datetime2(7)")]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Column("endDateTime", TypeName = "datetime2(7)")]
        public DateTime EndDateTime { get; set; }

        [Required]
        [Column("duration")]
        public int Duration { get; set; }

        [Required]
        [Column("includedServices")]
        public string? IncludedServices { get; set; }

        [Required]
        [Column("stops")]
        public string? Stops { get; set; }

        [Required]
        [Column("mealsPlan")]
        public string? MealsPlan { get; set; }

        [Required]
        [Column("hotelsStays")]
        public string? HotelsStays { get; set; }
        [Column("regionId")]
        [ForeignKey("RegionId")]
        public int? RegionId { get; set; }

        [Column("tripId")]
        [ForeignKey("TripId")]
        public int? TripId { get; set; }

        public Region? Region { get; set; }

        public Trip? Trip { get; set; }
        public virtual ICollection<TripPlanCar> TripPlanCars { get; set; }

        public virtual ICollection<TripBooking> TripBookings { get; set; }

    }
}
