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
        public Task<IEnumerable<PaymentResponse>> GetAllPayments();

        public Task<IEnumerable<PaymentResponse>> GetPaymentsByBookingId(int bookingId);

        public Task<PaymentResponse> AddPayment(RequestPaymentDTO payment);
    }
}
