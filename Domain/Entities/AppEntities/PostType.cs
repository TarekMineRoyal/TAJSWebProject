using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AppEntities
{
    public partial class PostType
    {
        public PostType()
        {
            Posts = new HashSet<Post>();
        }
        [Key]
        [Column("id")]

        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "nvarchar(50)")]
        public string? Title { get; set; }

        [Required]
        [Column("description")]
        public string? Description { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
