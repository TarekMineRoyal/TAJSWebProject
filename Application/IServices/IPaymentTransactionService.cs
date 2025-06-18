using Application.DTOs.Payment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPaymentTransactionService
    {
        public Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO transaction);
        public Task<ResponsePaymentTransactionDTO> GetPaymentTransactionById(int id);
        public Task<IEnumerable<ResponsePaymentTransactionDTO>?> GetAllPaymentTransactions();

        // Add these new methods for the PayPal flow
        Task<string> CreatePayPalOrderAsync(int bookingId);
        Task<object> CapturePayPalOrderAsync(string orderId);
    }
}
