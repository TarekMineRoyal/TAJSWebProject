using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            PaymentTransactions = new HashSet<PaymentTransaction>();
        }
        [Key]
        [Column("id")]

        public int Id { get; set; }

        [Required]
        [Column("method", TypeName = "nvarchar(50)")]
        public string? Method { get; set; }

        [Required]
        [Column("icon", TypeName = "nvarchar(50)")]
        public string? Icon { get; set; }

        public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }
}
