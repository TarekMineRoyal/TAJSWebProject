using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

// Assuming you have a reference to the PayPalHttp library
using PayPalHttp;

namespace Application.IServices
{
    public interface IPayPalService
    {
        Task<Order> CreateOrderAsync(decimal amount, string currency);
        Task<Order> CaptureOrderAsync(string orderId);

        /// <summary>
        /// Issues a refund for a previously captured PayPal payment.
        /// </summary>
        /// <param name="captureId">The ID of the captured payment to be refunded.</param>
        /// <param name="amount">The amount to refund.</param>
        /// <param name="currency">The currency of the amount.</param>
        /// <returns>The HttpResponse from PayPal's API.</returns>
        Task<HttpResponse> RefundPaymentAsync(string captureId, decimal amount, string currency);
    }
}