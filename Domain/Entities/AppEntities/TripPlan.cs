using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AppEntities
{
    public partial class TripPlan
    {
        public TripPlan()
        {
            TripPlanCars = new HashSet<TripPlanCar>();
            TripBookings = new HashSet<TripBooking>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Start Date Time is required")]
        [Column("startDateTime", TypeName = "datetime2(7)")]
        public DateTime StartDateTime { get; set; }

        [Required(ErrorMessage = "End Date Time is required")]
        [Column("endDateTime", TypeName = "datetime2(7)")]
        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Column("duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Included Services are required")]
        [Column("includedServices")]
        public string? IncludedServices { get; set; }

        [Required(ErrorMessage = "Stops are required")]
        [Column("stops")]
        public string? Stops { get; set; }

        [Required(ErrorMessage = "Meals plan is required")]
        [Column("mealsPlan")]
        public string? MealsPlan { get; set; }

        [Required(ErrorMessage = "Hotels Stays are required")]
        [Column("hotelsStays")]
        public string? HotelsStays { get; set; }

        [Required]
        [Column("regionId")]
        [ForeignKey("RegionId")]
        public int RegionId { get; set; }

        [Required]
        [Column("tripId")]
        [ForeignKey("TripId")]
        public int TripId { get; set; }

        public Region? Region { get; set; }
        public Trip? Trip { get; set; }
        public virtual ICollection<TripPlanCar> TripPlanCars { get; set; }
        public virtual ICollection<TripBooking> TripBookings { get; set; }

    }
}
