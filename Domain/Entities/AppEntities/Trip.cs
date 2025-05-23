using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities.AppEntities
{
    public partial class Trip
    {
        public Trip()
        {
            TripPlans = new HashSet<TripPlan>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        [Column("slug", TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Slug cannot exceed 50 characters")]
        public string? Slug { get; set; }

        [Required(ErrorMessage = "Trip Availibility is required")]
        [Column("isAvailable")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column("description", TypeName = "nvarchar(250)")]
        [StringLength(50, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? Description { get; set; }

        [Required]
        [Column("isPrivate")]
        public bool IsPrivate { get; set; }

        public virtual ICollection<TripPlan> TripPlans { get; set; }

    }
}
