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
    /// Represents a category for organizing vehicles in the system
    /// </summary>
    public partial class Category
    {
        #region Key Properties
        /// <summary>
        /// The unique identifier for the category
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }
        #endregion

        #region Category Information
        /// <summary>
        /// The display title of the category (e.g., "SUV", "Luxury", "Compact")
        /// </summary>
        [Required(ErrorMessage = "Category title is required")]
        [Column("title", TypeName = "nvarchar(50)")]
        [StringLength(50, ErrorMessage = "Category title cannot exceed 50 characters")]
        public string Title { get; set; } = string.Empty;
        #endregion
    }
}