using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPaymentService
    {
        public Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction transaction);
        public Task<PaymentTransaction> GetPaymentTransaction(int id);
    }
}
