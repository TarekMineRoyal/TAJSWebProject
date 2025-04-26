using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum PType // Post Type Enum
    {
        Pending,
        Pinned,
        Published,
        Deleted,
        Unpublished,
    }
    public partial class Post
    {
        public Post()
        {
            PostTags = new HashSet<PostTag>();
            SeoMetadata = new HashSet<SeoMetadata>();
        }

        [Key]
        [Column("id")]

        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        [Required]
        [Column("body")]
        public string? Body { get; set; }

        [Required]
        [Column("image", TypeName = "nvarchar(50)")]
        public string? Image { get; set; }

        [Required]
        [Column("slug", TypeName = "nvarchar(50)")]
        public string? Slug { get; set; }

        [Required]
        [Column("views")]
        public int Views { get; set; }

        [Required]
        [Column("status")]
        [EnumDataType(typeof(TType))]
        public PType? Status { get; set; }

        [Column("postTypeId")]
        [ForeignKey("PostTypeId")]
        public int? PostTypeId { get; set; }

        [Required]
        [Column("summary", TypeName = "nvarchar(50)")]
        public string? Summary { get; set; }

        [Required]
        [Column("publishDate", TypeName = "datetime2(7)")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Column("employeeId")]
        [ForeignKey("Employee")]
        public string? EmployeeId { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }

        public virtual ICollection<SeoMetadata> SeoMetadata { get; set; }

        public PostType? PostType { get; set; }

        public Employee? Employee { get; set; }

    }
}
