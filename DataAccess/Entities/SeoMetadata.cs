using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class SeoMetadata
    {
        [Key]
        [Column("id")]

        public int Id { get; set; }
        [Required]
        [Column("urlSlug", TypeName = "nvarchar(50)")]
        public string? UrlSlug { get; set; }

        [Required]
        [Column("metaTitle", TypeName = "nvarchar(50)")]
        public string? MetaTitle { get; set; }

        [Required]
        [Column("metaDescription", TypeName = "nvarchar(50)")]
        public string? MetaDescription { get; set; }

        [Required]
        [Column("metaKeywords", TypeName = "nvarchar(50)")]
        public string? MetaKeywords { get; set; }

        [Column("postId")]
        public int? PostId { get; set; }

        public Post? Post { get; set; }
    }
}
