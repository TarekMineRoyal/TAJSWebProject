// Application/IServices/IVirtualPaymentService.cs
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVirtualPaymentService
    {
        Task<object> MakeDeposit(int bookingId, decimal amount);
        Task<object> MakeRefund(int bookingId, decimal amount);
    }
}