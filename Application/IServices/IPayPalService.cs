using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPayPalService
    {
        Task<Order> CreateOrderAsync(decimal amount, string currency);
        Task<Order> CaptureOrderAsync(string orderId);
        Task<PayPalHttp.HttpResponse> RefundPaymentAsync(string captureId, decimal amount, string currency);
    }
}