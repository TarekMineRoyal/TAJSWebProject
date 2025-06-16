// Application/DTOs/Payment/ResponsePaymentTransactionDTO.cs
using Domain.Entities.AppEntities;

namespace Application.DTOs.Payment
{
    public class ResponsePaymentTransactionDTO
    {
        public int Id { get; set; }
        public TType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }

        // Add PayPal fields
        public string? PayPalOrderId { get; set; }
        public string? PayPalCaptureId { get; set; }
        public string? PayPalRefundId { get; set; }

        // Stripe fields
        public string? StripePaymentIntentId { get; set; }
        public string? StripeRefundId { get; set; }
    }
}