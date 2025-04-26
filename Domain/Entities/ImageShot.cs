using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Represents an image associated with a car booking
    /// </summary>
    public partial class ImageShot
    {
        #region Key Properties
        /// <summary>
        /// The unique identifier for the image
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }
        #endregion

        #region Image Information
        /// <summary>
        /// The file path or URL of the image
        /// </summary>
        [Required(ErrorMessage = "Image path is required")]
        [Column("path", TypeName = "nvarchar(255)")]
        [StringLength(255, ErrorMessage = "Path cannot exceed 255 characters")]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// The type/category of the image (e.g., "interior", "exterior", "damage")
        /// </summary>
        [Required(ErrorMessage = "Image type is required")]
        [Column("type", TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        public string Type { get; set; } = string.Empty;
        #endregion

        #region Relationships
        /// <summary>
        /// Foreign key to the associated car booking (nullable)
        /// </summary>
        [Column("carBookingId")]
        [ForeignKey("CarBookingId")]
        public int? CarBookingId { get; set; }

        /// <summary>
        /// The car booking this image is associated with
        /// </summary>
        public virtual CarBooking? CarBooking { get; set; }
        #endregion
    }
}