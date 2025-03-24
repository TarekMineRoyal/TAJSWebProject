using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public enum StatusEnum
    {
        Pending, Complete, Refund
    }
    public partial class Payment
    {
        public Payment()
        {
            PaymentTransactions = new HashSet<PaymentTransaction>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("bookingId")]
        public int? BookingId { get; set; }

        [Required]
        [Column("satatus")]
        [EnumDataType(typeof(StatusEnum))]
        public StatusEnum? Status { get; set; }

        [Required]
        [Column("amountDue", TypeName = "decimal(16,2)")]
        public decimal AmountDue { get; set; }

        [Required]
        [Column("amountPaid", TypeName = "decimal(16,2)")]
        public decimal AmountPaid { get; set; }

        [Required]
        [Column("paymentDate", TypeName = "datetime2(7)")]
        public DateTime PaymentDate { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }


        public Booking? Booking { get; set; }
        public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }
}
