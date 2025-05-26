using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.AppEntities
{
    public partial class Tag
    {
        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }
        [Key]
        [Column("id")]

        public int Id { get; set; }
        [Required]
        [Column("name", TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
