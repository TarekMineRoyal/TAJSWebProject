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

        [Required]
        [Column("slug", TypeName = "nvarchar(50)")]
        public string? Slug { get; set; }

        [Required]
        [Column("isAvailable")]
        public bool IsAvailable { get; set; }

        [Required]
        [Column("description", TypeName = "nvarchar(250)")]
        public string? Description { get; set; }

        [Required]
        [Column("isPrivate")]
        public bool IsPrivate { get; set; }

        public virtual ICollection<TripPlan> TripPlans { get; set; }

    }
}
