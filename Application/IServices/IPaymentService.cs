using Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPaymentService
    {
        public Task<IEnumerable<ResponsePaymentDTO>> GetAllPayments();
        public Task<ResponsePaymentDTO> GetPaymentById(int id);
        public Task<ResponsePaymentDTO> AddPayment(RequestPaymentDTO payment);
    }
}
