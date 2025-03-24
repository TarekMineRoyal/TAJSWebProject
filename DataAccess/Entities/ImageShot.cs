using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class ImageShot
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("carBookingId")]
        public int? CarBookingId { get; set; }

        [Required]
        [Column("path", TypeName = "nvarchar(50)")]
        public string? Path { get; set; }

        [Required]
        [Column("type", TypeName = "nvarchar(50)")]
        public string? Type { get; set; }

        public CarBooking? CarBooking { get; set; }

    }
}
