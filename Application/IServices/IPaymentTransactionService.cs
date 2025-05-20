using Application.DTOs.Payment;
using Domain.Entities;

namespace Application.IServices
{
    public interface IPaymentTransactionService
    {
        public Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO transaction);
        public Task<ResponsePaymentTransactionDTO> GetPaymentTransactionById(int id);
        public Task<IEnumerable<ResponsePaymentTransactionDTO>?> GetAllPaymentTransactions();
        
    }
}
