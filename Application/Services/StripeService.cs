using Application.IServices;
using Stripe;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StripeService : IStripeService
    {
        public StripeService()
        {
            // The API key is set globally in Program.cs
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, string currency)
        {
            // Stripe requires the amount in the smallest currency unit (e.g., cents for USD)
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency.ToLower(),
                PaymentMethodTypes = new() { "card" }
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }

        public async Task<Refund> CreateRefundAsync(string paymentIntentId, decimal amount)
        {
            var options = new RefundCreateOptions
            {
                PaymentIntent = paymentIntentId,
                Amount = (long)(amount * 100),
            };

            var service = new RefundService();
            return await service.CreateAsync(options);
        }
    }
}