using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AppEntities
{
    public partial class TripPlanCar
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(16,2)")]
        public decimal Price { get; set; }

        [Column("tripPlanId")]
        [ForeignKey("TripPlanId")]
        public int? TripPlanId { get; set; }

        [Column("carId")]
        [ForeignKey("CarId")]
        public int? CarId { get; set; }

        public TripPlan? TripPlan { get; set; }
        public Car? Car { get; set; }
    }
}
