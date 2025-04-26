using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class PostTag
    {
        [Key]
        [Column("id")]

        public int Id { get; set; }

        [Column("postId")]
        [ForeignKey("PostId")]
        public int? PostId { get; set; }

        [Column("tagId")]
        [ForeignKey("TagId")]
        public int? TagId { get; set; }

        public Post? Post { get; set; }
        public Tag? Tag { get; set; }

    }
}
