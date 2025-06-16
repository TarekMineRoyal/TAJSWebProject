using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AppEntities
{
    public enum TType { Deposit, Final, Refund }

    public partial class PaymentTransaction
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("type")]
        [EnumDataType(typeof(TType))]
        public TType? TransactionType { get; set; }

        [Required]
        [Column("amount", TypeName = "decimal(16,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column("transactionDate", TypeName = "datetime2(7)")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("paymentId")]
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }

        [Required]
        [Column("paymentMethodId")]
        [ForeignKey("PaymentMethodId")]
        public int PaymentMethodId { get; set; }

        // --- Add these properties ---
        public string? StripePaymentIntentId { get; set; }
        public string? PayPalOrderId { get; set; }
        public string? PayPalCaptureId { get; set; }
        public string? PayPalRefundId { get; set; }
        public string? StripeRefundId { get; set; }
        // --- End of new properties ---

        public Payment? Payment { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}