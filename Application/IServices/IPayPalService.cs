// Application/IServices/IPayPalService.cs
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPayPalService
    {
        Task<string> CreateOrderAsync(decimal amount, string currency);
        Task<string> CaptureOrderAsync(string orderId);
        Task<string> RefundPaymentAsync(string captureId, decimal amount, string currency);
    }
}